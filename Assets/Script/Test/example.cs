using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
	void Start() {
		Texture2D texture = new Texture2D(64, 64);
		GetComponent<Renderer>().material.mainTexture = texture;
		int y = 0;
		while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				Color color = ((x == y) ? Color.white : Color.gray);
				texture.SetPixel(x, y,color);
				++x;
			}
			++y;
		}
		texture.Apply();
	}
}