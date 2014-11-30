using UnityEngine;
using System.Collections;

public abstract class AbstractState {
	private AbstractInteractive __target;
	public AbstractInteractive target {
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

	protected BasicCreature _creature;

	public AbstractState(BasicCreature creature) {
		_creature = creature;
	}

	public abstract bool isFinish();

	public virtual void onStartState(AbstractInteractive stateTarget) {
		target = stateTarget;
	}

	public virtual void onFinishState() {}
}
