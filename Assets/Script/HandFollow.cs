using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class HandFollow : MonoBehaviour {
	public HandModel hand_model;
	public LeapProvider LeapDataProvider;

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
					
					FingerModel finger = hand_model.fingers [2];

					transform.position =  hand_model.palm.position;
					//transform.rotation = finger.bones[1].rotation;
					Vector3 Q = hand_model.palm.rotation.eulerAngles;

					Q.z -= 90f;
				
					transform.rotation = Quaternion.Euler (Q);
					//print (transform.position);

				}
			}
		}
	}
}
