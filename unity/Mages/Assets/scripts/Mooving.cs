using UnityEngine;
using System.Collections;

public class Mooving : MonoBehaviour {
	private NavMeshAgent _agent;
	private Vector3 _target;
	private bool _b_target = false;

	// Use this for initialization
	void Start () {
		_agent = gameObject.GetComponent<NavMeshAgent> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray _ray;
			RaycastHit _hit;

			_ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(_ray, out _hit, 1000.0f)) {
				_target = _hit.point;
				_b_target = true;
			}
		}

		if (_b_target) {
			if(Vector3.Distance(_target, transform.position) > 1.5f) {
				_agent.SetDestination(_target);
			} else {
				_agent.Stop();
			}
		}
	}
}
