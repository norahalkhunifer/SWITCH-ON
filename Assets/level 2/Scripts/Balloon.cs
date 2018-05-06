using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon: MonoBehaviour {

	public AudioClip aC;
	public AudioSource Baudio;


	public GameObject balloon;


	 //GameObject object1=null;
	bool t1=false;


	private int NO=0;

	private int[] randomNO = new int[]{3,4,5,-6,-4,-5};
	int i=0;
	Vector3 v;
	private Vector3 startPos;
	private Vector3 endPos;
	private float dis = 5f;
	private float lerpt = 1;
	private float currentt=0;

	public Camera player;
	public Material blink_material, normal_material;
	public GameObject effect;


	void Start(){
		
	}

	// Update is called once per frame
	void Update () {
		
		/*if(t1==true)
		startLerp ();*/

		if (Vector3.Distance (transform.position, player.transform.position) < 3f) {
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
		

	
	

	//get no. of hits on that object
	public int getNo(){
		t1 = false;
		return NO;
	}
		//change pos of object
	public void changePos(){
		
		t1 = true;
		//object1 = obj;
		//startPos = balloon.transform.position;
		//print ("change pos");

		//v = new Vector3 ((transform.position.x + randomNO [i]), transform.position.y, transform.position.z);


		//endPos = balloon.transform.position + v * dis;

		transform.position = new Vector3 ((transform.position.x+randomNO [i]), transform.position.y,( transform.position.z) );
		effect.transform.position=new Vector3 ((transform.position.x+randomNO [i]), transform.position.y,( transform.position.z) );

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
	//assign normal matiral 
public void setMatiral(Material m){
		normal_material = m;
		//blink_material=
	}

	//convert matiral to string
	public string getSNo(Material m){
		//print (m.name+"material name");
		//print (m.name.Replace("(Instance)","")+"material name after replace ");
		return	(m.name.Replace("(Instance)",""));


	}
}




