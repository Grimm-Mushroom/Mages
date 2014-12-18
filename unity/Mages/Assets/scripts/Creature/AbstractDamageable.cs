using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractDamageable : AbstractCastable {
	public HealthPoint[] healthPoints;
	public int currentLifeIndex = 0;


	public void addEffectToHealthPoint(AbstracteEffect effect) {
		for (int i = currentLifeIndex; i < healthPoints.Length; i++) {
			if (healthPoints[i].mayGetEffect()) {
				healthPoints[i].effect = effect;
				i = healthPoints.Length;
			}
		}
	}

	public override List<AbstracteEffect> getEffectListByKey(HashSet<EffectActionTypes> keys) {
		List<AbstracteEffect> returnedList = base.getEffectListByKey (keys);
		
		for (int i = currentLifeIndex; i < healthPoints.Length; i++) {
			if ((healthPoints [i].effect != null) &&
			    (keys.Overlaps(healthPoints [i].effect.getEffectActionList()))
			) {
				returnedList.Add(healthPoints [i].effect);
			}
		}
		
		return returnedList;
	}

	private float __onDamage(float damage, Object source) {
		float armor = propertyConfig.armor.getCurrent ();
		// on creature effect
		foreach (AbstracteEffect effect in effects.Values) {
			effect.onTakeDmg(source);
			armor = effect.getArmor(armor);
		}

		//healthPoint effect
		if (healthPoints[currentLifeIndex].effect != null) {
			healthPoints[currentLifeIndex].effect.onTakeDmg(source);
			armor = healthPoints[currentLifeIndex].effect.getArmor(armor);
		}

		if (armor > 0) {
			return damage - armor;
		} else {
			return damage;
		}
	}

	public virtual bool takeDamage(float damage, Object source) {
		float currentDamage = __onDamage(damage, source);

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
