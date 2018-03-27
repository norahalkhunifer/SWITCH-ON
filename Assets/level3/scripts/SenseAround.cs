using UnityEngine;
using System.Collections;
using System;
public class SenseAround : MonoBehaviour
{

	public float checkRadius;
	public LayerMask checklayer;
	private void onDrawGizmos() {
		Gizmos.DrawSphere (transform.position, checkRadius);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Collider[] coll = Physics.OverlapSphere (transform.position, checkRadius, checklayer);
		Array.Sort (coll, new DistanceCompare (transform));
		foreach (Collider box in coll) {
			Debug.Log (box.name);
			box.GetComponent<BoxControl>().ActivateIt();
		}
	}
}

