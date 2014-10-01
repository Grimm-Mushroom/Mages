using UnityEngine;
using System.Collections;

public class SpawnCreatureSpellProcessor : ISpellProcessor {

	private ISpell spawnCreatureSpell = new SpawnCreatureSpell();
	
	public void allocate(ICastable target) {
		if (target is Beacon) {
			target.allocate(spawnCreatureSpell);
		}

	}
	
	public void deallocate(ICastable target) {
		if (target is Beacon) {
			target.deallocate(spawnCreatureSpell);
		}
	}
	
	public void cast(ICastable target) {
		if (target is Beacon) {
			target.cast(spawnCreatureSpell);
			target.deallocate(spawnCreatureSpell);
		}

		SpellManager.INSTANCE.refresh();
		
	}
}
