using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractCreatureAI : MonoBehaviour {

	protected Dictionary<StrategysType, AbstractStrategy> _allStrategy;
	protected AbstractStrategy _currentStrategy;
	protected BasicCreature _creature;
	protected AbstractInteractive _target;
	protected bool _init;
	
	public virtual void init() {
		_creature = GetComponent<BasicCreature> ();
		_allStrategy = new Dictionary<StrategysType, AbstractStrategy> ();
	}

	//прерывание и смена состояния
	public virtual  void changeStrategy (AbstractStrategy startegy) {
		_currentStrategy = startegy;
		_currentStrategy.onStartState(_target);
		_target = _currentStrategy.target;
	}

	//прерывание и смена состояния
	public virtual void changeStrategy (StrategysType strategyType) {
		if (_allStrategy.ContainsKey(strategyType)) {
			_currentStrategy = _allStrategy[strategyType];
			_currentStrategy.onStartState(_target);
			_target = _currentStrategy.target;
		}
	}

	public void addState(AbstractStrategy strategy, bool mainState = false) {
		_allStrategy.Add (strategy.getStrategyType(), strategy);
		 
		if (mainState) {
			_currentStrategy = strategy;
			_currentStrategy.onStartState(_target);
			_target = _currentStrategy.target;
		}
	}

	public AbstractStrategy getCurrentStrategy() {
		return _currentStrategy;
	}

	//определение следующего состояния
	protected abstract void setNewStrategy ();

	void FixedUpdate () {
		if (_init && _currentStrategy.isFinish()) {
			_currentStrategy.onFinishState();
			setNewStrategy();

			_currentStrategy.onStartState(_target);
			_target = _currentStrategy.target;
		}
	}
}
	