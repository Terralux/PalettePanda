using UnityEngine;
using System.Collections;

public class BaseCharacterController : MonoBehaviour
{

	[Range(0.1f,20f)]
	public float movementSpeed = 1f;
	[Range(0.1f, 80f)]
	public float rotationSpeed = 10f;
	[Range(0.1f,100f)]
	public float jumpForce = 30f;
	[Range(0f,5f)]
	public float startAerialMovementSpeed = 0.5f;
	private bool isGrounded = false;
	private Animator anim;
	private Rigidbody rb;
	private float animSpeedModifier = 1f;
	private Transform referenceTransform;
	private Vector3 startAerialMovement = Vector3.zero;
	[SerializeField]
	float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
	const float k_Half = 0.5f;

	public float startAerialMovementLimit = 0.5f;
	public float beginningOfMovementLimit = 5f;
	[Range(0.5f, 1f)]
	public float limiter = 0.6f;

	private Vector3 aerialMovement = Vector3.zero;
	
	void Awake ()
	{
		referenceTransform = Camera.main.transform;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	public void Move (Vector3 move, bool crouch, bool jump)
	{
		if (move.magnitude > 1f) {
			move.Normalize ();
		}

		CheckIfGrounded ();

		if (isGrounded && jump) {
			rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			isGrounded = false;
			startAerialMovement = rb.velocity;
			//anim.applyRootMotion = false;
		}

		UpdateAnimator (move);
		transform.LookAt (transform.position + move);
	}

	void UpdateAnimator (Vector3 move)
	{
		// update the animator parameters
		anim.SetFloat ("Forward", move.magnitude, 0.1f, Time.deltaTime);
		//anim.SetFloat("Turn", move.x, 0.1f, Time.deltaTime);
		anim.SetBool ("OnGround", isGrounded);
		if (!isGrounded) {
			anim.SetFloat ("Jump", rb.velocity.y);
		}
		
		// calculate which leg is behind, so as to leave that leg trailing in the jump animation
		// (This code is reliant on the specific run cycle offset in our animations,
		// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
		float runCycle =
			Mathf.Repeat (anim.GetCurrentAnimatorStateInfo (0).normalizedTime + m_RunCycleLegOffset, 1);
		float jumpLeg = (runCycle < k_Half ? 1 : -1) * move.z;
		if (isGrounded) {
			anim.SetFloat ("JumpLeg", jumpLeg);
		}
		
		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (isGrounded) {
			anim.speed = animSpeedModifier;
		} else {
			if (move.magnitude > 0f) {

				Vector3 temp = referenceTransform.TransformDirection (move * startAerialMovementSpeed).normalized;

				Vector3 placeholder = Vector3.RotateTowards(rb.velocity, new Vector3(rb.velocity.x + temp.x, rb.velocity.y, rb.velocity.z + temp.z), Mathf.PI/20, 1f).normalized * rb.velocity.magnitude;

				rb.velocity = new Vector3 (placeholder.x, rb.velocity.y, placeholder.z);

				Vector2 groundVelocity = new Vector2(rb.velocity.x, rb.velocity.z);

				if(groundVelocity.magnitude > startAerialMovementLimit){
					groundVelocity = groundVelocity.normalized * startAerialMovementLimit;
				}

				rb.velocity = new Vector3(groundVelocity.x, rb.velocity.y, groundVelocity.y);

			}
			// don't use that while airborne
			anim.speed = 1;
		}
	}
	
	private void CheckIfGrounded ()
	{
		RaycastHit hitInfo = new RaycastHit ();

		if (Physics.Raycast (transform.position + Vector3.up * 0.1f, Vector3.down, out hitInfo, 0.12f)) {
			isGrounded = true;
			startAerialMovement = Vector3.zero;
			anim.applyRootMotion = true;
		} else {
			isGrounded = false;
			anim.applyRootMotion = false;
		}
	}

	public void OnAnimatorMove ()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (isGrounded && Time.deltaTime > 0) {
			Vector3 v = (anim.deltaPosition * movementSpeed) / Time.deltaTime;
			
			// we preserve the existing y part of the current velocity.
			v.y = rb.velocity.y;
			rb.velocity = v;
		}
	}
}
