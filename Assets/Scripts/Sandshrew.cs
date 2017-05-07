using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandshrew : MonsterCard {

	// Use this for initialization
	void Awake () {
		name = "Sandshrew";
		hp = 40;
		type = "fighting";
		retreatCost = 1;
		weakness = "grass";
		resistance.Add ("electric",30);
	}

	void SandAttack(){
		CardGame.attackDamage = 10;

		//put in card logic 
	}
}
