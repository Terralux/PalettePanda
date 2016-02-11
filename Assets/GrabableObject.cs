using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabableObject : MonoBehaviour {

	public bool enable = false;
	public bool recalculate = false;
	private List<Vector3> grabableLedge = new List<Vector3>();

	void OnDrawGizmos(){
		if (enable && Application.isEditor) {

			Gizmos.color = Color.red;

			if (grabableLedge.Count >= 2 && !recalculate) {

				for (int i = 0; i < grabableLedge.Count - 1; i++) {
					Gizmos.DrawLine (grabableLedge [i], grabableLedge [i + 1]);
				}

				Gizmos.DrawLine (grabableLedge [grabableLedge.Count - 1], grabableLedge [0]);

			} else {
				grabableLedge = new List<Vector3> ();
				Transform[] temp = GetComponentsInChildren<Transform> ();

				foreach (Transform t in temp) {
					if(t != transform){
						grabableLedge.Add (t.position);
					}
				}
				recalculate = false;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			Debug.Log("Should Grab here!");
		}
	}

}
