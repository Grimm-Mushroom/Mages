using UnityEngine;
using System.Collections;

public class PlusArmorSpellProcessor : ISpellProcessor {

	private ISpell plusArmorSpell = new PlusArmorSpell();

	public bool isValid(AbstractCastable target) {
		return target is AbstractDamageable;
	}

	public void allocate(AbstractCastable target) {
		plusArmorSpell.allocate(target);
	}

	public void deallocate(AbstractCastable target) {
		plusArmorSpell.deallocate(target);
	}

	public void cast(AbstractCastable target) {
		plusArmorSpell.cast(target);
		plusArmorSpell.deallocate(target);

		SpellManager.INSTANCE.refresh();

	}

}
