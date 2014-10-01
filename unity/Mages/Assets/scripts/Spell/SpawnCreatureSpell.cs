using UnityEngine;
using System.Collections;

public class SpawnCreatureSpell : ISpell {

	public void allocate(AbstractCastable target) {

		Beacon beacon = (Beacon) target;
		
		beacon.renderer.material.color = Color.blue;

	}
	
	public void deallocate(AbstractCastable target) {
	
		Beacon beacon = (Beacon) target;
		
		beacon.renderer.material.color = beacon.owner.color;
	
	}
	
	public void cast(AbstractCastable target) {
		
		Beacon beacon = (Beacon) target;
		
		Beacon.Instantiate(
			beacon.owner.creatureTypes[0], 
			new Vector3(
			beacon.transform.position.x,
			beacon.collider.bounds.size.y + beacon.transform.position.y + 0.5f,
			beacon.transform.position.z
			),
			Quaternion.identity);
		
	}

}
