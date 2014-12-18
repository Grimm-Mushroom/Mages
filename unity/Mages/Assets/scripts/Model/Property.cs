using UnityEngine;
using System.Collections;

[System.Serializable]
public class Property {

	public float basic;

	public float bonus;

	public float getCurrent() {
		return basic + bonus;
	}

	public Property(float basic, float bonus) {
		this.basic = basic;
		this.bonus = bonus;
	}

}
