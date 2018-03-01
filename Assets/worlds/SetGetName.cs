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

	public void setget () {
		//to save the written name into playerprefs
		SetUsername(nameFeild.text);
		PlayerPrefs.Save();

		//to display user in the next welcome dialouge 
		dispname.text = nameFeild.text;
		WelcomeDialouge (true);
	}

	public void disapearDialouge(bool show){
		nameDialouge.SetActive(show);

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
		if (firsttime()) {
			//if first time open app show enter username dialouge
			disapearDialouge (true);
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
	public static bool firsttime(){
		if (!PlayerPrefs.HasKey("Username")) {
			return true;
		}
		return false;
	}
}
