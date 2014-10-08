using UnityEngine;
using System.Collections;

public class MoveState: AbstractState {

	public MoveState(BasicCreature creature): base(creature) {
		stateName = "Move";
	}

	public override bool isFinish() {
		return target == null || Vector3.Distance (__creature.agent.destination, __creature._transform.position) < 0.6f;
	}

	public override void onStartState(Building stateTarget){
		//Найти ближайший маяк и передать его в target	
		target = __findNextBeacon ();
		if(target != null) {
			__creature.agent.SetDestination(
				new Vector3(
				target.transform.position.x,
				target.collider.bounds.size.y + target.transform.position.y,
				target.transform.position.z
				)
			);
		}
	}

	private float pathLength(NavMeshPath path) {
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
	
	private Beacon __findNextBeacon() {
		Beacon minBeacon = null;
		float minLegth = -1;
		NavMeshPath path = new NavMeshPath();

		foreach (Beacon beacon in PlayerManager.INSTANCE.player.beacons) {
			__creature.agent.CalculatePath(beacon.transform.position, path);
			float len = pathLength(path);
			if (len > -1 && minLegth > len || minLegth == -1) {
				minBeacon = beacon;
				minLegth = len;
			}
		}
		return minBeacon;

	}
}
