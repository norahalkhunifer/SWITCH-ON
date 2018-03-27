using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

	public class boxesHit : MonoBehaviour
	{
		public Transform m_HitTransform;
	public GameObject cam;
	private float destance;
		public static Ray ray;//this will be the ray that we cast from our touch into the scene
		private static RaycastHit hit;
		private static level3manger levelmanger; 



		bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
		{
			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
			if (hitResults.Count > 0) {
				//!!!!!!!never called why ???/
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
				x = 0.1f, //do a hit test at the center of the screen
				y = 0.4f
			};

			ARHitTestResultType[] resultTypes = {
				//ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, //if you want to use bounded planes
				//ARHitTestResultType.ARHitTestResultTypeExistingPlane,// if you want to use infinite planes use this
				ARHitTestResultType.ARHitTestResultTypeHorizontalPlane,
				ARHitTestResultType.ARHitTestResultTypeFeaturePoint// if you want to hit test on feature points
			};
			foreach (ARHitTestResultType resultType in resultTypes) {
				//2times 
				//Debug.Log ("ressult type" + resultType.ToString());
				if (HitTestWithResultType (point, resultType)) {
					return;
				}
			}
		}
		// Update is called once per frame
		void Update () {
			
			if (Input.touchCount > 0 &&(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch (0).fingerId))) {
				var touch = Input.GetTouch (0);
				//var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				//Debug.Log ("x" + screenPosition.x+"y"+screenPosition.y+"all"+ screenPosition.ToString());
				ray = Camera.main.ScreenPointToRay (touch.position);//creates ray from screen point position

				if (Physics.Raycast (ray, out hit)&& (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))) {//Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)

					GameObject item = hit.collider.transform.gameObject; //parent is what is stored in our area;
					//print ("Hit  " + item.name);
				destance=Vector3.Distance(item.transform.position,cam.transform.position);
				if(destance<3f)
					levelmanger.touchsomething (item);
				else{
					levelmanger.farAway ();
				    Debug.Log (destance);
				}

					

					

				}
			}

			/*var screenPosition = Camera.main.ScreenToViewportPoint(new Vector2(Screen.width/2,Screen.height/2));


			ARPoint point = new ARPoint {
				x = screenPosition.x,
				y = screenPosition.y
			};

			// prioritize reults types
			ARHitTestResultType[] resultTypes = {
				ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
				// if you want to use infinite planes use this:
				//ARHitTestResultType.ARHitTestResultTypeExistingPlane,
				// ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
				ARHitTestResultType.ARHitTestResultTypeFeaturePoint
			}; 

			foreach (ARHitTestResultType resultType in resultTypes)
			{
				if (HitTestWithResultType (point, resultType))
				{
					return;
				}
			}*/
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
	GameObject FindClosestBox() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest=null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	}


