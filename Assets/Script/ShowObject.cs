using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
public class ShowObject : MonoBehaviour {
	public GameObject gobj;
	public HandModel hand_model;
	public LeapProvider LeapDataProvider;
	private bool flag = false;

	// Use this for initialization
	void Start () {
		gobj.SetActive (false);
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
		
	}
	public void ShowButtonSwitch(string showFlag){
		if(showFlag.Equals("1")){
			flag = true;
			gobj.SetActive (true);
			print ("xuanz");
		}else{
			flag = false;
			gobj.SetActive (false);
			print ("qx");
		}


	}

}

