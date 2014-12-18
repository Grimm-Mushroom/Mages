using UnityEngine;
using System.Collections;

public class Pitfall : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		other.GetComponent<AbstractCreatureAI>().changeStrategy(StrategysType.DEAF);
	}
}
