using UnityEngine;
using System.Collections;

public class Mooving : MonoBehaviour {
	private NavMeshAgent _agent;
<<<<<<< HEAD
	private Vector3 _target;
	private bool _b_target = false;
=======
	//private Vector3 _target;
	//private bool _b_target = false;
	private int _step_count = 0;

	public GameObject[] buildings;



>>>>>>> 8b734461d2721e1419a150b5ac490b768f6a851a

	// Use this for initialization
	void Start () {
		_agent = gameObject.GetComponent<NavMeshAgent> ();	
<<<<<<< HEAD
=======
		//_buildings = GameObject.FindGameObjectsWithTag ("Building");
>>>>>>> 8b734461d2721e1419a150b5ac490b768f6a851a
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (Input.GetMouseButtonDown (0)) {
=======
		if (Vector3.Distance (_agent.destination, transform.position) < 1.5f) {
			_step_count++;
			if (_step_count == 6) {
				_step_count = 0;
			}
			_agent.SetDestination(buildings[_step_count].transform.position);
		}

		/*if (Input.GetMouseButtonDown (0)) {
			foreach(GameObject building in buildings) {
				Debug.Log(building.collider.bounds.size);
			}
>>>>>>> 8b734461d2721e1419a150b5ac490b768f6a851a
			Ray _ray;
			RaycastHit _hit;

			_ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(_ray, out _hit, 1000.0f)) {
				_target = _hit.point;
				_b_target = true;
<<<<<<< HEAD
			}
		}

		if (_b_target) {
			if(Vector3.Distance(_target, transform.position) > 1.5f) {
				_agent.SetDestination(_target);
			} else {
				_agent.Stop();
			}
		}
=======
				_agent.SetDestination(_target);
			}
		}*/


>>>>>>> 8b734461d2721e1419a150b5ac490b768f6a851a
	}
}
