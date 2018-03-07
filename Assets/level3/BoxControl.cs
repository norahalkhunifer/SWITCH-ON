using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent (typeof(AudioSource))]
public class BoxControl: MonoBehaviour
{
	private Animation opining;
	private bool isopen = false;
	public static Ray ray;
//this will be the ray that we cast from our touch into the scene
	private static level3manger levelmanger;
	public int boxnum;
//each box have uniqe num
	public GameObject insaideobj;
	private float speed = 0.7f;
	private float startTime;
	private float journeyLength;
	AudioSource audio;
	// Use this for initialization
	//Awake
	void Start ()
	{
		opining = GetComponent<Animation> ();
		levelmanger = GameObject.Find("manger").GetComponent<level3manger> ();
	    audio = GetComponent<AudioSource> ();
		startTime = Time.time;
		journeyLength = Vector3.Distance (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.3f, insaideobj.transform.position.z));

	}
	// Update is called once per frame
	void Update ()
	{
	}

	public void openit ()
	{
		//animation.CrossFade ("walk");
		opining.Play ("box_open");
		isopen = true;
		audio.Play ();
		//	insaideobj.transform.position = new Vector3 ();
		changepos (1);
		levelmanger.CheckBoxes (this);
	}

	public void closeit ()
	{
		changepos (-1);
		opining.Play ("box_close");
		audio.Play ();
		isopen = false;
	}

	public void mached ()
	{
		Destroy (insaideobj);
		//closeit ();
	}

	private void changepos (int upordown)
	{//1for up -1 for down 
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		switch (upordown) {
		case 1:
			insaideobj.transform.position = Vector3.Lerp (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.3f, insaideobj.transform.position.z), fracJourney);
			//insaideobj.transform.position = Vector3.Lerp (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.5f, insaideobj.transform.position.z), speed * Time.deltaTime); 
			break;
		case -1:
			insaideobj.transform.position = Vector3.Lerp (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y - 0.3f, insaideobj.transform.position.z), fracJourney);
			break;
		}
	}

	public bool isOpen ()
	{
		return isopen;
	}

}
