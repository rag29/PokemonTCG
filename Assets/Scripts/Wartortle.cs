using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wartortle : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Wartortle";
		hp = 70;
		type = "water";
		retreatCost = 1;
		weakness = "electric";
		preEvolvedForm = "Squirtle";
	}

	void Withdraw(){
		CardGame.attackDamage = 0;

		//put in card logic 
	}

	void Bite(){
		CardGame.attackDamage = 40;
	}
}
