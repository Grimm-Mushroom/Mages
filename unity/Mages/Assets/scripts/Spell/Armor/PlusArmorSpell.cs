using UnityEngine;
using System.Collections;

public class PlusArmorSpell : ISpell {

	public void allocate(AbstractCastable target) {
	
		AbstractInteractive interactive = (AbstractInteractive) target;

		interactive.renderer.material.color = Color.blue;

	}

	public void deallocate(AbstractCastable target) {

		AbstractInteractive interactive = (AbstractInteractive) target;
		
		interactive.renderer.material.color = interactive.owner.color;
		
	}

	public void cast(AbstractCastable target) {

		PlusArmor plus = new PlusArmor ();
		plus.source = target;
		target.addEffect (plus);

	}


}
