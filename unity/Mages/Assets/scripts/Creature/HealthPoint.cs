using UnityEngine;
using System.Collections;

[System.Serializable]
public class HealthPoint {

	public bool status = true;

	public HealthPoint(float healthValue) {
		health = healthValue;
	}

	public bool mayGetEffect() {
		return effect == null && status;
	}

	private AbstracteEffect __effect = null ;
	public AbstracteEffect effect {
		get {
			return __effect;
		}
		set {
			if (__effect == null) {
				__effect = value;
			} 
		}
	}

	[SerializeField]
	private float __health;
	public float health {
		get {
			return __health;
		}
		set {
			if (value <= 0) {
				status = false;
				if (__effect != null) {
					__effect.onDie();
				}
			}
			__health = value;
		} 
	}
}
