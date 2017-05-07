using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machoke : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Machoke";
		hp = 80;
		type = "fighting";
		retreatCost = 3;
		weakness = "psychic";
		preEvolvedForm = "Machop";
	}

	void KarateChop(){
		CardGame.attackDamage = 50;

		//put in logic for card effect
	}

	void Submission(){
		CardGame.attackDamage = 60;
		hp -= 20;
	}
}
