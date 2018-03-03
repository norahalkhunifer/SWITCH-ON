using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGetName : MonoBehaviour {
	float timer = 0f;
	public InputField nameFeild;
	public Text dispname;
	public Text dispname2;

	public GameObject nameDialouge;
	public GameObject welcomeDialouge;
	public GameObject welcomeBack;
	public GameObject instruction;


	//static bool firsttime;

	private string[] names = new string[] { "Peter", "Ron", "Satchmo", "Iron-Cut", "Titanium", "Lightning", "Kevlar", "Rex", "Falcon", "Switch on player" };

	public void setget () {
		if (nameFeild.text == "") {

			randomName ();

		}
			//Debug.Log ("field is empty");
		//to save the written name into playerprefs
		else {
			SetUsername (nameFeild.text);
			PlayerPrefs.Save ();
		//to display user in the next welcome dialouge 
		dispname.text = nameFeild.text;
		}//end else

		WelcomeDialouge (true);
	}


	public void randomName(){
		//dispname.text = "switch on player";
		string nameGenerated=names[Random.Range(0, names.Length)];
		dispname.text =nameGenerated;
		SetUsername (nameGenerated);
		PlayerPrefs.Save ();
	
	}


	public void disapearDialouge(bool show){
		nameDialouge.SetActive(show);
		instructionfirsttime ();

	}
	public void WelcomeDialouge(bool show){
		welcomeDialouge.SetActive(show);
	}
	public static void SetUsername(string name){
		PlayerPrefs.SetString ("Username",name);
	}
	public static string GetUsername(){
		return PlayerPrefs.GetString ("Username");
	}

	public void WelcomeBack(bool show){
		welcomeBack.SetActive(show);

	}

	IEnumerator ShowWelcome(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);
		welcomeBack.SetActive (show); 

	}

	void Start (){
		if (firstTime()) {
			//if first time open app show enter username dialouge
			disapearDialouge (true);
			//if (nameDialouge.activeInHierarchy == false && welcomeDialouge.activeInHierarchy == false) {

			
		} else {
			//to show welcome back dialouge & hide it after view of seconds 
			dispname2.text = GetUsername ();
			StartCoroutine (ShowWelcome (true, 0f));
			StartCoroutine (ShowWelcome (false, 7f));
		
			}
		}

		
	void Update (){
		//nameDialouge.SetActive (true);
		//welcomeDialouge.SetActive (true);

		if (nameDialouge.activeInHierarchy==false){

			timer += Time.deltaTime;    
			if (timer >= 2) {
				welcomeDialouge.SetActive (false);
			

			}
		}


	}
	public static bool firstTime(){
		if (!PlayerPrefs.HasKey("Username")) {
			return true;
		}
		return false;
	}


	public void instructionfirsttime(){
		//after closing welcome dialogs 

		if (firstTime()) {
			//ShowInstruction (true,0f);
			StartCoroutine (ShowInstruction (true, 0f));
			StartCoroutine (ShowInstruction (false, 16f));
		}
	}//END METHOD

	IEnumerator ShowInstruction(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);
		instruction.SetActive (show); 

	}

}
