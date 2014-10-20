using UnityEngine;
using System.Collections;

public abstract class Building : AbstractCastable {

	public Player owner;

	public abstract void changeOwner(Player player);

}
