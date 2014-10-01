using UnityEngine;
using System.Collections;

public abstract class AbstractCastable : MonoBehaviour, ICastable {

	void OnMouseUpAsButton() {
		SpellManager.INSTANCE.spellProcessor.cast(this);
	}
	
	void OnMouseEnter() {
		SpellManager.INSTANCE.spellProcessor.allocate(this);
	}
	
	void OnMouseExit() {
		SpellManager.INSTANCE.spellProcessor.deallocate(this);
	}
	
	public void cast(ISpell spell) {
		spell.cast(this);
	}
	
	public void allocate(ISpell spell) {
		spell.allocate(this);
	}
	
	public void deallocate(ISpell spell) {
		spell.deallocate(this);
	}

}
