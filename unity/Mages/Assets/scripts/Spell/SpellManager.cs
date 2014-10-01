using UnityEngine;
using System.Collections;

public class SpellManager : MonoBehaviour {
	
	private static SpellManager instance;

	public static SpellManager INSTANCE {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<SpellManager>();;
			}
			return instance;
		} 
	}

	public readonly static ISpellProcessor emptySpellProcessor = new EmptySpellProcessor();

	public ISpellProcessor spellProcessor = emptySpellProcessor;
		

	public void refresh() {
		spellProcessor = emptySpellProcessor;
	}
}
