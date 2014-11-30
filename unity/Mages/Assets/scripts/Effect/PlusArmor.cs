using UnityEngine;
using System.Collections;

public class PlusArmor : IEffect {

	public AbstractInteractive source;
	
	public float amount = 5.0f;
	
	public float execute(AbstractInteractive target) {
		return  + amount;
	}

	public EffectType getEffectType() {
		return EffectType.PLUS_ARMOR;
	}
	
}
