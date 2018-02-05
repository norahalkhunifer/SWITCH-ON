using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manger : MonoBehaviour {

	public void testwinlose(bool wrl){
		if (wrl)
			PlayerPrefs.SetInt ("LevelPassed", 2);
		SceneManager.LoadScene ("world");
	}
	public void testwinlose2(bool wrl){
		if (wrl)
			PlayerPrefs.SetInt ("LevelPassed", 1);
		SceneManager.LoadScene ("world");
	}

}
