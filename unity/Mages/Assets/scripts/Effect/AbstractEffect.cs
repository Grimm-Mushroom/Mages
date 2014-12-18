using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class AbstracteEffect {
	public AbstractInteractive bearer;
	public AbstractInteractive source;

	public abstract EffectType getEffectType ();
	public abstract List<EffectActionTypes> getEffectActionList ();

	public virtual float[] execute(EffectActionTypes[] keys, float[] paramsLis, AbstractInteractive target) { 
		for (int i = 0; i < keys.Length; i++){
			switch (keys[i]){
				case EffectActionTypes.ON_START_CAPTURE :
					onStartCapture(target);	
					break;

				case EffectActionTypes.ON_CAPTURE :
					onCapture(target);
					break;

				case EffectActionTypes.ON_DIE :
					onDie();
					break;

				case EffectActionTypes.ON_START_COMBAT :
					onStartCombat(target);
					break;

				case EffectActionTypes.ON_TAKE_DMG :
					onTakeDmg(target);
					break;

				case EffectActionTypes.ON_ATTACK :
					onAttack(target);
					break;

				case EffectActionTypes.GET_ARMOR :
					paramsLis[i] = getArmor(paramsLis[i]);
					break;
					
				case EffectActionTypes.GET_ATTACK_TIME :
					paramsLis[i] = getAttackTime(paramsLis[i]);
					break;

				case EffectActionTypes.GET_CAPTURE_TIME :
					paramsLis[i] = getCaptureTime(paramsLis[i]);
					break;

				case EffectActionTypes.GET_DMG :
					paramsLis[i] = getDmg(paramsLis[i]);
					break;

			}
		}
		return paramsLis;
	}

	/// <summary>
	/// Ons the start capture.
	/// </summary>
	/// <param name="target">Target.</param>
	public virtual void onStartCapture(AbstractInteractive target){}

	/// <summary>
	/// After capture target
	/// </summary>
	/// <param name="target">Target.</param>
	public virtual void onCapture(AbstractInteractive target){}

	/// <summary>
	/// Ons the die.
	/// </summary>
	public virtual void onDie(){}

	/// <summary>
	/// Ons the start combat.
	/// </summary>
	/// <param name="target">Target - enemy in combat</param>
	public virtual void onStartCombat(AbstractInteractive target){}

	public virtual void onTakeDmg(Object source){}
	public virtual void onAttack(AbstractInteractive target){}

	public virtual float getAttackTime(float attackTime){
		return attackTime;
	}
	public virtual float getCaptureTime(float captureTime){
		return captureTime;
	}
	public virtual float getDmg(float damage){
		return damage;
	}
	public virtual float getArmor(float armor){
		return armor;
	}
}
