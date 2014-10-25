using UnityEngine;
using System.Collections;

public abstract class AbstractCastable : AbstractInteractive {

	void OnMouseUpAsButton() {
		ISpellProcessor spellProcessor = SpellManager.INSTANCE.spellProcessor;
		if (spellProcessor.isValid(this)) {
			spellProcessor.cast(this);
		}
	}
	
	void OnMouseEnter() {
		ISpellProcessor spellProcessor = SpellManager.INSTANCE.spellProcessor;
		if (spellProcessor.isValid(this)) {
			spellProcessor.allocate(this);
		}
	}
	
	void OnMouseExit() {
		ISpellProcessor spellProcessor = SpellManager.INSTANCE.spellProcessor;
		if (spellProcessor.isValid(this)) {
			spellProcessor.deallocate(this);
		}
	}

}
