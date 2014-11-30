using UnityEngine;
using System.Collections;

public class HealthPoint {



	public bool status = true;

	public HealthPoint(float healthValue) {
		health = healthValue;
	}

	private IEffect __effect = null ;
	public IEffect effect {
		get {
			return __effect;
		}
		set {
			if (__effect == null) {
				__effect = value;
			} 
		}
	}

	private float __health;
	public float health {
		get {
			return __health;
		}
		set {
			if (value <= 0) {
				status = false;
			}
			__health = value;
		} 
	}

}
