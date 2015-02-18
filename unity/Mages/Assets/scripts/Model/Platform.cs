using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Platform : Building {

	//public int resA = 1, resB = 2, resC = 3, resD = 4;

	public Beacon beacon;
	public Platform[] neighbors;

	public void setBeacon(Beacon beacon) {
		this.beacon = beacon;
	}

	override public void changeOwner(Player owner) {
		this.owner = owner;
		changeOwnerAnim (); 
	}

	private void changeOwnerAnim() {
		renderer.material.color = owner.color;
	}

	public List<List<Platform>> getNeighborsFromDistance(int distance) {
		List<List<Platform>> result = new List<List<Platform>> ();

		result.Add (new List<Platform>());
		result [0].Add (this);

		for (int i = 1; i <= distance; i++) {
			result.Add (new List<Platform>());

			foreach (Platform currPlato in result[i - 1]){
				for (int j = 0; j < currPlato.neighbors.Length; j++) {
					if (!result[i].Contains(currPlato.neighbors[j]) &&
					    !result[i - 1].Contains(currPlato.neighbors[j])) {
						result[i].Add(currPlato.neighbors[j]);
					}
				}
			}
		}
		
		return result;
	}

}
