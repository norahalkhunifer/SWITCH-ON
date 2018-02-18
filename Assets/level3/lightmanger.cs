using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
public class lightmanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += UpdateAmbientIntensity;
	}
	
	// Update is called once per frame
	void UpdateAmbientIntensity (UnityARCamera cam) {
		float newLight = cam.lightData.arLightEstimate.ambientIntensity / 1000f;
		RenderSettings.ambientLight = Color.white * newLight;
		//RenderSettings.ambientIntensity = 4f;

	}
}
