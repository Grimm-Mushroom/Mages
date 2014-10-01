using UnityEngine;
using System.Collections;

public class SpawnCreatureSpell : ISpell {

	public void allocate(MonoBehaviour target) {

		Beacon beacon = (Beacon) target;
		
		beacon.renderer.material.color = Color.blue;

	}
	
	public void deallocate(MonoBehaviour target) {
	
		Beacon beacon = (Beacon) target;
		
		beacon.renderer.material.color = beacon.owner.color;
	
	}
	
	public void cast(MonoBehaviour target) {
		
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
