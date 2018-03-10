﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingManger : MonoBehaviour {
	public GameObject charcter1, charcter2, help, skip;
	public Button RedChar, BlueChar;
	 WorldManager manger;
	public Image closed, start;
	GameObject text1, text2;

	public void Start(){
		manger= GameObject.Find("worlds manger").GetComponent<WorldManager> ();


	}
	public void ContactUs()
	{
		string email = "renadalmalki2@gmail.com"; 
		string title = emailURL ("FEEDBACK"); 
		string msg = emailURL ("Please enter your message");

		Application.OpenURL ("mailto:" + email + "?subject=" + title + "&body=" + msg); //open iphone mail 
	}

	string emailURL(string url){

		return WWW.EscapeURL (url).Replace ("+", "%20");
	}
	public void swapToBlue(){

		charcter1.SetActive (true);
		charcter2.SetActive (false);
		setCape ("Blue");

	}

	//method to change blue cape to red
	public void swapToRed(){

		charcter2.SetActive (true);
		charcter1.SetActive (false);
		setCape ("Red");


	}
	private void setCape(string color){
		PlayerPrefs.SetString("CapeColor",color);

	}
	public void getCapeColor(){
		string color =PlayerPrefs.GetString("CapeColor");
		if (color == "Blue")
			swapToBlue ();
		else if (color == "Red")
			swapToRed ();

	}
	public void showinst(Animator anim){
		manger.closesettings (anim);

		StartCoroutine (ShowInstruction (true, 0f));
		StartCoroutine (ShowInstruction (false, 10f));
	}

	IEnumerator ShowInstruction(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);


		help.SetActive (show); 

		skip.SetActive (true);
		closed.enabled = false;
		start.enabled = false;

		text1 = GameObject.Find ("Text1");
		text1.GetComponent<Text>().enabled = false;

		text2 = GameObject.Find ("Text2");
		text2.GetComponent<Text>().enabled = false;


	
	}

	public void closeInstruction()
	{

		help.SetActive (false);
}

}

