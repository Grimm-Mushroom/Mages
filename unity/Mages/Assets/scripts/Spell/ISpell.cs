using UnityEngine;
using System.Collections;

public interface ISpell {

	void allocate (MonoBehaviour target);

	void deallocate (MonoBehaviour target);

	void cast (MonoBehaviour target);

}
