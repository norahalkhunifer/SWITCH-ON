using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingManger : MonoBehaviour {

	public void ContactUs()
	{
		string email = "renadalmalki2@gmail.com"; 
		string title = GoURL ("FEEDBACK"); 
		string msg = GoURL ("Please enter your message");

		Application.OpenURL ("mailto:" + email + "?subject=" + title + "&body=" + msg); //open iphone mail 
	}

	string GoURL(string url){

		return WWW.EscapeURL (url).Replace ("+", "%20");
	}
	 }

