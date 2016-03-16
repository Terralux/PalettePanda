using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabableObject : MonoBehaviour {

	public bool enable = false;
	public bool recalculate = false;
	private List<Vector3> grabableLedge = new List<Vector3>();

	void Awake(){
		Transform[] temp = GetComponentsInChildren<Transform> ();

		foreach (Transform t in temp) {
			if(t != transform){
				grabableLedge.Add(t.position);
			}
		}
	}

	public Vector3 GetClosestGrabablePosition(Vector3 playerPosition){

		int firstIndex = 1;
		int secondIndex = 0;

		for (int i = 2; i < grabableLedge.Count - 1; i++) {
			float distance = Vector3.Distance(grabableLedge[i], playerPosition);

			if(distance < Vector3.Distance(grabableLedge[firstIndex], playerPosition)){
				if(Vector3.Distance(grabableLedge[firstIndex], playerPosition) < Vector3.Distance(grabableLedge[secondIndex], playerPosition)){
					secondIndex = i;
				}else{
					firstIndex = i;
				}
			}else{
				if(distance < Vector3.Distance(grabableLedge[secondIndex], playerPosition)){
					secondIndex = i;
				}
			}
		}

		Vector3 target = Vector3.zero;

		return target;
	}

}
