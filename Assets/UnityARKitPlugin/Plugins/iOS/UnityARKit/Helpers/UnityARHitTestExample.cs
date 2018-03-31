using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
		public static Ray ray;//this will be the ray that we cast from our touch into the scene
		private static RaycastHit hit;
		private static Level2Manager levelmanager;
		private float distance;
		public GameObject cam;

		bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
		{

			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
			if (hitResults.Count > 0) {
				foreach (var hitResult in hitResults) {
					Debug.Log ("Got hit!");
					// m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
					m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResults[0].worldTransform);
					m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
					// Face the camera (assume it's level and rotate around y-axis only)
					//m_HitTransform.LookAt (Camera.main.transform.position);
					//m_HitTransform.eulerAngles = new Vector3 (0, m_HitTransform.eulerAngles.y, 0);
					Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
					return true;
				}
			}
			return false;
		}

		void Awake () {
			//get the mager to send tutched object to it 
			levelmanager = GameObject.Find("Balloons").GetComponent<Level2Manager> ();
			//place the boxes container on detected ground 
			ARPoint point = new ARPoint { 
				x = 0.1f, //do a hit test at the center of the screen
				y = 0.4f
			};
			// prioritize reults types
			ARHitTestResultType[] resultTypes = {
				ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
				// if you want to use infinite planes use this:
				ARHitTestResultType.ARHitTestResultTypeExistingPlane,
				//ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
				//ARHitTestResultType.ARHitTestResultTypeFeaturePoint
			};

			foreach (ARHitTestResultType resultType in resultTypes)
			{
				if (HitTestWithResultType (point, resultType))
				{
					return;
				}
			}
		}


		// Update is called once per frame
		void Update () {

			if (Input.touchCount > 0)
			{
				var touch = Input.GetTouch(0);

					var ray = Camera.main.ScreenPointToRay (touch.position);//creates ray from screen point position
					
				if (Physics.Raycast (ray, out hit)){//&& EventSystem.current.IsPointerOverGameObject()) {//Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)
						GameObject item = hit.collider.transform.gameObject; //parent is what is stored in our area;

					distance=Vector3.Distance(item.transform.position,cam.transform.position);

					if (distance < 3f) {
						print ("near");
						levelmanager.touchsomething (item);
					}

					else{
						levelmanager.farAway ();
						print("D"+distance);
					}


					//print (item.name);
						/*var screenPosition = Camera.main.ScreenToViewportPoint(new Vector2 (Screen.width / 2f, Screen.height / 2f));*/
	}


}
		}//end of update
	}
}

