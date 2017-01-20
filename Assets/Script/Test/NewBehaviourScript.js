// Attach this script to a camera and it will paint black pixels in 3D
// on whatever the user clicks. Make sure the mesh you want to paint
// on has a mesh collider attached.
//附加这个脚本到相机，当用户点击时
//它将在3D中绘制黑色的像素，确保绘制的网格附加有一个网格碰撞器.
function Update () {
	// Only when we press the mouse
	//只有在按下鼠标时
	if (!Input.GetMouseButton (0))
	return;

	// Only if we hit something, do we continue
	//只有碰到某些东西，继续
	var hit : RaycastHit;
	if (!Physics.Raycast (GetComponent.<Camera>().ScreenPointToRay(Input.mousePosition), hit))
		return;

	// Just in case, also make sure the collider also has a renderer
	// material and texture. Also we should ignore primitive colliders.
	//以防万一，还要确保碰撞器也有一个渲染器、材质和纹理.我们也应该忽略几何体碰撞器.
	var renderer : Renderer = hit.collider.GetComponent.<Renderer>();
	var meshCollider = hit.collider as MeshCollider;
	if (renderer == null || renderer.sharedMaterial == null ||
		renderer.sharedMaterial.mainTexture == null || meshCollider == null)
	return;

	// Now draw a pixel where we hit the object
	//现在在所碰到的物体上绘制一个像素
	var tex : Texture2D = renderer.material.mainTexture;
	var pixelUV = hit.textureCoord;
	pixelUV.x *= tex.width;
	pixelUV.y *= tex.height;

	tex.SetPixel(pixelUV.x, pixelUV.y, Color.black);
	tex.SetPixel(pixelUV.x+1, pixelUV.y+1, Color.black);
	tex.SetPixel(pixelUV.x-1, pixelUV.y-1, Color.black);
	tex.SetPixel(pixelUV.x+1, pixelUV.y, Color.black);
	tex.SetPixel(pixelUV.x, pixelUV.y+1, Color.black);
	tex.SetPixel(pixelUV.x-1, pixelUV.y, Color.black);
	tex.SetPixel(pixelUV.x, pixelUV.y-1, Color.black);
	tex.SetPixel(pixelUV.x-1, pixelUV.y+1, Color.black);
	tex.SetPixel(pixelUV.x+1, pixelUV.y-1, Color.black);
	tex.Apply();
}