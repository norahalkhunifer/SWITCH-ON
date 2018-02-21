using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
[RequireComponent(typeof(AudioSource))]
public class BoxControl: MonoBehaviour {

	private Animation opining;
	private bool isopen=false;
	public static Ray ray;//this will be the ray that we cast from our touch into the scene
	private static level3manger levelmanger; 
	public int boxnum;//each box have uniqe num
	public bool testit=false;

	// Use this for initialization
	//Awake
	void Start () {

		opining = GetComponent<Animation>();
		levelmanger = GetComponent<level3manger>();

	}
		
	// Update is called once per frame
	void Update () {
		if (testit)
			openit ();
		
	}
	public void openit(){
		//animation.CrossFade ("walk");
			opining.Play ("box_open");
		    isopen = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		levelmanger.CheckBoxes(this);

	}
	public void closeit(/* box number !*/){
		opining.Play ("box_close");
		//opining.Stop ();
		isopen = false;

	}
	public void mached(){
		//if get the cads match it 

	}


	public bool isOpen(){
		return isopen;
	}
	public void setbumb(){
	//StartCoroutine("Bumb");
}
	IEnumerator Bumb(){
	yield return new WaitForSeconds(.5f);
	//Destroy(gameObject);
}
}
