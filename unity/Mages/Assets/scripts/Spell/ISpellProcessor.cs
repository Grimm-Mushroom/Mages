using UnityEngine;
using System.Collections;

public interface ISpellProcessor {

	bool isValid(AbstractCastable target);

	void allocate(AbstractCastable target);

	void deallocate(AbstractCastable target);

	void cast(AbstractCastable target);

}
