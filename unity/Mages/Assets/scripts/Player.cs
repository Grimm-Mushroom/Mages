using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public Color color;

	public Transform[] creatureTypes;

	public IList<Beacon> beacons = new List<Beacon>();

}
