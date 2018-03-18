using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThenderHide : MonoBehaviour {
	public GameObject thender;
	public GameObject thender1;
	public GameObject thender2;
	public GameObject thender3;
	public GameObject thender4;
	public GameObject thender5;
	public GameObject thender6;
	public GameObject thender7;
	public GameObject thender8;
	public GameObject grass0;

	private int scorebug;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void diseble()
	{
		float timer = 0f;
				timer += Time.deltaTime;    


		if (timer>=2||grass0==null) {

			thender.SetActive (false);//to disable thinder
		

		}
	}
}
