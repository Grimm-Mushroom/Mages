using UnityEngine;
using System.Collections;

public class StunStrategy: AbstractStrategy {
	private bool __stunned = true;
	private float __stuneTime;

	private void __stunEnd() {
		__stunned = false;
	}

	public StunStrategy(BasicCreature creature, float stunTime) {
		_creature = creature;
		__stuneTime = stunTime;
	}

	public override StrategysType getStrategyType() {
		return StrategysType.STUN;
	}

	public override void onFinishState() {
		_creature.renderer.material.color = _creature.owner.color;
	}

	public override bool isFinish() {
		return !__stunned;
	}
	
	public override void onStartState(AbstractInteractive stateTarget){
		target = null;
		_creature.renderer.material.color = Color.blue;
		Timer.Instance.StartCoroutine(Timer.Instance.TimerStart(__stuneTime, __stunEnd));
	}
}
