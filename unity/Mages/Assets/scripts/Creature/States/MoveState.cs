using UnityEngine;
using System.Collections;

public class MoveState: AbstractState {

	public MoveState(BasicCreature creature): base(creature) {
		stateName = "Move";
	}

	public override bool isFinish() {
		if (target != null && target.owner == _creature.owner) {
			target = null;
			_creature.agent.ResetPath();
		}
		return target == null || Vector3.Distance (_creature.agent.destination, _creature._transform.position) < 0.6f;
	}

	public override void onStartState(AbstractInteractive stateTarget){
		//Найти ближайший маяк и передать его в target	
		target = __findNextBeacon ();
		if(target != null) {
			_creature.agent.SetDestination(
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
		Player enemy;
		if (_creature.owner == PlayerManager.INSTANCE.player) {
			enemy = PlayerManager.INSTANCE.enemy;
		} else {
			enemy = PlayerManager.INSTANCE.player;
		}

		foreach (Beacon beacon in enemy.beacons) {
			_creature.agent.CalculatePath(beacon.transform.position, path);
			float len = _creature.pathLength(path);
			if (len > -1 && minLegth > len || minLegth == -1) {
				minBeacon = beacon;
				minLegth = len;
			}
		}
		return minBeacon;

	}
}
