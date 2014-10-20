using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicCreatureAI : MonoBehaviour {

	private Dictionary<string, AbstractState> __allStates;
	private AbstractState __state;
	private BasicCreature __creature;
	private Building __target;
	private bool init;


	
	public void Init() {
		__creature = GetComponent<BasicCreature> ();
		__allStates = new Dictionary<string, AbstractState> ();
		__allStates.Add ("Capture", new CaptureState (__creature));
		__allStates.Add ("Move", new MoveState (__creature));

		__state = __allStates["Move"];
		__state.onStartState(__target);
		__target = __state.target;
		init = true;
	}

	void Update() {
		if (init && __state.isFinish()) {
			__state.onFinishState();
			if (__state.stateName == "Move") {
				if (__state.target != null){
					__state = __allStates["Capture"];
				} 
			} else if (__state.stateName == "Capture") {
				__state = __allStates["Move"];
			}
			__state.onStartState(__target);
			__target = __state.target;
		}
	}


}
