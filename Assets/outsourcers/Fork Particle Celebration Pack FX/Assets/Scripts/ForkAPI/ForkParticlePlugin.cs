﻿/******************************************************************************
 Disclaimer Notice:
 This file is provided as is with no warranties of any kind and is
 provided without any obligation on Fork Particle, Inc. to assist in 
 its use or modification. Fork Particle, Inc. will not, under any
 circumstances, be liable for any lost revenue or other damages arising 
 from the use of this file.
 
 (c) Copyright 2017 Fork Particle, Inc. All rights reserved.
******************************************************************************/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class ForkParticlePlugin : MonoBehaviour {

	#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#elif UNITY_EDITOR_WIN
	[DllImport ("forkParticlePluginX64")]
	#elif UNITY_EDITOR_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_WIN
	[DllImport ("forkParticlePluginX86")]
	#elif UNITY_ANDROID
	[DllImport ("PluginAndroid")]
	#endif
	private static extern bool _frkParticlePluginSDKInit();

	#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#elif UNITY_EDITOR_WIN
	[DllImport ("forkParticlePluginX64")]
	#elif UNITY_EDITOR_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_WIN
	[DllImport ("forkParticlePluginX86")]
	#elif UNITY_ANDROID
	[DllImport ("PluginAndroid")]
	#endif
	private static extern bool  _frkParticlePluginSDKShutdown();

	#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#elif UNITY_EDITOR_WIN
	[DllImport ("forkParticlePluginX64")]
	#elif UNITY_EDITOR_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_WIN
	[DllImport ("forkParticlePluginX86")]
	#elif UNITY_ANDROID
	[DllImport ("PluginAndroid")]
	#endif
	private static extern void _frkParticlePluginSetEffectView(Matrix4x4 viewMat, Matrix4x4 projMat, Vector3 Up, Vector3 Right, Vector3 Forward, Vector3 Position);

	#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#elif UNITY_EDITOR_WIN
	[DllImport ("forkParticlePluginX64")]
	#elif UNITY_EDITOR_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_OSX
	[DllImport ("PluginMAC")]
	#elif UNITY_STANDALONE_WIN
	[DllImport ("forkParticlePluginX86")]
	#elif UNITY_ANDROID
	[DllImport ("PluginAndroid")]
	#endif
	private static extern bool _frkParticlePluginSDKProcess (float fFrameTDelta);

	/***********************************************************************/

	private static ForkParticlePlugin _instance = null;
    public string TexturePath = "ForkFX/";

	private ArrayList effectsList = new ArrayList(); //array of effects
	private bool bForkSDKShutdown = false;
	public bool bForkSDKInit	= false; 
	//No. of effects in the secne
	public GameObject effect1;
	public GameObject effect2;
	public GameObject effect3;
	public GameObject effect4;
	public GameObject effect5;
	public GameObject effect6;
	public GameObject effect7;
	public GameObject effect8;
	public GameObject effect9;
	public GameObject effect10;

	public static ForkParticlePlugin Instance {
		get {
			return _instance;
		}
	}

	void Awake() {
		if (_instance) {
			GameObject.Destroy (_instance.gameObject);
			_instance = null;
		}

		_instance = this;
	}

	// Use this for initialization
	void Start () {
		// Initializes the Fork SDK. 
		// The SDK must be initialised 
		// before creating any effects. 
		bForkSDKInit = _frkParticlePluginSDKInit ();
	}

	void Update()
	{
		Camera cam = Camera.main;
		_frkParticlePluginSetEffectView (cam.worldToCameraMatrix, cam.projectionMatrix, cam.transform.up, cam.transform.right, cam.transform.forward, cam.transform.position);
		_frkParticlePluginSDKProcess (1.0f / 60.0f);
	}

	public void AddEffect(GameObject obj)
	{
		effectsList.Add (obj);
	}

	public void RemoveEffect(GameObject obj)
	{
		effectsList.Remove (obj);
	}

	public bool ShutDownForkSDK()
	{
		if (bForkSDKShutdown)
			return true;
		
		InvalidateObjects ();
        // release textures
        ForkParticleEffect.DestroyTextures();

		// Shuts down the Fork SDK and destroy all the effects
		// references in the dll.
        bForkSDKShutdown = _frkParticlePluginSDKShutdown ();

		return bForkSDKShutdown;
	}

	void InvalidateObjects()
	{
		for (int i = 0; i < effectsList.Count; i++) {
			GameObject obj = (GameObject)effectsList [i];
			obj.GetComponent<ForkParticleEffect> ().InvalidateEffect();
		}
	}

	public void OnApplicationQuit ()
	{
		#if (!UNITY_EDITOR)
		if (bForkSDKShutdown == false) {
			Debug.Log("OnApplicationQuit ");
			ShutDownForkSDK ();
		}
		#endif
	}
	public void Test1(){
		print ("i enter it");
	effect1.GetComponent<ForkParticleEffect>().PlayEffect();
	effect1.GetComponent<ForkParticleEffect>().RestartEffect();
	}

    public void Test(GameObject obj) {

       // for (int i = 0; i < effectsList.Count; i++) {
           // GameObject obj = (GameObject)effectsList [i];


	if (obj.CompareTag("B1") ){
			print ("test");
	effect1.GetComponent<ForkParticleEffect>().PlayEffect();
	effect1.GetComponent<ForkParticleEffect>().RestartEffect();}

	if (obj.CompareTag("B2") ){
	print ("test");
	effect2.GetComponent<ForkParticleEffect>().PlayEffect();
	effect2.GetComponent<ForkParticleEffect>().RestartEffect();}

	if (obj.CompareTag("B3") ){
	print ("test");

	effect3.GetComponent<ForkParticleEffect>().PlayEffect();
	effect3.GetComponent<ForkParticleEffect>().RestartEffect();}

	if (obj.CompareTag("B4") ){
	effect4.GetComponent<ForkParticleEffect>().PlayEffect();
	effect4.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B5") ){
	print ("test");

	effect5.GetComponent<ForkParticleEffect>().PlayEffect();
	effect5.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B6") ){
	print ("test");

	effect6.GetComponent<ForkParticleEffect>().PlayEffect();
	effect6.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B7") ){
	print ("test");

	effect7.GetComponent<ForkParticleEffect>().PlayEffect();
	effect7.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B8") ){
	print ("test");

	effect8.GetComponent<ForkParticleEffect>().PlayEffect();
	effect8.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B9") ){
	print ("test");

	effect9.GetComponent<ForkParticleEffect>().PlayEffect();
	effect9.GetComponent<ForkParticleEffect>().RestartEffect();	}

	if (obj.CompareTag("B10") ){
	print ("test");

	effect10.GetComponent<ForkParticleEffect>().PlayEffect();
	effect10.GetComponent<ForkParticleEffect>().RestartEffect();}

           
    }

}