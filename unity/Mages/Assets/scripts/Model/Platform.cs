using UnityEngine;
using System.Collections;

public class Platform : Building {

	public int resA = 1, resB = 2, resC = 3, resD = 4;

	public Beacon beacon;

	public void setBeacon(Beacon beacon) {
		this.beacon = beacon;
	}

	override public void changeOwner(Player owner) {
		this.owner = owner;
		changeOwnerAnim (); 
	}

	private void changeOwnerAnim() {
		renderer.material.color = beacon.renderer.material.color;
	}

}
