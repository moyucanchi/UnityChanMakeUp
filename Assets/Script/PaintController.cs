using UnityEngine;
using System.Collections;
using Hover.Core.Utils;

namespace Hover.Core.Items.Types {

	public class PaintController : HoverItemDataSlider {
		int size;

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {

		}
		public void SetSize(){
			float value=GameObject.Find ("ItemBA").GetComponent<HoverItemDataSlider> ().RangeValue;
			GameObject.Find("Ray").GetComponent<RayToMakeUp>().paintSize= (int)value;
			return;
		}
		public void SetSharp(string sharp){
			GameObject.Find("Ray").GetComponent<RayToMakeUp>().tools= sharp;
			return;
		}
	}
}
