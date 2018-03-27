using System.Collections;
using System;
using UnityEngine;

public class DistanceCompare : IComparer {

	private Transform player;

	// Use this for initialization
	public DistanceCompare(Transform p){
		player = p;
	}

	public int Compare (object x,object y) {
		Collider xcoll = x as Collider;
		Collider ycoll = y as Collider;

		Vector3 offset = xcoll.transform.position - player.position;
		float xdis = offset.sqrMagnitude;

		offset = ycoll.transform.position - player.position;
		float ydis = offset.sqrMagnitude;
		return xdis.CompareTo (ydis);
	}
	

}
