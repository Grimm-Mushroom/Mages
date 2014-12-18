using UnityEngine;
using System.Collections;

public class MinusArmorSpell : ISpell {
	
	public void allocate(AbstractCastable target) {
		
		AbstractInteractive interactive = (AbstractInteractive) target;
		
		interactive.renderer.material.color = Color.blue;
		
	}
	
	public void deallocate(AbstractCastable target) {
		
		AbstractInteractive interactive = (AbstractInteractive) target;
		
		interactive.renderer.material.color = interactive.owner.color;
		
	}
	
	public void cast(AbstractCastable target) {
		
		MinusArmor minus = new MinusArmor ();
		minus.bearer = target;
		AbstractDamageable creature = (AbstractDamageable) target;
		creature.addEffectToHealthPoint (minus);
		
	}
	
	
}
