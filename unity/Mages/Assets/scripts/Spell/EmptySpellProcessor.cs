using UnityEngine;
using System.Collections;

public class EmptySpellProcessor : ISpellProcessor {

	public bool isValid(AbstractCastable target) {
		return false;
	}

	public void allocate(AbstractCastable target) { }

	public void deallocate(AbstractCastable target) { }

	public void cast(AbstractCastable target) { }

}
