using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BoxControl: MonoBehaviour {

	private Animation opining;
	private bool isopen=false;
	public static Ray ray;//this will be the ray that we cast from our touch into the scene
	private static level3manger levelmanger; 


	// Use this for initialization
	void Start () {

		opining = GetComponent<Animation>();
		levelmanger = GetComponent<level3manger>();

	}
	
	// Update is called once per frame
	void Update () {

		/*ray = Camera.main.ScreenPointToRay(_instance.position);//creates ray from screen point position
		if (Physics.Raycast (ray,out hit,100)) {//+out hit 
			print ("Hit box insaid!");
					
			if  (isopen)
			{
				closeit ();
			} 
			else
			{
				openit ();

			}	
		}*/


		/*if(Physics.Raycast(transform.position, transform.forward,out hit, 2))
		{
			if(hit.collider.gameObject.tag == "main" )
			{
				var chest = gameObject.FindWithTag("chest");
				if (Input.GetKeyDown("x"))
				{
					if  (isopen)
					{
						closeit ();
					} 
					else
					{
						openit ();

					}
				}
			}
		} */
	}
	public void openit(){
		//animation.CrossFade ("walk");
			opining.Play ("box_open");
		    isopen = true;
		levelmanger.CheckBoxes(this);

	}
	public void closeit(/* box number !*/){
		opining.Play ("box_close");
		//opining.Stop ();
		isopen = false;

	}
	public void mached(){
		//if get the cads match it 

	}


	public bool isOpen(){
		return isopen;
	}
	public void setbumb(){
	//StartCoroutine("Bumb");
}
	IEnumerator Bumb(){
	yield return new WaitForSeconds(.5f);
	//Destroy(gameObject);
}
}
