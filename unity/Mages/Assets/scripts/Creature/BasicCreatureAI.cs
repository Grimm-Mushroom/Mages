using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicCreatureAI : AbstractCreatureAI {

	public override void init() {
		base.init();
		AbstractStrategy captureStrategy = new CaptureStrategy (_creature);
		this.addState (captureStrategy);

		AbstractStrategy deafStrategy = new DeafStrategy (_creature);
		this.addState (deafStrategy);

		AbstractStrategy moveStrategy = new MoveStrategy (_creature);
		this.addState (moveStrategy, true);

		AbstractStrategy combatStrategy = new CombatStrategy (_creature);
		this.addState (combatStrategy);

		_init = true;
	}

	public override void changeStrategy(StrategysType strategyType) {
		StrategysType currentStrategyType = _currentStrategy.getStrategyType ();
		if (currentStrategyType == StrategysType.MOVE) {
			_creature.agent.Stop();
		};
		base.changeStrategy (strategyType);
	}

	public override void changeStrategy(AbstractStrategy strategy) {
		StrategysType currentStrategyType = _currentStrategy.getStrategyType ();
		if (currentStrategyType == StrategysType.MOVE) {
			_creature.agent.Stop();
		};
		base.changeStrategy (strategy);
	}

	protected override void setNewStrategy() {
		var batleObject = Physics.OverlapSphere(transform.position, 1.1f);
		bool inCombat = false;
		foreach (var enemy in batleObject) {
			inCombat = __startCombat(enemy) || inCombat;
		}

		if (!inCombat) {
			if (_currentStrategy.getStrategyType () == StrategysType.MOVE) {
					if (_currentStrategy.target != null) {
							_currentStrategy = _allStrategy [StrategysType.CAPTURE];
					} 
			} else {
					_currentStrategy = _allStrategy [StrategysType.MOVE];
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		__startCombat (other);
	}

	protected bool __startCombat(Collider other) {
		BasicCreature enemyCreature = other.GetComponent<BasicCreature>();
		if (enemyCreature != null && _creature.owner != enemyCreature.owner) {
			if (_currentStrategy.getStrategyType () != StrategysType.COMBAT) {
				_target = enemyCreature;
				changeStrategy (StrategysType.COMBAT);
			}
			return true;
		}
		return false;
	}
}
