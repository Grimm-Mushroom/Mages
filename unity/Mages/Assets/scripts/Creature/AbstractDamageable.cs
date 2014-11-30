using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractDamageable : AbstractCastable {
	public HealthPoint[] healthPoints;
	public int currentLifeIndex = 0;

	public float onDamage(float damage) {
		float armor = propertyConfig.armor.getCurrent ();
		// по эффектам существа
		foreach (IEffect effect in effects.Values) {
			if ((effect.getEffectType() == EffectType.PLUS_ARMOR) ||
			    (effect.getEffectType() == EffectType.MINUS_ARMOR)) {
				armor += effect.execute(null);
			}
		}
		// по эффектам точек жизни
		foreach (HealthPoint healthPoint in healthPoints) {
			if ((healthPoint.effect != null) && (
					(healthPoint.effect.getEffectType() == EffectType.PLUS_ARMOR) ||
			    	(healthPoint.effect.getEffectType() == EffectType.MINUS_ARMOR)
				)
			) {
				armor += healthPoint.effect.execute(null);
			}
		}
		if (armor > 0) {
			return damage - armor;
		} else {
			return damage;
		}
	}

	public virtual bool takeDamage(float damage) {
		float currentDamage = onDamage(damage);

		while ((currentDamage > 0) && (currentLifeIndex < healthPoints.Length)) {
			healthPoints [currentLifeIndex].health -= currentDamage;
			currentDamage = -healthPoints [currentLifeIndex].health;

			if (!healthPoints [currentLifeIndex].status) {
				currentLifeIndex++;
			}
		}

		return currentLifeIndex < healthPoints.Length;
	}
}
