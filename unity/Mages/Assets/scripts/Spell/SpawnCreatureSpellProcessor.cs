using UnityEngine;
using System.Collections;

public class SpawnCreatureSpellProcessor : ISpellProcessor {

	private ISpell spawnCreatureSpell = new SpawnCreatureSpell ();
	
	public void allocate (ICastable target) {
		target.allocate(spawnCreatureSpell);
	}
	
	public void deallocate (ICastable target) {
		target.deallocate(spawnCreatureSpell);
	}
	
	public void cast(ICastable target) {
		
		target.cast (spawnCreatureSpell);
		target.deallocate (spawnCreatureSpell);
		
		SpellManager.Instance.refresh();
		
	}
}
