using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onix : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Onix";
		hp = 90;
		type = "fighting";
		retreatCost = 3;
		weakness = "grass";
	}

	void RockThrow(){
		CardGame.attackDamage = 10;
	}

	void Harden(){
		CardGame.attackDamage = 0;

		//put in logic for effect
	}
}
