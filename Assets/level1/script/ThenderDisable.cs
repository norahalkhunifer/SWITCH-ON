using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public int num=0;
	public AccelerationControlScript grass;
	public ThenderDisable script;
	public BattryChange battryHide;
	public BattryShow jump;
	public GameObject gameWin;
	public GameObject back;
	public TimeText timer;
	public Text topScore;
	public Text finalScore;
	public Text scoreText;
	public Text scoreText2;
	public Text scoreTextWin;
	public Resume_Paused resume;
	public instruction instruc;
	public Color newColor;
	public Color oldColor;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject scordis;
	public GameObject scordis1;
	public GameObject grass17;
	public GameObject gameOver;
	public Button resumeButton;
	public Scene scene;
public LevelManger levelmanger;
	public int level;
	public int score=0;

	public AudioSource Endwin,Endlose,background;

	void Start(){
	//	Debug.Log (level);
		gameWin.SetActive (false);
		back.SetActive (false);
		scoreText.text = score.ToString ();
		finalScore.text=score.ToString();
		scoreTextWin.text=score.ToString();
		text1.SetActive (false);
		text2.SetActive (false);
		text3.SetActive (false);
		scordis.SetActive (false);


	}
	void Update(){
		if (!grass17.activeInHierarchy&&score>=6&&!thender8.activeInHierarchy) {
			timer.enabled= false;
			instruc.enabled = false;
			finalScore.text=score.ToString();
			scoreTextWin.text=score.ToString();
			gameWin.SetActive (true);
			background.Stop ();
			Endwin.Play ();
			back.SetActive (true);
			script.enabled = false;
			grass.enabled = false;
			battryHide.enabled = false;
			jump.enabled = false;
			resume.enabled = false;
			string winT=timer.finalTimerWin.text;
			levelmanger.win (level,score , winT);
			topScore.text=levelmanger.getTopScore (level).ToString();
			Debug.Log (topScore);

			resumeButton.interactable = false;


		}
		if (!grass17.activeInHierarchy && score < 6&&!thender8.activeInHierarchy) {
			gameOver.SetActive (true);
			background.Stop ();
			Endlose.Play ();
			back.SetActive (true);
			timer.chare.SetActive (false);
			resume.enabled = false;
			grass.enabled = false;
			battryHide.enabled = false;
			jump.enabled = false;
			timer.usingT = false;
			timer.enabled = false;
			resumeButton.interactable = false;

		}
	}
	public void diseble(GameObject obj)
	{

		if (thender.name == obj.name ) {
				Debug.Log (score);
				Debug.Log (thender.name == obj.name);
				thender.SetActive (false);//to disable thinder
				score = score + 1;
				Debug.Log (score);
				scoreText.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();

			
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
			if (score > 6) {
				scordis1.SetActive (false);
				scordis.SetActive (true);
				StartCoroutine (disable (num));
				text1.SetActive (true);
				scoreText2.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
			} else {
				scoreText.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
				scordis.SetActive (false);
				scordis1.SetActive (true);

			}

		}

		if ( thender7.name==obj.name) {
			Debug.Log (score);
			thender7.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			if (score > 6) {
				scordis1.SetActive (false);
				scordis.SetActive (true);
				StartCoroutine (disable (num));
				text2.SetActive (true);
				scoreText2.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
			} else {
				scoreText.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
				scordis.SetActive (false);
				scordis1.SetActive (true);

			}

		}

		if ( thender8.name==obj.name) {
			Debug.Log (score);
			thender8.SetActive (false);//to disable thinder
			score = score + 1;
			Debug.Log (score);
			if (score > 6) {
				scordis1.SetActive (false);
				scordis.SetActive (true);
				StartCoroutine (disable (num));
				text3.SetActive (true);
				scoreText2.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
			} else {
				scordis.SetActive (false);
				scordis1.SetActive (true);
				scoreText.text = score.ToString ();
				finalScore.text = score.ToString ();
				scoreTextWin.text = score.ToString ();
			}

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
			string winT=timer.finalTimerWin.text;
			// scene = SceneManager.

			levelmanger.win (level,score , winT);
			topScore.text=levelmanger.getTopScore (level).ToString();
			Debug.Log (topScore);

			resumeButton.interactable = false;

		}
		if (!grass17.activeInHierarchy&&score>=6&&!thender8.activeInHierarchy) {
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
			string winT=timer.finalTimerWin.text;
			levelmanger.win (level,score , winT);
			topScore.text=levelmanger.getTopScore (level).ToString();
			Debug.Log (topScore);
			resumeButton.interactable = false;


		}
		if (!grass17.activeInHierarchy && score < 6&&!thender8.activeInHierarchy) {
			gameOver.SetActive (true);
			back.SetActive (true);
			timer.chare.SetActive (false);
			resume.enabled = false;
			grass.enabled = false;
			battryHide.enabled = false;
			jump.enabled = false;
			timer.usingT = false;
			timer.enabled = false;
			resumeButton.interactable = false;

		}

	
	}
	IEnumerator disable (int num)
	{
		yield return new WaitForSeconds (2f);
		if (num == 0 && !thender6.activeInHierarchy) {
			text1.SetActive (false);
			num = 1;
		}
		yield return new WaitForSeconds (2f);
		if (num == 1 && !thender7.activeInHierarchy) {
			text2.SetActive (false);
		}
		yield return new WaitForSeconds (2f);
		if (num == 2 && !thender8.activeInHierarchy) {
			text3.SetActive (false);
		}
	}
}



