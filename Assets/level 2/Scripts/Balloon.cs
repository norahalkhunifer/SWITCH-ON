using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon: MonoBehaviour {

	public AudioClip aC;
	public AudioSource Baudio;


	public GameObject balloon;
	/*public GameObject balloon2;
	public GameObject balloon3;
	public GameObject balloon4;
	public GameObject balloon5;
	public GameObject balloon6;
	public GameObject balloon7;
	public GameObject balloon8;
	public GameObject balloon9;
	public GameObject balloon10;*/

	 //GameObject object1=null;
	bool t1=false;


	private int NO=0;
	/*private int NO2=0;
	private int NO3=0;
	private int NO4=0;
	private int NO5=0;
	private int NO6=0;
	private int NO7=0;
	private int NO8=0;
	private int NO9=0;
	private int NO10=0;*/

	private int[] randomNO = new int[]{2,3,4,-2,-3,-4};
	int i=0;
	Vector3 v;
	private Vector3 startPos;
	private Vector3 endPos;
	private float dis = 5f;
	private float lerpt = 1;
	private float currentt=0;

	public Camera player;
	public Material blink_material, normal_material;

	//public GameObject thunder;
	//public GameObject score;
	void Start(){
		
	}

	// Update is called once per frame
	void Update () {
		
		/*if(t1==true)
		startLerp ();*/

		if (Vector3.Distance (transform.position, player.transform.position) < 2f) {
			Blinking ();
		}
		else 
			StopBlinking ();
	}

	/*public void startLerp(){
		print ("lerp");
		currentt += Time.deltaTime;
		if (currentt > lerpt)
			currentt = lerpt;

		float t = currentt / lerpt;

		balloon.transform.position = Vector3.Lerp (startPos, endPos, t);

	}*/

	//set no. of hits(toutch) on that obj
	public void setNo(){
		t1 = false;
		NO++;
	}
		/*if (obj.CompareTag ("B2")) {
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
		}*/
	

	
	

	//get no. of hits on that object
	public int getNo(){
		t1 = false;
		return NO;
	}

		/*if (obj.CompareTag ("B2")) {
			NO = NO2;
			print ("NO2"+NO);

		}
		if (obj.CompareTag ("B3")) {
			NO = NO3;
			print ("NO3"+NO);

		}
		if (obj.CompareTag ("B4")) {
			NO = NO4;
			print ("NO4"+NO);

		}
		if (obj.CompareTag ("B5")) {
			NO = NO5;
			print ("NO5"+NO);

		}
		if (obj.CompareTag ("B6")) {
			NO = NO6;
			print ("NO6"+NO);

		}
		if (obj.CompareTag ("B7")) {
			NO = NO7;
			print ("NO7"+NO);

		}
		if (obj.CompareTag ("B8")) {
			NO = NO8;
			print ("NO8"+NO);

		}*/
	
	

	



	public void changePos(){
		
		t1 = true;
		//object1 = obj;
		//startPos = balloon.transform.position;
		//print ("change pos");

		//v = new Vector3 ((transform.position.x + randomNO [i]), transform.position.y, transform.position.z);


		//endPos = balloon.transform.position + v * dis;

		transform.position = new Vector3 ((transform.position.x+randomNO [i]), transform.position.y,( transform.position.z) );

		i++;
		if (i == 5)//to prevent out of boud
			i = 0;
	}



	public void showParticle(GameObject obj){
		t1 = false;
		print ("show particle");
		ForkParticlePlugin.Instance.Test(obj);

	}

	public void playSound1(){

		t1 = false;
		print ("play sounds");
		Baudio.clip = aC;
		Baudio.Play ();
	}

	void Blinking ()
	{
		balloon.transform.GetChild (0).gameObject.GetComponent<Renderer>().material=blink_material;
	
		//Invoke("StopBlinking",3f);
	}
	void StopBlinking ()
	{
		balloon.transform.GetChild (0).gameObject.GetComponent<Renderer>().material=normal_material;


	}

}




