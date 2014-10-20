using UnityEngine;
using System.Collections;

public class Beacon : Building {

	public int resA = 1, resB = 2, resC = 3, resD = 4;

	// related platforms
	public Platform[] platforms; 
	 
	override public void changeOwner(Player owner) {

		// remove beacon from previous owner
		if (this.owner != null) {
			this.owner.beacons.Remove(this);
		}

		// assign new owner
		this.owner = owner;

		// add beacon to new owner
		owner.beacons.Add(this);

		changeOwnerAnim(owner);
		foreach (Platform platform in platforms) {
			platform.setBeacon(this);
			platform.changeOwner(owner);
		}
	}

	private void changeOwnerAnim(Player owner) {
		renderer.material.color = owner.color;
	}

	public void checkEnd() {
		if ((tag == "Finish Beacon") && (owner == PlayerManager.INSTANCE.player)) {
			if (Application.loadedLevel + 1 != Application.levelCount) {
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				Application.LoadLevel(0);
			}
		}
	}

	void Start () {
		changeOwner(PlayerManager.INSTANCE.nobody);
	}

}
