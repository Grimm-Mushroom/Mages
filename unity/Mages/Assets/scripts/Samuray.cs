using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Samuray : MonoBehaviour {

	private Mesh __mesh;
	private List<float> __verY;

	void Start () {
		__mesh = GetComponent<MeshFilter>().mesh;
		int i = 0;
		//Debug.Log (vertices.Length);

		__verY = new List<float>() ;
		while (i < __mesh.vertices.Length) {
			__verY.Add(Random.Range(-2.0f, 2.0f));
			i++;
		}
	}
	
	// Update is called once per frame
	void Update() {

		Vector3[] vertices = __mesh.vertices;
		int i = 0;
		
		while (i < vertices.Length) {
			vertices[i].y = __verY[i] + Mathf.Sin(Time.time * 3 + i)/2;//*100;
			i++;
		}
		__mesh.vertices = vertices;
		__mesh.RecalculateNormals ();
	}
}
