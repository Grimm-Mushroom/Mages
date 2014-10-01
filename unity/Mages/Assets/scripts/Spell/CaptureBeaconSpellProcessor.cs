using UnityEngine;
using System.Collections;

public class CaptureBeaconSpellProcessor : ISpellProcessor {

	private ISpell captureBeaconSpell = new CaptureBeaconSpell();

	public void allocate(ICastable target) {
		if (target is Beacon) {
			target.allocate(captureBeaconSpell);
		}
	}

	public void deallocate(ICastable target) {
		if (target is Beacon) {
			target.deallocate(captureBeaconSpell);
		}
	}

	public void cast(ICastable target) {
		if (target is Beacon) {
			target.cast(captureBeaconSpell);
		}

		SpellManager.INSTANCE.refresh();

	}

}
