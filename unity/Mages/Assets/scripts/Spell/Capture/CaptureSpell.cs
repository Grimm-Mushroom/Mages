using UnityEngine;
using System.Collections;

public class CaptureSpell : ISpell {

	public void allocate(AbstractCastable target) {
	
		//Building beacon = (Building) target;

		target.renderer.material.color = Color.blue;

	}

	public void deallocate(AbstractCastable target) {
		
		//Building beacon = (Building) target;

		target.renderer.material.color = target.owner.color;
		
	}

	public void cast(AbstractCastable target) {

		//Building building = (Building) target;

		if (target.owner == PlayerManager.INSTANCE.nobody) {
			target.changeOwner(PlayerManager.INSTANCE.player);
		} else {
			target.changeOwner(PlayerManager.INSTANCE.nobody);
		}


	}


}
