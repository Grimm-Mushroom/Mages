using UnityEngine;
using System.Collections;

public abstract class AbstractStrategy {
	protected BasicCreature _creature;

	private AbstractInteractive __target;
	public AbstractInteractive target {
		get {
			return __target;
		}
		set {
			__target = value;
		}
	}

	public abstract StrategysType getStrategyType ();
	
	public abstract bool isFinish();

	public virtual void onStartState(AbstractInteractive stateTarget) {}

	public virtual void onFinishState() {}
}
