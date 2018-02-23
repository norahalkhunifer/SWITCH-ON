using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level3manger : MonoBehaviour
{

	public List<GameObject> boxes = new List<GameObject> ();
	//array used to keep track of boxes objects
	public GameObject[] random;
	//array of objects name
	private int[] randomthingsrepet;
	//array of objects name
	public int size;
//same as array of boxes/2 almost!
	BoxControl current;
	private BoxControl[] currentboxes = new BoxControl[2];
	private int nroftries = 0;
	public Text time;
	public Text debugbox;
	private float timer;
	public float timelimitbysec;
	private Text score;
	private int scorenum=0;

	// Use this for initialization
	void Start ()
	{
		//start timer depend on the complexity 
		timer = Time.time + timelimitbysec;
		randomthingsrepet = new int[random.Length];
		//add all boxes to array why ? couse they will have same index as there random object insaide 
		foreach (GameObject box in boxes) {
			placeRandomobj (box);
			//Instantiate (RandomGenrator.placeRandomobj(),box.transform.position,box.transform.rotation,box.transform);
		}
		setScore ();
	}

	public void placeRandomobj (GameObject box)
	{
		int randomInt = GetRandom (random.Length);

		if (randomthingsrepet [randomInt] % 2 != 0 || (randomthingsrepet [randomInt] < (size / 2))) {
			Vector3 newpos = new Vector3 (box.transform.position.x, box.transform.position.y + 0.05f, box.transform.position.z);
			GameObject newObject = Instantiate (random [randomInt], newpos, box.transform.rotation, box.transform)as GameObject;
			newObject.transform.localScale = new Vector3 (0.005f, 0.005f, 0.005f);//box.transform.localScale.x, box.transform.localScale.y, box.transform.localScale.z); // change its local scale in x y z format
			//Instantiate(names[randomInt], spawnPos.position//in mid of our chest object (from boxes array , spawnPos.rotation//same also we want to added it to object rooot +scale is fixed !);
			randomthingsrepet [randomInt] += 1;
			box.GetComponent<BoxControl> ().insaideobj = newObject;
		} else
			placeRandomobj (box);
	}

	int GetRandom (int count)
	{
		return Random.Range (0, count);
	}

	void Update ()
	{
		float t = timer - Time.time;
		string min = ((int)t / 60).ToString ();
		string sec = ((int)t % 60).ToString ();
		if (t <= 0) {
			time.text = "done";
			home ();

		} else//we can change it to red if its close to end by 5 or 10 sec 
		time.text = min + ":" + sec;
	}

	public void touchsomething (GameObject hitobject)
	{
		//check if its shadow or pairent don't get in 
		//get it and openit or close it the mange will be in other method 
		current = hitobject.GetComponent<BoxControl> ();
		if (current != null) {
			if (current.isOpen ()) {
				current.closeit ();
			} else {
				current.openit ();

			}	
		} else
			print ("not box!");//message that says tuch me again!


	}

	public void home ()
	{
		SceneManager.LoadScene ("world");
	}

	//check if there is 2 opened before
	public void CheckBoxes (BoxControl bc)
	{//null point why?
		//PrefabUtility.GetPrefabParent(gameObject) == null && PrefabUtility.GetPrefabObject(go) != null; // Is a prefab
		debugbox.text= "in method!";

		if (currentboxes [0] == null)
			currentboxes [0] = bc;
		else {
			currentboxes [1] = bc;
			nroftries++;
			debugbox.text= "notnull!";
			//check if it's not the same box !
			if (PrefabUtility.GetPrefabParent(currentboxes [0].insaideobj) == PrefabUtility.GetPrefabParent(currentboxes [1].insaideobj))
				BoxesMatching ();
			else
				BoxesNotMatching ();

			currentboxes [0] = null;
			currentboxes [1] = null;
		}
	}

	public void BoxesMatching ()
	{
		currentboxes [0].mached ();
		currentboxes [1].mached ();

		size--;
		if (size == 0)
			GameEnd ();
	}

	public void BoxesNotMatching ()
	{

		currentboxes [0].closeit ();
		currentboxes [1].closeit ();
	}

	public void timelimit ()
	{


	}
	public void addscore (int addedscore)
	{
		scorenum += addedscore;
		setScore ();
	}
	private void setScore(){
		score.text = scorenum.ToString ();
	}
	void GameEnd ()
	{
		//check wining or loosing
		Debug.Log ("Game has ended, number of tries: " + nroftries);
	}

	public void save (int winscore)
	{
		PlayerPrefs.SetInt ("Level3Score", winscore);
	}


}
