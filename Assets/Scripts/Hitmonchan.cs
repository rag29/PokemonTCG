using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitmonchan : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Hitmonchan";
		hp = 70;
		type = "fighting";
		retreatCost = 2;
		weakness = "psychic";

	}

	void Jab(){
		CardGame.attackDamage = 20;
	}

	void SpecialPunch(){
		CardGame.attackDamage = 40;
	}
}
