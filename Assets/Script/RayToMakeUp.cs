using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class RayToMakeUp : MonoBehaviour {
	public Ray ray;
	public LeapProvider LeapDataProvider;
	public HandModel hand_model;
	public int paintSize;
	public string tools="square";
	private Color c;
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
		tools = "square";
	}
	
	// Update is called once per frame
	void Update () {
		
		Frame curFrame = LeapDataProvider.CurrentFrame.TransformedCopy(LeapTransform.Identity);
		for (int whichHand = 0; whichHand < 2; whichHand++) {
			if (curFrame.Hands.Count > whichHand) {

				if (curFrame.Hands [whichHand].IsRight) {
					FingerModel finger =hand_model.fingers[1];
					ray = finger.GetRay();	
					Debug.DrawRay (ray.origin,ray.direction*0.05f,Color.green);
					RaycastHit hit = new RaycastHit ();
					if (!Physics.Raycast (ray,out hit,0.01f)) {
						return;
					}

					Vector2 pixelUV = hit.textureCoord;
					Renderer renderer= hit.collider.GetComponent<Renderer> ();
					MeshCollider meshCollider = hit.collider as MeshCollider;
					if (renderer == null || renderer.sharedMaterial == null ||renderer.sharedMaterial.mainTexture == null || meshCollider == null){
						return;
					}
						
					Texture2D objectTexture = renderer.material.mainTexture as Texture2D;
					pixelUV.x *= objectTexture.width;
					pixelUV.y *= objectTexture.height;

					try{
						c=ColorSelector.GetColor();
					}catch{
						c = Color.black;
					}	
					if(tools.Equals("square")){
						for(int i=0;i<paintSize;i++){
							for(int j=0;j<paintSize;j++){
								objectTexture.SetPixel((int)pixelUV.x+i ,(int)pixelUV.y+j, c);
							}
						}
					}else{
						for(int i=0;i<paintSize;i++){
							for(int j=0;j<paintSize;j++){
								objectTexture.SetPixel((int)pixelUV.x+i ,(int)pixelUV.y+j, c);
							}	
						}
					}

					objectTexture.Apply();
				}
			}
		}
	}
}
