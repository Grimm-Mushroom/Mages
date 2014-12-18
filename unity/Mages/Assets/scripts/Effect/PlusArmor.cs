using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlusArmor : AbstracteEffect {

	public float amount = 5.0f;
	public float stunTime = 1.0f;
	public float stunChance = 0.1f;
	
	public override float getArmor(float armor) {
		return armor + amount;
	} 
	
	public override EffectType getEffectType() {
		return EffectType.PLUS_ARMOR;
	}

	public override void onAttack(AbstractInteractive target){
		BasicCreature combatEnemy = (BasicCreature)target;
		if (Random.Range(0.0f, 1.0f) < stunChance) {
			 
			StunStrategy stun = new StunStrategy (combatEnemy, stunTime);
			combatEnemy.creatureAI.changeStrategy(stun);
		}
	}

	public override List<EffectActionTypes> getEffectActionList() {
		List<EffectActionTypes> keysList = new List<EffectActionTypes> ();
		keysList.Add (EffectActionTypes.GET_ARMOR);
		keysList.Add (EffectActionTypes.ON_ATTACK);
		return keysList;
	}
	
}
