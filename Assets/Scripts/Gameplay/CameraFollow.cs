using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	/*
    This camera smoothes out rotation around the y-axis and height.
    Horizontal Distance to the target is always fixed.
     
    There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.
     
    For every of those smoothed values we calculate the wanted value and the current value.
    Then we smooth it using the Lerp function.
    Then we apply the smoothed values to the transform's position.
    */
	
	// The target we are following
	private Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we
	public float heightDamping = 2.0f;
	private float rotationDamping = 3.0f;

	private float rotation = 0.0f;
	public float sensitivity = 3.0f;

	public float verticaltalOffset;
	public float camHeightOffset;

	private bool isAutoTracking = false;

	private Transform[] players;

	// Place the script in the Camera-Control group in the component menu
	//@script AddComponentMenu("Camera-Control/Smooth Follow")
		
	void Awake(){
		GameObject tempGO = GameObject.FindGameObjectWithTag("Player");
		if (tempGO != null) {
			target = tempGO.transform;
		}
	}

	public void SetTrackingMode(bool isTrackingMultipleCharacters){

		if(!isAutoTracking && isTrackingMultipleCharacters){
			GameObject[] tempGOList = GameObject.FindGameObjectsWithTag("Player");
			players = new Transform[tempGOList.Length];

			int count = 0;

			foreach(GameObject g in tempGOList){
				players[count] = g.transform;
				count++;
			}
			Debug.Log(count);

		}
		isAutoTracking = isTrackingMultipleCharacters;
	}

	void LateUpdate () {
		if (isAutoTracking) {

			if(target == null){
				GameObject tempGO = GameObject.FindGameObjectWithTag("Player");
				if (tempGO != null) {
					target = tempGO.transform;
				}
			}else{
				float xMean = 0;

				for(int i = 0; i < players.Length; i++){
					xMean += (players[i].position.x - target.position.x);
				}

				xMean = xMean/players.Length;
				
				float zMean = 0;
				
				for(int i = 0; i < players.Length; i++){
					zMean += (players[i].position.z - target.position.z);
				}
				
				zMean = zMean/players.Length;

				float xzMean = 0;
				
				for(int i = 0; i < players.Length; i++){
					xzMean += ((players[i].position.x - target.position.x) * (players[i].position.z - target.position.z));
				}
				
				xzMean = xzMean/players.Length;
				
				float xPowMean = 0;
				
				for(int i = 0; i < players.Length; i++){
					xPowMean += Mathf.Pow(players[i].position.x - target.position.x,2);
				}
				
				xPowMean = xPowMean/players.Length;

				float slope = ((xMean*zMean) - xzMean)/((xMean*xMean - xPowMean));

				//z = slope*x + intersection

				if(Vector3.Distance(target.position + new Vector3(1,0,slope), transform.position) <= Vector3.Distance(target.position - new Vector3(1,0,slope), transform.position)){

					if(Vector3.Distance(target.position + new Vector3(1,0,slope), transform.position + transform.right) <= Vector3.Distance(target.position + new Vector3(1,0,slope), transform.position - transform.right)){
						rotation += sensitivity * 1f;
					}else{
						rotation -= sensitivity * 1f;
					}
				}else{
					if(Vector3.Distance(target.position - new Vector3(1,0,slope), transform.position + transform.right) <= Vector3.Distance(target.position - new Vector3(1,0,slope), transform.position - transform.right)){
						rotation += sensitivity * 1f;
					}else{
						rotation -= sensitivity * 1f;
					}
				}

				// Calculate the current rotation angles
				//float wantedRotationAngle = target.eulerAngles.y;
				float wantedRotationAngle = rotation;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = transform.eulerAngles.y;
				float currentHeight = transform.position.y;
				
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
				// Damp the height
				currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				// Convert the angle into a rotation
				Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
				
				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target
				transform.position = target.position;
				transform.position -= currentRotation * Vector3.forward * distance;
				
				// Set the height of the camera
				transform.position = new Vector3(transform.position.x, currentHeight /* + camHeightOffset*/, transform.position.z);
				
				// Always look at the target
				transform.LookAt (new Vector3(target.position.x, target.position.y + verticaltalOffset, target.position.z));

				/* This is for normal vector to the line
				if(slope >= 1){
					slope = (-1/slope);
				}else{
					slope = (slope/-1);
				}
	     			*/
			}
		}else{
			if (target == null) {
				GameObject tempGO = GameObject.FindGameObjectWithTag("Player");
				if (tempGO != null) {
					target = tempGO.transform;
				}
			}else{

				float tempInputAxisVal = Input.GetAxis ("HorizontalRight1");

				if(tempInputAxisVal > 0){
					rotation += sensitivity * tempInputAxisVal;
				}
				else if(tempInputAxisVal < 0){
					rotation -= sensitivity * -tempInputAxisVal;
				}

				// Calculate the current rotation angles
				//float wantedRotationAngle = target.eulerAngles.y;
				float wantedRotationAngle = rotation;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = transform.eulerAngles.y;
				float currentHeight = transform.position.y;
				
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

				// Damp the height
				currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				// Convert the angle into a rotation
				Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
				
				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target
				transform.position = target.position;
				transform.position -= currentRotation * Vector3.forward * distance;

				// Set the height of the camera
				transform.position = new Vector3(transform.position.x, currentHeight /* + camHeightOffset*/, transform.position.z);

				// Always look at the target
				transform.LookAt (new Vector3(target.position.x, target.position.y + verticaltalOffset, target.position.z));

			}
		}
		
	}
}
