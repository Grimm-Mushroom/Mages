using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicCreatureAI : AbstractCreatureAI {

	public override void init() {
		base.init();
		AbstractState captureState = new CaptureState (_creature);
		this.addState (captureState);

		AbstractState deafState = new DeafState (_creature);
		this.addState (deafState);

		AbstractState moveState = new MoveState (_creature);
		this.addState (moveState, true);

		AbstractState combatState = new CombatState (_creature);
		this.addState (combatState);

		_init = true;
	}

	public override void changeState(string stateName) {
		if (_state.stateName == "Move") {
			_creature.agent.Stop();
		}
		base.changeState (stateName);
	}

	protected override void setNewState() {
		if (_state.stateName == "Move") {
			if (_state.target != null){
				_state = _allStates["Capture"];
			} 
		} else {
			_state = _allStates["Move"];
		}
	}

	void OnTriggerEnter(Collider other) {
		BasicCreature enemyCreature = other.GetComponent<BasicCreature>();
		if (enemyCreature != null && _creature.owner != enemyCreature.owner) {
			_target = enemyCreature;
			if (_state.stateName != "Combat") {
				this.changeState ("Combat");
			}
		}
	}
}
