using UnityEngine;
using System.Collections;

public class CaptureState: AbstractState {

	public CaptureState(BasicCreature creature): base(creature) {
		stateName = "Capture";
	}

	public override bool isFinish() {
		return __creature.owner == target.owner;
	}

	public override void onStartState(AbstractInteractive stateTarget){
		base.onStartState (stateTarget);
		// запустить this.__captureBuilding через _creature.captureTime сек. 
		Timer.Instance.StartCoroutine(Timer.Instance.TimerStart(
			__creature.propertyConfig.captureTime.basic, __captureBuilding)
		);
	}

	private void  __captureBuilding() {
		target.changeOwner (__creature.owner);
	}
}
