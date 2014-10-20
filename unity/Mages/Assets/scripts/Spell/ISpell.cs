using UnityEngine;
using System.Collections;

public interface ISpell {

	void allocate(AbstractCastable target);

	void deallocate(AbstractCastable target);

	void cast(AbstractCastable target);

}
