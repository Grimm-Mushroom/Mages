using UnityEngine;
using System.Collections;

public class CaptureBeaconSpellProcessor : ISpellProcessor {

	private ISpell captureBeaconSpell = new CaptureBeaconSpell ();

	public void allocate (ICastable target) {
		target.allocate(captureBeaconSpell);
	}

	public void deallocate (ICastable target) {
		target.deallocate(captureBeaconSpell);
	}

	public void cast(ICastable target) {

		target.cast (captureBeaconSpell);

		SpellManager.Instance.refresh();

	}

}
