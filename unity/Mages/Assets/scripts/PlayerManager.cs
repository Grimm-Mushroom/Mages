using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager _instance;
	
	public static PlayerManager Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<PlayerManager>();;
			}
			return _instance;
		} 
	}

	public Player player, enemy, nobody;

}
