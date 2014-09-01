using UnityEngine;
using System.Collections;

public class Mooving : MonoBehaviour {

	private NavMeshAgent _agent;
	//private Vector3 _target;
	//private bool _b_target = false;
	private int _step_count = 0;
	public GameObject[] buildings;

	// Use this for initialization
	void Start () {
		_agent = gameObject.GetComponent<NavMeshAgent> ();	
		//_buildings = GameObject.FindGameObjectsWithTag ("Building");
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (_agent.destination, transform.position) < 1.5f) {
			_step_count++;
			if (_step_count == buildings.Length) {
				_step_count = 0;
			}
			_agent.SetDestination(buildings[_step_count].transform.position);
		}

				/*if (Input.GetMouseButtonDown (0)) {
		foreach(GameObject building in buildings) {
		Debug.Log(building.collider.bounds.size);
		}
		Ray _ray;
		RaycastHit _hit;
		_ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(_ray, out _hit, 1000.0f)) {
		_target = _hit.point;
		_b_target = true;
		_agent.SetDestination(_target);
		}
		}*/

	}
}
