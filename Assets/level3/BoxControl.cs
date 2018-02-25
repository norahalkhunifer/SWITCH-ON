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
	public float speed = 0.7F;
	private float startTime;
	private float journeyLength;
	// Use this for initialization
	//Awake
	void Start ()
	{

		opining = GetComponent<Animation> ();
		//GameObject.Find("manger");
		levelmanger = GameObject.Find("manger").GetComponent<level3manger> ();
		startTime = Time.time;
		journeyLength = Vector3.Distance (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.03f, insaideobj.transform.position.z));
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
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
		//	insaideobj.transform.position = new Vector3 ();
		changepos (1);
		levelmanger.CheckBoxes (this);
	}

	public void closeit (/* box number !*/)
	{
		changepos (-1);
		opining.Play ("box_close");
		//opining.Stop ();
		isopen = false;
	}

	public void mached ()
	{
		print ("matchyaay");
		Destroy (insaideobj);
		//if get the cads match it 
	}

	private void changepos (int upordown)
	{//1for up -1 for down 
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		switch (upordown) {
		case 1:
			insaideobj.transform.position = Vector3.Lerp (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.01f, insaideobj.transform.position.z), fracJourney);
			//pMenu.transform.position = Vector3.Lerp(pMenu.transform.position, endPosition, speed * Time.deltaTime); 
			break;
		case -1:
			insaideobj.transform.position = Vector3.Lerp (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y - 0.01f, insaideobj.transform.position.z), fracJourney);
			break;
		}
	}

	public bool isOpen ()
	{
		return isopen;
	}

	public void setbumb ()
	{
		//StartCoroutine("Bumb");
	}

	IEnumerator Bumb ()
	{
		yield return new WaitForSeconds (.5f);
		//Destroy(gameObject);
	}
}
