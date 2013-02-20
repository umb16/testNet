using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class c_sprite : MonoBehaviour
{
	public Vector2 size;
	public int leftRightSide = 0;
	public int upDownSide = 0;
	public Vector2 anchor=new Vector2(.5f,.5f);
	public bool realSize=false;
	// Use this for initialization

	public MeshFilter meshFilter;
	// Use this for initialization

	void Awake ()
	{
		meshFilter = GetComponent<MeshFilter> ();
		if (leftRightSide < 0)
			leftRightSide = 0;
		if (leftRightSide > 1)
			leftRightSide = 1;
		if (upDownSide < 0)
			upDownSide = 0;
		if (upDownSide > 1)
			upDownSide = 1;
		if(realSize)
		if(renderer.sharedMaterial.mainTexture)
		{
		size.x=renderer.sharedMaterial.mainTexture.width;
		size.y=renderer.sharedMaterial.mainTexture.height;
		realSize=false;
		} 
	}
	void Start ()
	{
		meshFilter.mesh = CreateMesh (size, new Vector2 (1 * leftRightSide, 1 * upDownSide), new Vector2 (1 * leftRightSide, 1 - upDownSide), new Vector2 (1 - leftRightSide, 1 - upDownSide), new Vector2 (1 - leftRightSide, 1 * upDownSide));
//		meshFilter.mesh.Optimize();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	Mesh CreateMesh (Vector2 size, Vector2 tex0, Vector2 tex1, Vector2 tex2, Vector2 tex3)
	{
		var vertices = new[] { new Vector3 (-size.x*anchor.x, -size.y*anchor.y, 0), new Vector3 (-size.x*anchor.x, size.y*(1-anchor.y), 0), new Vector3 (size.x*(1-anchor.x), size.y*(1-anchor.y), 0), new Vector3 (size.x*(1-anchor.x), -size.y*anchor.y, 0) };
		
		var uv = new[] { tex0, tex1, tex2, tex3 };
		
		var triangles = new[] { 0, 1, 2, 0, 2, 3 };
		return new Mesh { vertices = vertices, uv = uv, triangles = triangles };
	}
}
