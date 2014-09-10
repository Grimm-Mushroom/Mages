using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public int owner;
	public Beacon MyBeacon;

	public void changeOwner(int own) {
		owner = own;
		__changeOwnerAnim (); 
	}

	private void __changeOwnerAnim() {
		renderer.material.color = MyBeacon.renderer.material.color;
	}




}
