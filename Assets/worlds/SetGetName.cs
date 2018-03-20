﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGetName : MonoBehaviour {
	float timer = 0f;
	public InputField nameFeild;
	public InputField changeNameFeild;

	public Text dispname;
	public Text dispname2;

	public GameObject nameDialouge;
	public GameObject welcomeDialouge;
	public GameObject welcomeBack;
	public GameObject instruction;
	public WorldManager worldObject;
	public bool welcombbool=false; 



	public GameObject rightIcon;

	//static bool firsttime;

	private string[] names = new string[] { "Peter", "Ron", "Satchmo", "Iron-Cut", "Titanium", "Lightning", "Kevlar", "Rex", "Falcon", "Switch on player" };




	public void changeName() {
		
		//check if the user click change without writing anythings 

		if (changeNameFeild.text == "") {


		} else {
			SetUsername (changeNameFeild.text);
			//to save the written name into playerprefs
			PlayerPrefs.Save ();
			//to display user in the next welcome dialouge 
			dispname.text = changeNameFeild.text;

			//right icon timer 
			StartCoroutine (ShowRight (true, 0f));
			StartCoroutine (ShowRight (false, 2f));
		}
	}


	IEnumerator ShowRight(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);
		rightIcon.SetActive(show); 
	}


	public void setget () {
		if (nameFeild.text == "") {
			randomName ();
		}
		//to save the written name into playerprefs
		else {
			SetUsername (nameFeild.text);
			PlayerPrefs.Save ();
		//to display user in the next welcome dialouge 
		dispname.text = nameFeild.text;
		}//end else
		StartCoroutine (WelcomeDialouge (true, 0f));
		StartCoroutine (WelcomeDialouge (false, 4f));

	}


	//this method to generate random name from array of names
	public void randomName(){
		string nameGenerated=names[Random.Range(0, names.Length)];
		dispname.text =nameGenerated;
		SetUsername (nameGenerated);
		PlayerPrefs.Save ();
	
	}

	//right icon 
	public void showRight(){
		rightIcon.SetActive(true);

	}

	//this method to asking about the user name for the first time  
	public void disapearDialouge(bool show){
		nameDialouge.SetActive(show);

	}
	//first welcome 
	IEnumerator WelcomeDialouge(bool show,float delayTime){

		yield return new WaitForSeconds(delayTime);
		welcomeDialouge.SetActive(show);

		instructionfirsttime (show);


	}
	public static void SetUsername(string name){
		PlayerPrefs.SetString ("Username",name);
	}
	public static string GetUsername(){
		return PlayerPrefs.GetString ("Username");
	}

	//welcome back
	IEnumerator ShowWelcome(bool show,float delayTime){
		
		yield return new WaitForSeconds(delayTime);
		welcomeBack.SetActive (show); 



	}

	void Start (){
		changeNameFeild.GetComponent<InputField>().placeholder.GetComponent<Text>().text =GetUsername ();

		        //Application.Quit();
		        if (firstTime ()) {
			            //if first time open app show enter username dialouge
			            disapearDialouge (true);

		        } else {

			            if (PlayerPrefs.GetInt ("welcombbool1") == 1)
				                welcombbool = true;

			        if (welcombbool == true)  {
				                //to show welcome back dialouge & hide it after view of seconds

				                dispname2.text = GetUsername ();
				                StartCoroutine (ShowWelcome (true, 0f));
				                StartCoroutine (ShowWelcome (false, 5f));

				                welcombbool = false;
				                PlayerPrefs.SetInt("welcombbool1", welcombbool ? 1 : 0);
				                PlayerPrefs.Save();

				                    print ("a"+welcombbool);

				            }//if
			        }

		    }//start

	    void OnApplicationQuit(){

		        welcombbool = true;
		        PlayerPrefs.SetInt("welcombbool1", welcombbool ? 1 : 0);
		        print ("sara"+ PlayerPrefs.GetInt ("welcombbool1"));
		        PlayerPrefs.Save();

		    }


	public static bool firstTime(){
		if (!PlayerPrefs.HasKey("Username")) {
			return true;
		}
		return false;
	}


	public void instructionfirsttime(bool show){
		//after closing welcome dialogs 

		if (!show) {
			StartCoroutine (ShowInstruction (true, 0f));
			StartCoroutine (ShowInstruction (false, 10f));
		}
	}//END METHOD

	IEnumerator ShowInstruction(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);
		instruction.SetActive (show); 

	}


}
