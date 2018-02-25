using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGetName : MonoBehaviour {
	float timer = 0f;
	public InputField nameFeild;
	public Text dispname;
	public GameObject nameDialouge;
	public GameObject welcomeDialouge;

	// Use this for initialization
	public void setget () {
		//to save the written name into playerprefs
		PlayerPrefs.SetString ("username",dispname.ToString());
		PlayerPrefs.Save();
		Debug.Log(PlayerPrefs.GetString("username"));

		//to display user in the next welcome dialouge 
		dispname.text = nameFeild.text;
	}

	public void disapearDialouge(){
		nameDialouge.SetActive(false);
	

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
}
