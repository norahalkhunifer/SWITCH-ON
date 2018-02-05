using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour {

	void onTrigger( Collision2D col)
	{
		Level.instance.youLose ();
	}
}