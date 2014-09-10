using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	public int owner;
	public Platform[] platforms; 

	 
	private void __changeOwner(int own) {
		owner = own;
		__changeOwnerAnim (own);
		foreach(Platform platform in platforms) {
			platform.changeOwner(own);
		}
	}

	private void __changeOwnerAnim(int own) {
		if (owner < 0) {
			renderer.material.color = new Color(0, 0, 0);
		} else if (owner > 0) {
			renderer.material.color = new Color(1, 1, 1);
		}
	}

	private void __checkEnd() {
		if ((tag == "Finish Beacon") && (owner == 1)) {
			if (Application.loadedLevel + 1 != Application.levelCount)
				Application.LoadLevel(Application.loadedLevel + 1);
			else
				Application.LoadLevel(0);

		}
	}

	// Use this for initialization
	void Start () {
		__changeOwner (owner);
		Debug.Log (tag);
			//_buildings = GameObject.FindGameObjectsWithTag ("Building");
	}



	void Update () {
		if (Input.GetMouseButtonDown (0)) {		
			Ray _ray;
			RaycastHit _hit;
			_ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(_ray, out _hit, 1000.0f)) {
				if (_hit.collider.gameObject == gameObject) {
					if(owner == 0) {
						__changeOwner(1);
					} else {
						__changeOwner(owner * -1);
					}
					__checkEnd();
				}
			}
		}
		
	}
}
