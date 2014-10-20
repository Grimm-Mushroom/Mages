using UnityEngine;
using System.Collections;

public class CaptureSpellProcessor : ISpellProcessor {

	private ISpell captureSpell = new CaptureSpell();

	public bool isValid(AbstractCastable target) {
		return target is Building;
	}

	public void allocate(AbstractCastable target) {
		captureSpell.allocate(target);
	}

	public void deallocate(AbstractCastable target) {
		captureSpell.deallocate(target);
	}

	public void cast(AbstractCastable target) {
		captureSpell.cast(target);

		SpellManager.INSTANCE.refresh();

	}

}
