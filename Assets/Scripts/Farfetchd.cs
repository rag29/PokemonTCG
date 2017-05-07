using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farfetchd : MonsterCard {

	// Use this for initialization
	void Awake () {
		hp = 50;
		type = "normal";
		retreatCost = 1;
		weakness = "electric";
		resistance.Add ("fighting",30); 
	}
	
	void LeekSlap(){
		CardGame.attackDamage = 30;
	}

	void PotSmash(){
		CardGame.attackDamage = 30;
	}
}
