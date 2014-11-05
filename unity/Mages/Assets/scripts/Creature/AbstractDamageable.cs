using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractDamageable : AbstractCastable {
	public float healthPoint = 150.0f;


	public void onDamage(float damage) {
		float armor = 0.0f;
		foreach (IEffect effect in effects.Values) {
			if (effect.getEffectType() == EffectType.PLUS_ARMOR) {
				armor += effect.execute(null);
			}
			if (effect.getEffectType() == EffectType.MINUS_ARMOR) {
				armor -= effect.execute(null);
			}
		}
	}

	public virtual bool takeDamage(float damage) {
		healthPoint -= damage - propertyConfig.armor.getCurrent();
		return healthPoint > 0.0f;
	}
}
