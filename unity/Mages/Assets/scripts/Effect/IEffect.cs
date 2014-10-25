using UnityEngine;
using System.Collections;

public interface IEffect {

	EffectType getEffectType();
	
	float execute(AbstractInteractive target);

}
