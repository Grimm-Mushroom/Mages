using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour, ICastable {

	public int resA = 1, resB = 2, resC = 3, resD = 4;

	// current owner
	public Player owner;

	// related platforms
	public Platform[] platforms; 
	 
	public void ChangeOwner(Player owner) {

		// remove beacon from previous owner
		if (this.owner != null) {
			this.owner.beacons.Remove(this);
		}

		// assign new owner
		this.owner = owner;

		// add beacon to new owner
		owner.beacons.Add(this);

		__changeOwnerAnim(owner);
		foreach (Platform platform in platforms) {
			platform.setBeacon(this);
			platform.changeOwner(owner);
		}
	}

	private void __changeOwnerAnim(Player owner) {
		renderer.material.color = owner.color;
	}

	public void checkEnd() {
		if ((tag == "Finish Beacon") && (owner == PlayerManager.Instance.player)) {
			if (Application.loadedLevel + 1 != Application.levelCount) {
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				Application.LoadLevel(0);
			}
		}
	}

	void Start () {
		ChangeOwner (PlayerManager.Instance.nobody);
	}

	void OnMouseUpAsButton () {
		SpellManager.Instance.spellProcessor.cast (this);
	}

	void OnMouseEnter () {
		SpellManager.Instance.spellProcessor.allocate (this);
	}

	void OnMouseExit () {
		SpellManager.Instance.spellProcessor.deallocate (this);
	}

	public void cast (ISpell action) {
		action.cast (this);
	}

	public void allocate (ISpell action) {
		action.allocate (this);
	}

	public void deallocate (ISpell action) {
		action.deallocate (this);
	}

}
