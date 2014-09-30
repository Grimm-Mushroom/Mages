using UnityEngine;
using System.Collections;

public interface ICastable {

	void allocate(ISpell action);

	void deallocate(ISpell action);

	void cast(ISpell action);

}
