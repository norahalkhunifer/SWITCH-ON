using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
	 
	public static Level instance = null;
	int sceneIndex, levelPassed;
	GameObject levelSign;



	void Start(){
	
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		levelSign = GameObject.Find ("LevelNumber");

		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");

	}

	public void youWin()
	{
		Invoke ("loadWorld", 1f);
	}

	public void youLose()
	{
		Invoke ("loadMainMenu", 1f);
	}

	void loadWorld(){
		SceneManager.LoadScene ("world");
	}

	}
