using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;

public abstract class AbstractInteractive : MonoBehaviour {

	public Player owner;
	
	public abstract void changeOwner(Player player);

	public PropertyConfig propertyConfig = new PropertyConfig();

	public IDictionary<Type, IEffect> effects = new Dictionary<Type, IEffect>();

	public void addEffect(IEffect effect) {
		effects.Add (effect.GetType(), effect);
	}

	public void removeEffect(IEffect effect) {
		effects.Remove (effect.GetType());
	}

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
	
}
