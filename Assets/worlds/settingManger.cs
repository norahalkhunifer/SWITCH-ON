using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingManger : MonoBehaviour {

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
	 }

