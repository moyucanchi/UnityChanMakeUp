using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class ColorSelect : MonoBehaviour {
	public Ray ray;
	public LeapProvider LeapDataProvider;
	public HandModel hand_model;

	// Use this for initialization
	void Start () {
		if (LeapDataProvider == null)
		{
			LeapDataProvider = FindObjectOfType<LeapProvider>();
			if (LeapDataProvider == null || !LeapDataProvider.isActiveAndEnabled)
			{
				Debug.LogError("Cannot use LeapImageRetriever if there is no LeapProvider!");
				enabled = false;
				return;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

		Frame curFrame = LeapDataProvider.CurrentFrame.TransformedCopy(LeapTransform.Identity);
		for (int whichHand = 0; whichHand < 2; whichHand++) {
			if (curFrame.Hands.Count > whichHand) {

				if (curFrame.Hands [whichHand].IsRight) {
					FingerModel finger =hand_model.fingers[1];
					ray = finger.GetRay();	
					RaycastHit hit = new RaycastHit ();
					if (!Physics.Raycast (ray,out hit,0.01f)) {
						
					}


				}
			}
		}
	}
}
