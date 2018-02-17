using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManger : MonoBehaviour {

	public Sound[] sounds;


	[System.Serializable]
	public class Sound{
		public string Name;
		public AudioClip Source;
		[Range(0f,1f)]
		public float Volume;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void PlaySound(){

	}
}
