using UnityEngine;
using System.Collections;

public class MoveState: AbstractState {

	public MoveState(BasicCreature creature): base(creature) {
		stateName = "Move";
	}

	public override bool isFinish() {
		if (target != null && target.owner == __creature.owner) {
			target = null;
			__creature.agent.ResetPath();
		}
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

	
	private Beacon __findNextBeacon() {
		Beacon minBeacon = null;
		float minLegth = -1;
		NavMeshPath path = new NavMeshPath();

		foreach (Beacon beacon in __creature.enemy.beacons) {
			__creature.agent.CalculatePath(beacon.transform.position, path);
			float len = __creature.pathLength(path);
			if (len > -1 && minLegth > len || minLegth == -1) {
				minBeacon = beacon;
				minLegth = len;
			}
		}
		return minBeacon;

	}
}
