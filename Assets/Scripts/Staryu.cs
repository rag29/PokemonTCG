using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staryu : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Staryu";
		hp = 40;
		type = "water";
		retreatCost = 1;
		weakness = "electric";
	}

	void Slap(){
		CardGame.attackDamage = 20;

		//put in card logic 
	}
		
}
