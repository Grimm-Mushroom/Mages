using UnityEngine;
using System.Collections;

public class GuiData : MonoBehaviour {

	public Player player;

	public int resources;

	void Start () {
		InvokeRepeating("__process", 5.0f, 5.0f);
	}
	
	void Update () {
	
	}

	private void __process() {
		resources += player.beacons.Count;
	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 20), resources.ToString());
	}

}
