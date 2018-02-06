using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingManger : MonoBehaviour {

	public void ContactUs()
	{
		string email = "renadalmalki2@gmail.com"; 
		string subject = MyEscapeURL ("SUGGESTION"); 
		string body = MyEscapeURL ("Please enter your message");

		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body); //open iphone mail 
	}

	string MyEscapeURL(string url){

		return WWW.EscapeURL (url).Replace ("+", "%20");
	}
	 }

