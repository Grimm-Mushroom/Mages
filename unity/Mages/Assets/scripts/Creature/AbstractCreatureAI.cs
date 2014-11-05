using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractCreatureAI : MonoBehaviour {

	protected Dictionary<string, AbstractState> _allStates;
	protected AbstractState _state;
	protected BasicCreature _creature;
	protected AbstractInteractive _target;
	protected bool _init;

	
	public virtual void init() {
		_creature = GetComponent<BasicCreature> ();
		_allStates = new Dictionary<string, AbstractState> ();
	}

	//прерывание и смена состояния
	public virtual void changeState (string stateName) {
		if (_allStates.ContainsKey(stateName)) {
			_state = _allStates[stateName];
			_state.onStartState(_target);
			_target = _state.target;
		}
	}

	public void addState(AbstractState state, bool mainState = false) {
		_allStates.Add (state.stateName, state);
		 
		if (mainState) {
			_state = state;
			_state.onStartState(_target);
			_target = _state.target;
		}
	}

	public AbstractState getState() {
		return _state;
	}

	//определение следующего состояния
	protected abstract void setNewState ();

	void Update() {
		if (_init && _state.isFinish()) {
			_state.onFinishState();
			setNewState();

			_state.onStartState(_target);
			_target = _state.target;
		}
	}
}
	