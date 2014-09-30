using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour {
	
	private static SpellManager _instance;

	public static SpellManager Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<SpellManager>();;
			}
			return _instance;
		} 
	}

	public readonly static ISpellProcessor emptySpellProcessor = new EmptySpellProcessor ();

	public ISpellProcessor spellProcessor = emptySpellProcessor;
		

	public void refresh() {
		spellProcessor = emptySpellProcessor;
	}
}
