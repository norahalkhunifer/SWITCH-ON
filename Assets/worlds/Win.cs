using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	void onTrigger( Collision2D col)
	{
		Level.instance.youWin ();
}
}
