using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaptureStrategy: AbstractStrategy {

	public CaptureStrategy(BasicCreature creature) {
		_creature = creature;
	}

	public override StrategysType getStrategyType() {
		return StrategysType.CAPTURE;
	}

	public override bool isFinish() {
		return _creature.owner == target.owner;
	}

	public override void onStartState(AbstractInteractive strategyTarget){		
		target = strategyTarget;

		float[] returnedArr = _creature.fireEffect(
			new EffectActionTypes[] {EffectActionTypes.ON_START_CAPTURE, EffectActionTypes.GET_CAPTURE_TIME}, 
			new float[] {0, _creature.propertyConfig.captureTime.getCurrent()},
			target
		);
		float captureTime = returnedArr [1];

		// запустить this.__captureBuilding через _creature.captureTime сек. 
		Timer.Instance.StartCoroutine(Timer.Instance.TimerStart(captureTime, __captureBuilding));
	}

	private void  __captureBuilding() {
		if (target != null) {
			target.changeOwner (_creature.owner);
			_creature.fireEffect (
				new EffectActionTypes[] {EffectActionTypes.ON_CAPTURE}, 
				new float[] {0},
				target
			);
		}
	}
}
