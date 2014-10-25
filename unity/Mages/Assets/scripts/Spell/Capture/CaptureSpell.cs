using UnityEngine;
using System.Collections;

public class CaptureSpell : ISpell {

	public void allocate(AbstractCastable target) {
	
		Building beacon = (Building) target;

		beacon.renderer.material.color = Color.blue;

	}

	public void deallocate(AbstractCastable target) {
		
		Building beacon = (Building) target;

		beacon.renderer.material.color = beacon.owner.color;
		
	}

	public void cast(AbstractCastable target) {

		Building building = (Building) target;

		if (building.owner == PlayerManager.INSTANCE.nobody) {
			building.changeOwner(PlayerManager.INSTANCE.player);
		} else {
			building.changeOwner(PlayerManager.INSTANCE.nobody);
		}


	}


}
