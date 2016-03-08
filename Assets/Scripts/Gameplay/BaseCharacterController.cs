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

	private float startAerialMovementLimit = 4.3f;
	private float beginningOfMovementLimit = 5f;
	private float limiter = 0.6f;

	private bool isHanging = false;
	private bool isWallsliding = false;
	[Range(-3,3f)]
	public float grabRange = 1f;
	[Range(-3,3f)]
	public float verticalGrabOffset = 1f;

	private Vector3 aerialMovement = Vector3.zero;

	public float planarOffset = 0.6f;
	public float lerpLimit = 0.5f;

	private BaseCharacterController controller;
	private float distanceModifier = 1f;
	private float rayCastLength = 3f;
	
	private Vector3 currentTarget;
	private Vector3 currentPosition;

	private bool isWaitingToSlide;

	[Range(0f,5f)]
	public float verticalWallslideSpeed;
	private Vector3 currentMove;

	[Range(0.01f, 1f)]
	public float wallJumpForceModifier;

	[Range(5f,50f)]
	public float wallJumpAngleLimit = 30f;

	private bool hasWallJumped = false;

	void Awake ()
	{
		referenceTransform = Camera.main.transform;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("GrabableObject") && rb.velocity.y < 0f && !isHanging && !isGrounded) {
			HangState(col);
		}
	}

	public void HangState(Collider col){

		float Ytarget = col.ClosestPointOnBounds (transform.position + Vector3.up * 3).y;

		Vector3 tempTransform = new Vector3 (transform.position.x, Ytarget, transform.position.z);

		RaycastHit hitInfo;

		LayerMask mask = 1 << 8;

		if (Physics.Raycast (tempTransform - Vector3.up * 0.5f, col.transform.position - tempTransform, out hitInfo, 4f, mask)) {
			transform.position = new Vector3(hitInfo.point.x, Ytarget, hitInfo.point.z);
			currentPosition = transform.position;

			transform.rotation = Quaternion.LookRotation(-hitInfo.normal, Vector3.up);

			GameObject go = new GameObject();
			go.transform.position = transform.position;

			isHanging = true;
			anim.SetBool ("Grab", isHanging);
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			isWallsliding = false;
		}
	}

	IEnumerator waitForClimbDeactivate(){
		yield return new WaitForSeconds (0.5f);
		anim.SetBool("ClimbUp", false);
	}

	public void Move (Vector3 move, bool crouch, bool jump)
	{
		move = referenceTransform.TransformDirection (move);
		currentMove = move;

		if (move.magnitude > 1f) {
			move = move.normalized;
		}

		if (!isHanging) {
			CheckIfGrounded ();
			if (!isWallsliding) {
				if (isGrounded && jump) {
					rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
					isGrounded = false;
					startAerialMovement = rb.velocity;
				}

				UpdateAnimator (move);

				if (!hasWallJumped) {
					transform.LookAt (transform.position + new Vector3 (move.x, 0, move.z));
				}
			} else {
				isWallsliding = !isGrounded;

				if (isWaitingToSlide) {
					rb.velocity = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
				} else {
					if (rb.velocity.y < verticalWallslideSpeed) {
						rb.velocity = new Vector3 (rb.velocity.x, -verticalWallslideSpeed, rb.velocity.z);
					}
				}

				if (jump) {
					Vector2 lookDirection = new Vector2 (transform.forward.x, transform.forward.z);
					float degreesBetweenInputAndLookDirection = Vector2.Angle (-lookDirection, -lookDirection + new Vector2 (move.x, move.z));
					Debug.Log(degreesBetweenInputAndLookDirection);

					if (degreesBetweenInputAndLookDirection > wallJumpAngleLimit) {
						//Find the direction to jump in

						float angleToRotateWith = Mathf.Deg2Rad * wallJumpAngleLimit;

						Vector2 jumpAnglePlus = new Vector2((Mathf.Cos(angleToRotateWith) * -lookDirection.x) - (Mathf.Sin(angleToRotateWith) * -lookDirection.y), 
												(Mathf.Cos(angleToRotateWith) * -lookDirection.y) + (Mathf.Sin(angleToRotateWith) * -lookDirection.x));

						angleToRotateWith = Mathf.Deg2Rad * -wallJumpAngleLimit;

						Vector2 jumpAngleMinus = new Vector2((Mathf.Cos(angleToRotateWith) * -lookDirection.x) - (Mathf.Sin(angleToRotateWith) * -lookDirection.y), 
												(Mathf.Cos(angleToRotateWith) * -lookDirection.y) + (Mathf.Sin(angleToRotateWith) * -lookDirection.x));
						
						if (Vector2.Distance ((-lookDirection + jumpAnglePlus).normalized, move) > Vector2.Distance ((-lookDirection + jumpAngleMinus).normalized, move)) {
							rb.velocity = new Vector3 (jumpAnglePlus.x * wallJumpForceModifier * jumpForce, jumpForce, jumpAnglePlus.y * wallJumpForceModifier * jumpForce);
							transform.LookAt (transform.position + new Vector3 (jumpAnglePlus.x, 0, jumpAnglePlus.y));
						} else {
							rb.velocity = new Vector3 (jumpAngleMinus.x * wallJumpForceModifier * jumpForce, jumpForce, jumpAngleMinus.y * wallJumpForceModifier * jumpForce);
							transform.LookAt (transform.position + new Vector3 (jumpAngleMinus.x, 0, jumpAngleMinus.y));
						}
					}else{
						//jump in move direction
						rb.velocity = new Vector3 (move.x * wallJumpForceModifier * jumpForce, jumpForce, move.z * wallJumpForceModifier * jumpForce);

						transform.LookAt (transform.position + new Vector3 (move.x, 0, move.z));
					}

					isGrounded = false;
					startAerialMovement = rb.velocity;
					isWallsliding = false;
					hasWallJumped = true;
				}

			}
		} else {

			transform.position = new Vector3(currentPosition.x, currentPosition.y - verticalGrabOffset, currentPosition.z);

			if(Vector3.Dot(move, transform.forward) > 0.7f && jump){
				anim.applyRootMotion = true;
				anim.SetBool("ClimbUp", true);
				StartCoroutine(waitForClimbDeactivate());

				isHanging = false;
				anim.SetBool("Grab", isHanging);
				isGrounded = true;
				startAerialMovement = Vector3.zero;
				rb.velocity = new Vector3(0, jumpForce/1.5f, 1f);
				rb.useGravity = true;
			}
			if (Vector3.Dot(move, transform.forward) < -0.7f && jump) {
				isHanging = false;
				anim.SetBool ("Grab", isHanging);
				startAerialMovement = Vector3.zero;
				anim.applyRootMotion = true;
				rb.useGravity = true;
			}
		}
	}

	void UpdateAnimator (Vector3 move)
	{
		// update the hanging state
		anim.SetBool ("Grab", isHanging);
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
		float runCycle = Mathf.Repeat (anim.GetCurrentAnimatorStateInfo (0).normalizedTime + m_RunCycleLegOffset, 1);
		float jumpLeg = (runCycle < k_Half ? 1 : -1) * move.z;
		if (isGrounded) {
			anim.SetFloat ("JumpLeg", jumpLeg);
		}
		
		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (isGrounded) {
			anim.speed = animSpeedModifier;
		} else {
			if (move.magnitude > 0f && !hasWallJumped) {

				Vector3 temp = (move * startAerialMovementSpeed).normalized;

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
			isHanging = false;
			startAerialMovement = Vector3.zero;
			hasWallJumped = false;
			anim.applyRootMotion = true;
			rb.useGravity = true;
			anim.SetBool ("Grab", isHanging);

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

	IEnumerator WaitForWallSlide(){
		yield return new WaitForSeconds (0.4f);
		if (!isHanging) {
			isWaitingToSlide = false;
		} else {
			isWallsliding = false;
		}
	}

	void OnCollisionEnter(Collision col){
		contacts = col.contacts;
		if (contacts [0].normal.y < -0.05f || contacts [0].normal.y < 0.05f) {
			if (Vector3.Dot (currentMove.normalized, contacts [0].normal) < -0.2f) {
				isWallsliding = true;
				isWaitingToSlide = true;
				StartCoroutine (WaitForWallSlide());
				transform.LookAt (transform.position - new Vector3 (contacts [0].normal.x, 0, contacts [0].normal.z));
			}
		}
	}

	private ContactPoint[] contacts = new ContactPoint[0];

	void OnDrawGizmos(){
		for(int i = 0; i < contacts.Length; i++){
			if (contacts.Length > 0) {
				Gizmos.DrawWireSphere (contacts [i].point, 0.5f);
				Gizmos.DrawLine (contacts [i].point, contacts [i].point + contacts [i].normal);
			}
		}
	}
}
