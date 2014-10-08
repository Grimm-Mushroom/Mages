using UnityEngine;
using System.Collections;

public class BasicCreature : MonoBehaviour {
	public NavMeshAgent agent;
	public Transform _transform;
	public Player owner;

	public float captureTime = 3.0f;

	void Start() {
		owner = PlayerManager.INSTANCE.enemy;
		agent = gameObject.GetComponent<NavMeshAgent> ();	
		_transform = gameObject.GetComponent<Transform> ();	

		BasicCreatureAI ai = GetComponent<BasicCreatureAI> ();
		ai.Init ();
	}
}
