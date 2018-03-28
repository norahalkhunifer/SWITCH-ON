using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThenderHide : MonoBehaviour {
	public GameObject bug0;
	public GameObject bug1;
	public GameObject bug2;
	public GameObject bug3;
	public GameObject bug4;
	public GameObject bug5;
	public GameObject bug6;
	public GameObject bug7;
	public ThenderDisable thender;


	public void bugDis(GameObject obj){
		if (bug0.name == obj.name) {
			Debug.Log (thender.score);

			bug0.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug1.name == obj.name) {
			Debug.Log (thender.score);

			bug1.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug2.name == obj.name) {
			Debug.Log (thender.score);

			bug2.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug3.name == obj.name) {
			Debug.Log (thender.score);

			bug3.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug4.name == obj.name) {
			Debug.Log (thender.score);

			bug4.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug5.name == obj.name) {
			Debug.Log (thender.score);

			bug5.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}

		if (bug6.name == obj.name) {
			Debug.Log (thender.score);

			bug6.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
		if (bug7.name == obj.name) {
			Debug.Log (thender.score);

			bug7.SetActive (false);//to disable thinder
			if (thender.score > 0) {
				thender.score = thender.score - 1;
			}
			Debug.Log (thender.score);
			if (thender.score > 6) {
				thender.scordis1.SetActive (false);
				thender.scordis.SetActive (true);
				thender.scoreText2.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			} else {
				thender.scordis.SetActive (false);
				thender.scordis1.SetActive (true);
				thender.scoreText.text = thender.score.ToString ();
				thender.finalScore.text = thender.score.ToString ();
				thender.scoreTextWin.text = thender.score.ToString ();
			}
		}
	}
}
