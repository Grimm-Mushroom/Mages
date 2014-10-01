using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private static PlayerManager instance;
	
	public static PlayerManager INSTANCE {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<PlayerManager>();;
			}
			return instance;
		} 
	}

	public Player player, enemy, nobody;

}
