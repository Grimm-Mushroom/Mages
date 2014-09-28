using UnityEngine;
using System.Collections;

public class GuiData : MonoBehaviour {

	public Player player;

	public int resA, resB, resC, resD;

	void Start () {
		InvokeRepeating("__process", 5.0f, 5.0f);
	}
	
	void Update () {
		//создание существа по клику
		if (Input.GetMouseButtonDown (0)) {	
			RaycastHit _hit;
			Ray _ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (_ray, out _hit, 1000.0f)) {
				_hit.collider.gameObject.SendMessage("SpawnCreature", null, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void __process() {
		int tempResA = 0, tempResB = 0, tempResC = 0, tempResD = 0;

		foreach (Beacon beacon in player.beacons) {
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

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 20), resA.ToString());
		GUI.Label (new Rect (30, 10, 100, 20), resB.ToString());
		GUI.Label (new Rect (50, 10, 100, 20), resC.ToString());
		GUI.Label (new Rect (70, 10, 100, 20), resD.ToString());
	}

}
