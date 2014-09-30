using UnityEngine;
using System.Collections;

public class CaptureBeaconSpell : ISpell {

	public void allocate(MonoBehaviour target) {
	
		Beacon beacon = (Beacon)target;

		beacon.renderer.material.color = Color.blue;

	}

	public void deallocate(MonoBehaviour target) {
		
		Beacon beacon = (Beacon)target;
		
		beacon.renderer.material.color = beacon.owner.color;
		
	}

	public void cast(MonoBehaviour target) {

		Beacon beacon = (Beacon)target;

		RaycastHit _hit;
		Ray _ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit, 1000.0f)) {
			if (_hit.collider.gameObject == beacon.gameObject) {
				if (beacon.owner == PlayerManager.Instance.nobody) {
					beacon.ChangeOwner(PlayerManager.Instance.player);
				} else {
					beacon.ChangeOwner(PlayerManager.Instance.nobody);
				}
			}
		}

	}


}
