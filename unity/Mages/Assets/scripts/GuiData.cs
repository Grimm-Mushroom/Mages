﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiData : MonoBehaviour {

	public int resA, resB, resC, resD;

	void Start() {
		InvokeRepeating("process", 5.0f, 5.0f);
	}

	private void process() {
		int tempResA = 0, tempResB = 0, tempResC = 0, tempResD = 0;

		foreach (Beacon beacon in PlayerManager.INSTANCE.player.beacons) {
			tempResA += beacon.resA;
			tempResB += beacon.resB;
			tempResC += beacon.resC;
			tempResD += beacon.resD;

			foreach (Platform platform in beacon.platforms) {
				tempResA += platform.resA;
				tempResB += platform.resB;
				tempResC += platform.resC;
				tempResD += platform.resD;
			}
		}

		resA += tempResA;
		resB += tempResB;
		resC += tempResC;
		resD += tempResD;

	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 20), resA.ToString());
		GUI.Label (new Rect (30, 10, 100, 20), resB.ToString());
		GUI.Label (new Rect (50, 10, 100, 20), resC.ToString());
		GUI.Label (new Rect (70, 10, 100, 20), resD.ToString());


		if (GUI.Button (new Rect (90, 10, 100, 20), "Capture")) {
			SpellManager.INSTANCE.spellProcessor = captureBeaconSpellProcessor;	
		}
		if (GUI.Button (new Rect (210, 10, 100, 20), "Spawn")) {
			SpellManager.INSTANCE.spellProcessor = spawnCreatureSpellProcessor;	
		}

	}

	private ISpellProcessor captureBeaconSpellProcessor = new CaptureBeaconSpellProcessor();
	private ISpellProcessor spawnCreatureSpellProcessor = new SpawnCreatureSpellProcessor();

}
