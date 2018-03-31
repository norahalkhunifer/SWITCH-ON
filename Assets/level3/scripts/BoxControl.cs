using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[RequireComponent (typeof(AudioSource))]
public class BoxControl: MonoBehaviour
{
	//animating box +blinking
	private Animation opining;
	AudioSource boxAudio;
	private bool isopen = false;
	//public bool blinking=false;
	public static Ray ray;
	//Renderer rend;
	public Material blink_material, normal_material;
    //this will be the ray that we cast from our touch into the scene
	private static level3manger levelmanger;
	public int boxnum;
	//to get des 
	public Camera player;
    //each box have uniqe num
	public GameObject insaideobj;
	//for learping 
	private float speed = 0.7f;
	private float startTime;
	private float journeyLength;
	// Use this for initialization
	//Awake
	void Start ()
	{
		opining = GetComponent<Animation> ();
		levelmanger = GameObject.Find("manger").GetComponent<level3manger> ();
		boxAudio = GetComponent<AudioSource> ();
		startTime = Time.time;
		journeyLength = Vector3.Distance (insaideobj.transform.position, new Vector3 (insaideobj.transform.position.x, insaideobj.transform.position.y + 0.3f, insaideobj.transform.position.z));
		//blink_material=	GetComponent<Renderer>().material;
		normal_material=GetComponent<Renderer>().material;

	}
	// Update is called once per frame
	void Update ()
	{
		if(isopen)//Vector3.Distance(transform.position, player.transform.position)<0.5f && (isopen))
			hideIt (true);
		else
			hideIt (false);
		
		if (Vector3.Distance(transform.position, player.transform.position)<3f)
			Blinking ();
		else {
			StopBlinking ();
		}
	}

	public void openit ()
	{
		//animation.CrossFade ("walk");
		opining.Play ("box_open");
		isopen = true;
		boxAudio.Play ();
		//	insaideobj.transform.position = new Vector3 ();
		changepos (1);
		levelmanger.CheckBoxes (this);
	}

	public void closeit ()
	{
		changepos (-1);
		opining.Play ("box_close");
		boxAudio.Play ();
		isopen = false;
	}

	public void mached ()
	{
		Destroy (insaideobj);
		transform.GetChild(1).gameObject.SetActive(false);
		//transform.Find("Directional light").active = false;
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
	public void ActivateIt (bool active)
	{
		levelmanger.setDebugText ("close to "+boxnum);
		//blinking = active;

	}
	 void Blinking ()
	{
		//blink_material.SetFloat ("_MKGlowTexStrength",10f);
		//blink_material.SetFloat ("_MKGlowPower",5f);
		GetComponent<Renderer>().material=blink_material;
		//thisRend.material.SetColor("_Color", Color.Lerp(thisRend.material.color, newColor, Time.deltaTime * transitionRate));
		//_MKGlowTexStrength
		//_MKGlowPower
		//Invoke("StopBlinking",2f);
	}
	void StopBlinking ()
	{
		GetComponent<Renderer>().material=normal_material;

		//blink_material.SetFloat ("_MKGlowTexStrength",0f);
	//	blink_material.SetFloat ("_MKGlowPower",0f);

	}
	/*public Shader shader1;
	public Shader shader2;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
		shader1 = Shader.Find("Diffuse");
		shader2 = Shader.Find("Transparent/Diffuse");
	}
	void Update() {
		if (Input.GetButtonDown("Jump"))
		if (rend.material.shader == shader1)
			rend.material.shader = shader2;
		else
			rend.material.shader = shader1;

	}*/
	public void hideIt (bool hide)
	{
		insaideobj.SetActive (hide);
	}
}
