using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class HandFollowTools : MonoBehaviour {
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

					FingerModel finger = hand_model.fingers [1];
					Ray ray = finger.GetRay();	
					Vector3 origin = new Vector3 (0.07f, 0f, 0f);
					Vector3 P =   hand_model.fingers [1].bones[2].position;
					//P.y -= 0.01f;
					transform.position = P;
					//transform.rotation = finger.bones[1].rotation;
				


//					transform.LookAt =  Quaternion.Euler (ray.direction);
					transform.forward = ray.direction;
					//print (transform.position);

				}
			}
		}
	}
}
