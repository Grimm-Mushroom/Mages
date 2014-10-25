using UnityEngine;
using System.Collections;

public class MinusArmorSpellProcessor : ISpellProcessor {
	
	private ISpell minusArmorSpell = new MinusArmorSpell();
	
	public bool isValid(AbstractCastable target) {
		return target is AbstractInteractive;
	}
	
	public void allocate(AbstractCastable target) {
		minusArmorSpell.allocate(target);
	}
	
	public void deallocate(AbstractCastable target) {
		minusArmorSpell.deallocate(target);
	}
	
	public void cast(AbstractCastable target) {
		minusArmorSpell.cast(target);
		minusArmorSpell.deallocate(target);
		
		SpellManager.INSTANCE.refresh();
		
	}
	
}
