using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon: MonoBehaviour {

	public AudioClip aC;
	public AudioSource Baudio;
	public GameObject balloon1;
	public GameObject balloon2;
	public GameObject balloon3;
	public GameObject balloon4;
	public GameObject balloon5;
	public GameObject balloon6;
	public GameObject balloon7;
	public GameObject balloon8;
	public GameObject balloon9;
	public GameObject balloon10;

	public int NO1=0;
	public int NO2=0;
	public int NO3=0;
	public int NO4=0;
	public int NO5=0;
	public int NO6=0;
	public int NO7=0;
	public int NO8=0;
	public int NO9=0;
	public int NO10=0;

	public GameObject Particle1;
	public GameObject Particle2;
	public GameObject Particle3;
	public GameObject Particle4;
	public GameObject Particle5;


	//public GameObject thunder;
	//public GameObject score;
	void Start(){

	}

	// Update is called once per frame
	void Update () {
		
	}

	//set no. of hits(toutch) on that obj
	public void setNo(GameObject obj){
		
		if (obj.CompareTag ("B1")) {
			NO1++;
		}
		 if (obj.CompareTag ("B2")) {
			NO2++;
		}
		 if (obj.CompareTag ("B3")) {
			NO3++;
		}
		if (obj.CompareTag ("B4")) {
			NO4++;
		}
		if (obj.CompareTag ("B5")) {
			NO5++;
		}
		if (obj.CompareTag ("B6")) {
			NO6++;
		}
		if (obj.CompareTag ("B7")) {
			NO7++;
		}
		if (obj.CompareTag ("B8")) {
			NO8++;
		}
		if (obj.CompareTag ("B9")) {
			NO9++;
		}
		if (obj.CompareTag ("B10")) {
			NO10++;
		}
	}

	//get no. of hits on that object
	public int getNo(GameObject obj){
		int NO=0;

		if (obj.CompareTag ("B1")) {
			NO = NO1;
		}
		 if (obj.CompareTag ("B2")) {
			NO = NO2;
		}
		 if (obj.CompareTag ("B3")) {
			NO = NO3;
		}
		if (obj.CompareTag ("B4")) {
			NO = NO4;
		}
		if (obj.CompareTag ("B5")) {
			NO = NO5;
		}
		if (obj.CompareTag ("B6")) {
			NO = NO6;
		}
		if (obj.CompareTag ("B7")) {
			NO = NO7;
		}
		if (obj.CompareTag ("B8")) {
			NO = NO8;
		}
		if (obj.CompareTag ("B9")) {
			NO = NO9;
		}
		if (obj.CompareTag ("B10")) {
			NO = NO10;
		}
		return NO;
	}


	public void changePos(){

		transform.position = new Vector3 (transform.position.x, transform.position.y, (transform.position.z - 2));
	}


	public void showParticle(GameObject obj){
		
		if (obj.CompareTag("B1") ){
			print ("showParticle");
			ForkParticlePlugin.Instance.Test();
		}
		if (obj.CompareTag("B2") ){
			print ("showParticle");
			ForkParticlePlugin.Instance.Test();
		}

		if (obj.CompareTag("B3") ){
			print ("showParticle");
				ForkParticlePlugin.Instance.Test();
		}
		if (obj.CompareTag("B4") ){
			print ("showParticle");
			ForkParticlePlugin.Instance.Test();
		}
	}

	public void playSound(){

		Baudio.clip = aC;
		Baudio.Play ();
	}

	/*public void disappear(GameObject go){
		
		if ( balloon.name==go.name) {
			Debug.Log (score);
			balloon.SetActive (false);//to disable balloon
		   // thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}*/
	}


	

