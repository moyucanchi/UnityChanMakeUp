using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour {
	public Camera camera;
	public Rect rect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
	public void CaptureCamera()
    {
      
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
      
        camera.targetTexture = rt;
        camera.Render();
       
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();

     
        camera.targetTexture = null;
       
        RenderTexture.active = null; 
        GameObject.Destroy(rt);
       
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + "/Screenshot.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("截屏了一张照片: {0}", filename));

       
    }
}
