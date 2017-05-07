using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : Card {

	protected string name = "";

	protected int hp = 0;

	protected string type = "";

	//iterate through here to instantiate energy and also to check for energy for attacks
	//1. when adding energy to a pokemon card, check if energy is present on that card
	//if not, instantiate a new dictionary element and set the value to one
	//else, do a ++ to the current value at that type (the type is the key value in the key value pair
	protected Dictionary<string, int> energyOnCard = new Dictionary<string, int> (); 

	protected int retreatCost = 0;

	protected string weakness = "";

	protected Dictionary<string, int> resistance = new Dictionary<string, int> (); 

	protected string preEvolvedForm = "";

	//the base attack method 
	//call in each pokemon's attack by calling base.Attack()
	//this will set the publically accessible variables to be used in the battle resolution
	//if there is not enough energy or the attack cannot happen return false
	//do check on this base method before setting damage and doing effects
	bool Attack()
	{
		
	}

	void EnergyCheck()
	{
		
	}
}
