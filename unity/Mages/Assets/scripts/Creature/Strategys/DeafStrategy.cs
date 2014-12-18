using UnityEngine;
using System.Collections;

public class DeafStrategy: AbstractStrategy {

	public DeafStrategy(BasicCreature creature) {
		_creature = creature;
	}

	public override StrategysType getStrategyType() {
		return StrategysType.DEAF;
	}
	
	public override bool isFinish() {
		return false;
	}
	
	public override void onStartState(AbstractInteractive stateTarget){
		_creature.fireEffect(
			new EffectActionTypes[] {EffectActionTypes.ON_DIE}, 
			new float[] {0},
			null
		);
		target = null;
		UnityEngine.Object.Destroy (_creature.creatureObject);
	}
}
