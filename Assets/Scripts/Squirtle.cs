using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirtle : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Squirtle";
		hp = 40;
		type = "water";
		retreatCost = 1;
		weakness = "electric";
	}

	void Bubble(){
		CardGame.attackDamage = 10;

		//put in card logic 
	}

	void Withdraw(){
		CardGame.attackDamage = 0;

		//put in card logic 
	}


}
