using UnityEngine;
using System.Collections;

public class CombatStrategy: AbstractStrategy {

	public CombatStrategy(BasicCreature creature) {
		_creature = creature;
	}
	
	public override StrategysType getStrategyType() {
		return StrategysType.COMBAT;
	}
	
	public override bool isFinish() {
		BasicCreature enemy = (BasicCreature) target;
		AbstractStrategy state = enemy.creatureAI.getCurrentStrategy();
		return state.getStrategyType() == StrategysType.DEAF;
	}
	
	public override void onStartState(AbstractInteractive stateTarget){
		target = stateTarget;
		float[] returnedArr = _creature.fireEffect(
			new EffectActionTypes[] {
				EffectActionTypes.ON_START_COMBAT,
				EffectActionTypes.GET_ATTACK_TIME
			}, 
			new float[] {
				0, 
				_creature.propertyConfig.attackTime.getCurrent()
			},
			target
		);
		float attackTime = returnedArr [1];

		// запустить this.__captureBuilding через _creature.captureTime сек. 
		Timer.Instance.StartCoroutine(
			Timer.Instance.TimerStart(attackTime, __attackTarget)
		);
	}

	private void  __attackTarget() {
		BasicCreature enemy = (BasicCreature) target;

		float[] returnedArr = _creature.fireEffect(
			new EffectActionTypes[] {
				EffectActionTypes.ON_ATTACK, 
				EffectActionTypes.GET_ATTACK_TIME, 
				EffectActionTypes.GET_DMG
			}, 
			new float[] {
				0, 
				_creature.propertyConfig.attackTime.getCurrent(),
				_creature.propertyConfig.damage.getCurrent(),
			},
			target
		);
		float attackTime = returnedArr [1];
		float damage = returnedArr [2];

		if (_creature.creatureAI.getCurrentStrategy().getStrategyType() == StrategysType.COMBAT) {
			if (enemy.takeDamage (damage, this._creature)) {
				Timer.Instance.StartCoroutine (
					Timer.Instance.TimerStart (attackTime, __attackTarget)
				);
			} else {
				enemy.creatureAI.changeStrategy (StrategysType.DEAF);
			}
		}
	}
}
