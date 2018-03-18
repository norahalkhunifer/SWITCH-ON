using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour {
	public GameObject bug0;
	public GameObject bug1;
	public GameObject bug2;
	public GameObject bug3;
	public GameObject bug4;
	public GameObject bug5;
	public ThenderDisable scoreTh;
	private int scorebug;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void diseble(GameObject obj)
	{
		//

		if (bug0.name == obj.name) {
			Debug.Log (scoreTh);
			Debug.Log (bug0.name == obj.name);
			bug0.SetActive (false);//to disable thinder
			//score = score + 1;
			scorebug=scoreTh.score;
			scoreTh.score = scorebug - 1;
			Debug.Log (scorebug);
//
//			scoreText.text = score.ToString ();
//			finalScore.text = score.ToString ();
//			scoreTextWin.text = score.ToString ();

		}
	}
}
