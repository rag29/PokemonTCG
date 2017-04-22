using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour {

	public int HandSize = 7;
	public GameObject CardBack;

	private GameObject[] Hand;
	private GameObject[] EnemyHand;

	public GameObject[] ZapDeck = new GameObject[60];
	public GameObject[] BlackoutDeck =  new GameObject[60];

	//an internal representation of the player's hand based on an integer value
	public int[] MyCards = new int[7];

	//an internal representation of the enemy's hand based on an integer value
	public int[] EnemyCards = new int[7];

	public int CardType;
	public string CardName;

	//indicator of the player's life
	//decrase by one every time the enemy gets a prize card
	public int MyLife = 6;

	//indicator of the enemy's life
	//decrase by one every time the player gets a prize card
	public int EnemyLife = 6;

	public bool playerHasWon;
	public bool enemyHasWon;

	// Use this for initialization
	void Start () {

		//create and populate the player hand
		Hand = new GameObject[HandSize];
		for (int x = 0; x < HandSize; x++) {
			CardType = Random.Range (0, 59);
			GameObject go = GameObject.Instantiate (ZapDeck [CardType]) as GameObject;
			Vector3 positionCard = new Vector3((x * 3) + 1, 1, 0);
			go.transform.transform.position = positionCard;
			Hand [x] = go;
		}

		//create and populate the enemy hand
		EnemyHand = new GameObject[HandSize];
		for (int x = 0; x < HandSize; x++) {
			CardType = Random.Range (0, 59);
			EnemyCards [x] = CardType;
			CardName = BlackoutDeck [CardType].ToString();
			GameObject go = GameObject.Instantiate (CardBack) as GameObject;
			Vector3 positionEnemy = new Vector3((x * 3) + 1, 17, 0);
			go.transform.transform.position = positionEnemy;
			EnemyHand [x] = go;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) {
			
			//capture mouse position through a raycast
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			//if the raycast hits a card, handle the game logic
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Card") {
					GameObject CardClicked = hit.transform.gameObject;

					//string CardEnemyPlayed = EnemyTurn ();
				}
			}

		}
	}

	//function to control enemy turn

	//------pick a card at random out of a given category (3 lists for internal - energy, pkmn, trainer)
	//------int PickACardAtRandom = Random.Range(0, {name of category list - one of the three above} );
	//------GameObject ChosenCard = EnemyHand[PickACardAtRandom];



	//function to resolve battle logic

	//function to control drawing a card
}
