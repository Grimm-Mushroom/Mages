using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;

public abstract class AbstractInteractive : MonoBehaviour {

	public Player owner;
	
	public abstract void changeOwner(Player player);

	public PropertyConfig propertyConfig = new PropertyConfig();

	public IDictionary<Type, AbstracteEffect> effects = new Dictionary<Type, AbstracteEffect>();


	public virtual List<AbstracteEffect> getEffectListByKey(HashSet<EffectActionTypes> keys) {
		List<AbstracteEffect> returnedList = new List<AbstracteEffect> ();

		foreach (AbstracteEffect effect in effects.Values) {
			if (keys.Overlaps(effect.getEffectActionList())) {
				returnedList.Add(effect);
			}
		}
		return returnedList;
	}


	public float[] fireEffect(EffectActionTypes[] keys, float[] paramList, AbstractInteractive target) {
		List<AbstracteEffect> effectList = getEffectListByKey(new HashSet<EffectActionTypes>(keys));

		foreach (AbstracteEffect effect in effectList) {
			paramList = effect.execute(keys, paramList, target);
		}
		return paramList;
	}


	public void addEffect(AbstracteEffect effect) {
		effects.Add (effect.GetType(), effect);
	}

	public void removeEffect(AbstracteEffect effect) {
		effects.Remove (effect.GetType());
	}


}
