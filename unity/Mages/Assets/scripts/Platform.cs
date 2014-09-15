using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public int resA = 1, resB = 2, resC = 3, resD = 4;

	public Resources resources;

	public Player owner;

	public Beacon beacon;

	public void setBeacon(Beacon beacon) {
		this.beacon = beacon;
	}

	public void changeOwner(Player owner) {
		this.owner = owner;
		__changeOwnerAnim (); 
	}

	private void __changeOwnerAnim() {
		renderer.material.color = beacon.renderer.material.color;
	}

}
