using UnityEngine;
using System.Collections;

public abstract class AbstractState {
	private Building __target;
	public Building target {
		get {
			return __target;
		}
		set {
			__target = value;
		}
	}

	private string __name;
	public string stateName {
		get {
			return __name;
		}
		set {
			__name = value;
		}
	}

	protected BasicCreature __creature;

	public AbstractState(BasicCreature creature) {
		__creature = creature;
	}

	public abstract bool isFinish();

	public virtual void onStartState(Building stateTarget) {
		target = stateTarget;
	}

	public virtual void onFinishState() {}
}
