using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThenderDisable : MonoBehaviour {
	public GameObject thender;
	public GameObject thender1;
	public GameObject thender2;
	public GameObject thender3;
	public GameObject thender4;
	public GameObject thender5;
	public GameObject thender6;
	public GameObject thender7;
	public GameObject thender8;
	public AccelerationControlScript grass;
	public ThenderDisable script;
	public BattryChange battryHide;
	public BattryShow jump;
	public GameObject gameWin;
	public GameObject back;
	public TimeText timer;
	//public GameObject finalTimerWin;

	public Text finalScore;
	public Text scoreText;
	public Text scoreTextWin;
	public Resume_Paused resume;
	public instruction instruc;
	private LevelManger levelmanger;

	private int score=0;


	void Start(){
		gameWin.SetActive (false);
		back.SetActive (false);
		scoreText.text = score.ToString ();
		finalScore.text=score.ToString();
		scoreTextWin.text=score.ToString();

	}

	public void diseble(GameObject obj)
	{
		//

		if (thender.name==obj.name) {
			Debug.Log (score);
			Debug.Log (thender.name == obj.name);
			thender.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}



		if ( thender1.name==obj.name) {
			Debug.Log (score);

			thender1.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}

		if ( thender2.name==obj.name) {
			Debug.Log (score);

			thender2.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}


		if ( thender3.name==obj.name) {
			Debug.Log (score);

			thender3.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}

		if ( thender4.name==obj.name) {
			Debug.Log (score);

			thender4.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}


		if ( thender5.name==obj.name) {
			Debug.Log (score);

			thender5.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}

		if ( thender6.name==obj.name) {
			Debug.Log (score);

			thender6.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}

		if ( thender7.name==obj.name) {
			Debug.Log (score);

			thender7.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}

		if ( thender8.name==obj.name) {
			Debug.Log (score);

			thender8.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			scoreText.text = score.ToString ();
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();

		}
		if (score == 9) {

			timer.enabled= false;
			instruc.enabled = false;
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();
			gameWin.SetActive (true);
			back.SetActive (true);
			script.enabled = false;
			grass.enabled = false;
			battryHide.enabled = false;
			jump.enabled = false;
			resume.enabled = false;
			timer.finalTimerWin.ToString ();

			levelmanger.win (1,score , timer.finalTimerWin.ToString () );

			//	timer.finalTimerWin.ToString ();
		}	
	}
}



