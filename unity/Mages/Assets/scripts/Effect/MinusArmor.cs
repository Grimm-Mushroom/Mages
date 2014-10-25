using UnityEngine;
using System.Collections;

public class MinusArmor : IEffect {

	public AbstractInteractive source;
	
	public float amount = 5.0f;
	
	public float execute(AbstractInteractive target) {
		return source.propertyConfig.armor.basic - amount;
	}

	public EffectType getEffectType() {
		return EffectType.MINUS_ARMOR;
	}

}
