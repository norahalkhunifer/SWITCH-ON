using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
namespace UnityEngine.XR.iOS
{//change name
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
		public static Ray ray;//this will be the ray that we cast from our touch into the scene
		private static RaycastHit hit;
		//private static Touch _instance;
		private static level3manger levelmanger; 

		//!!!!!!!never called why ???/
		bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
		{
			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
			if (hitResults.Count > 0) {
				foreach (var hitResult in hitResults) {
					Debug.Log ("Go hit!");
					m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);//returns a Vector3 in Unity Coordinates
					m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);//returns a Quaternion in Unity Coordinate
					Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));

					return true;
				}
			}
			return false;
		}
		void Awake () {
			//get the mager to send tutched object to it 
			levelmanger = GameObject.Find("manger").GetComponent<level3manger>();

			//place the boxes container on detected ground 
			ARPoint point = new ARPoint { 
				x = 0.5f, //do a hit test at the center of the screen
				y = 0.5f
			};
			/*var screenPosition = Camera.main.ScreenToViewportPoint();
			ARPoint point = new ARPoint {
				x = screenPosition.x,///where ?
				y = screenPosition.y
			};*/
			ARHitTestResultType[] resultTypes = {
				ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, //if you want to use bounded planes
				//ARHitTestResultType.ARHitTestResultTypeExistingPlane,// if you want to use infinite planes use this
				//ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
				ARHitTestResultType.ARHitTestResultTypeFeaturePoint// if you want to hit test on feature points
			}; 
			foreach (ARHitTestResultType resultType in resultTypes) {
				if (HitTestWithResultType (point, resultType)) {
					return;
				}
			}
		}
		// Update is called once per frame
		void Update () {
			if (Input.touchCount > 0) {
				var touch = Input.GetTouch (0);
				//var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);

				ray = Camera.main.ScreenPointToRay (touch.position);//creates ray from screen point position
				if (Physics.Raycast (ray, out hit)) {//Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)

					GameObject item = hit.collider.transform.gameObject; //parent is what is stored in our area;
					print ("Hit  " + item.name);
					levelmanger.touchsomething (item);

				}
			}
				//m_HitTransform.position = hit.point;
			///	m_HitTransform.rotation = hit.transform.rotation;
//#if !UNITY_EDITOR
//#endif
//UNITY_IOS
		}
		//conver AR cordinets  to unity cordinets
		//we can apply it in objects too 
		private Vector3 GetCameraPosition(UnityARCamera cam) {
			Matrix4x4 matrix = new Matrix4x4 ();
			matrix.SetColumn (3, cam.worldTransform.column3);
			return UnityARMatrixOps.GetPosition (matrix);
		}


	}
}

