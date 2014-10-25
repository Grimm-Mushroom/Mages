using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicCreature : AbstractCastable {

	public NavMeshAgent agent;
	public Transform _transform;

	public float captureTime = 3.0f;

	void Start() {

		agent = gameObject.GetComponent<NavMeshAgent> ();	
		_transform = gameObject.GetComponent<Transform> ();	

		BasicCreatureAI ai = GetComponent<BasicCreatureAI> ();
		ai.Init ();
	}

	public float pathLength(NavMeshPath path) {
		if (path.corners.Length < 2)
			return -1;
		
		Vector3 previousCorner = path.corners[0];
		float lengthSoFar = 0.0F;
		int i = 1;
		while (i < path.corners.Length) {
			Vector3 currentCorner = path.corners[i];
			lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
			previousCorner = currentCorner;
			i++;
		}
		return lengthSoFar;
	}

	override public void changeOwner(Player player) {
		this.owner = player;
		changeOwnerAnim (player);
	}

	private void changeOwnerAnim(Player owner) {
		renderer.material.color = owner.color;
	}

}
