using UnityEngine;
using System.Collections;

public interface ISpellProcessor {

	void allocate(ICastable target);

	void deallocate(ICastable target);

	void cast(ICastable target);

}
