using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class UnitTest {
	SetGetName welcometest =new SetGetName();
	AudioManager audiotest=new AudioManager();
	settingManger settingtest =new settingManger();
	LevelManger levelmangertest=new LevelManger();

	[Test]
	public void UnitTestSimplePasses() {
		// Use the Assert class to test conditions.
		//Assert.AreEqual(SetGetName.firstTime(),true);

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode

	[UnityTest]
	public IEnumerator UnitTestWithEnumeratorPasses() {
		//var prefabs =
		// Use the Assert class to test conditions.
		// yield to skip a frame
		//var prefap=PrefabUtility.GetPrefabParent(3);

		//Assert.AreEqual(RandomObj,prefap);

		yield return null;
		//Assert.AreEqual(SetGetName.firstTime(),true);


	}
	/*[UnityTest]
	public IEnumerator TestsRegisterPasses() {
		string username = "Sara";
		SetGetName.SetUsername (username);
		yield return new WaitForSeconds(1);
		Assert.AreEqual (username, SetGetName.GetUsername ());


	}*/
	[UnityTest]
	public IEnumerator TestsRandomNamePasses() {
		string username = welcometest.getRandomName();
		Debug.Log (username);
		yield return new WaitForSeconds(1);
		Assert.AreEqual (username, SetGetName.GetUsername ());

	}
	[UnityTest]
	public IEnumerator TestsLevelPasses() {
		levelmangertest.win (1,7,"0:22");
		yield return new WaitForSeconds(1);
		Assert.AreEqual (levelmangertest.getlevelpassed(),1);

	}
	[UnityTest]
	public IEnumerator TestsMutePasses() {
		audiotest.SetMute (1);
		Debug.Log (audiotest.GetMute());
		yield return new WaitForSeconds(1);
		Assert.IsFalse (audiotest.GetMute());

	}
	[UnityTest]
	public IEnumerator TestsCapePasses() {
		settingtest.setCapecolor ("Blue");
		yield return new WaitForSeconds(1);
		Assert.AreEqual ("Blue",settingtest.getCapeColor());

	}
	[UnityTest]
	public IEnumerator TestAddTotalscorePasses() {
		levelmangertest.win (1,7,"0:22");
		yield return new WaitForSeconds(0.1f);
		Assert.AreEqual (levelmangertest.getTotalScreore(),7);
	}
	[UnityTest]
	public IEnumerator TestSubTotalscorePasses() {
		yield return new WaitForSeconds(1);
		levelmangertest.subTotalScore (7);
		Assert.AreEqual (levelmangertest.getTotalScreore(),0);
	}
}
