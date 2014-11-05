using UnityEngine;
using System.Collections;

public class DeafState: AbstractState {
	
	public DeafState(BasicCreature creature): base(creature) {
		stateName = "Deaf";
	}
	
	public override bool isFinish() {
		return false;
	}
	
	public override void onStartState(AbstractInteractive stateTarget){
		//Запустить анимацию смерти и уничтожать объект
		target = null;
		UnityEngine.Object.Destroy (__creature.creatureObject);
	}
}
