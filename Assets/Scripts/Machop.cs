using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machop : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Machop";
		hp = 50;
		type = "fighting";
		retreatCost = 1;
		weakness = "psychic";
	}

	void LowKick(){
		CardGame.attackDamage = 20;
	}


}
