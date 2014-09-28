﻿using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	public int resA = 1, resB = 2, resC = 3, resD = 4;

	// current owner
	public Player owner;

	// injection of possible owners
	public Player player, enemy, nobody;

	// related platforms
	public Platform[] platforms; 
	 
	private void __changeOwner(Player owner) {

		// remove beacon from previous owner
		this.owner.beacons.Remove(this);

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

	private void __checkEnd() {
		if ((tag == "Finish Beacon") && (owner == player)) {
			if (Application.loadedLevel + 1 != Application.levelCount) {
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				Application.LoadLevel(0);
			}
		}
	}

	void SpawnCreature() {
		if (owner.creatureTypes.Length > 0) {

			Instantiate(
				owner.creatureTypes[0], 
				new Vector3(
					transform.position.x,
					collider.bounds.size.y + transform.position.y + 0.5f,
					transform.position.z
				),
				Quaternion.identity);
		}
	}


	void Start () {
		// assign owner to platforms
		__changeOwner(owner);
	}



	void Update () {
		if (Input.GetMouseButton(0)) {		
			RaycastHit _hit;
			Ray _ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(_ray, out _hit, 1000.0f)) {
				if (_hit.collider.gameObject == gameObject) {
					if(owner == nobody) {
						__changeOwner(player);
					} else if(owner == player)  {
						__changeOwner(nobody);
					}
					__checkEnd();
				}
			}
		}
	}


}
