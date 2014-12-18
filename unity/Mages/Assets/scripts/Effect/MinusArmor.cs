using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinusArmor : AbstracteEffect {

	public float amount = 5.0f;
	
	public override float getArmor(float armor) {
		return armor - amount;
	} 

	public override EffectType getEffectType() {
		return EffectType.MINUS_ARMOR;
	}

	public override List<EffectActionTypes> getEffectActionList() {
		List<EffectActionTypes> keysList = new List<EffectActionTypes> ();
		keysList.Add (EffectActionTypes.GET_ARMOR);
		return keysList;
	}

}
