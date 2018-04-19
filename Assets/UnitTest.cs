using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UnitTest {

	[Test]
	public void UnitTestSimplePasses() {
		// Use the Assert class to test conditions.
		Assert.AreEqual(SetGetName.firstTime(),true);

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode

	[UnityTest]
	public IEnumerator UnitTestWithEnumeratorPasses() {
		//var prefabs =
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
		Assert.AreEqual(SetGetName.firstTime(),true);

	}
}
