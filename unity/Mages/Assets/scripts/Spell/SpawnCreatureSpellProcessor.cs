using UnityEngine;
using System.Collections;

public class SpawnCreatureSpellProcessor : ISpellProcessor {

	private ISpell spawnCreatureSpell = new SpawnCreatureSpell();

	public bool isValid(AbstractCastable target) {
		return target is Beacon;
	}
	
	public void allocate(AbstractCastable target) {
		spawnCreatureSpell.allocate(target);
	}
	
	public void deallocate(AbstractCastable target) {
		spawnCreatureSpell.deallocate(target);
	}
	
	public void cast(AbstractCastable target) {
		spawnCreatureSpell.cast(target);
		spawnCreatureSpell.deallocate(target);

		SpellManager.INSTANCE.refresh();
		
	}
}
