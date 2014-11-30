using UnityEngine;
using System.Collections;

public class CombatState: AbstractState {
	
	public CombatState(BasicCreature creature): base(creature) {
		stateName = "Combat";
	}
	
	public override bool isFinish() {
		BasicCreature enemy = (BasicCreature) target;
		AbstractState state = enemy.creatureAI.getState();
		return state.stateName == "Deaf";
	}
	
	public override void onStartState(AbstractInteractive stateTarget){
		base.onStartState (stateTarget);
		// запустить this.__captureBuilding через _creature.captureTime сек. 
		Timer.Instance.StartCoroutine(
			Timer.Instance.TimerStart(_creature.propertyConfig.attackTime.basic, __attackTarget)
		);
	}

	private void  __attackTarget() {
		BasicCreature enemy = (BasicCreature)target;
		if (_creature.creatureAI.getState ().stateName == stateName) {
				if (enemy.takeDamage (_creature.propertyConfig.damage.getCurrent ())) {
						Timer.Instance.StartCoroutine (
			Timer.Instance.TimerStart (_creature.propertyConfig.attackTime.basic, __attackTarget)
						);
				} else {
						enemy.creatureAI.changeState ("Deaf");
				}
		}
	}
}
