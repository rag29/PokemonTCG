using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGame : MonoBehaviour {

	public int HandSize = 7;
	public GameObject CardBack;

	[SerializeField]
	private List<GameObject> Hand;
	[SerializeField]
	private List<GameObject> EnemyHand;
	[SerializeField]
	private List<GameObject> EnemyInvisibleHand;

	public List<GameObject> ZapDeck = new List<GameObject> ( new GameObject[60] );
	public List<GameObject> BlackoutDeck =   new List<GameObject> ( new GameObject[60] );

	//an internal representation of the player's hand based on an integer value
	public List<int> MyCards = new List<int> ();

	//an internal representation of the enemy's hand based on an integer value
	public List<int> EnemyCards = new List<int> ();

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

	bool playerHandInstantiated = false;
	bool enemyHandInstantiated = false;

	public List<GameObject> InvisiblePlayerPrizeCards = new List<GameObject>();
	public List<GameObject> InvisibleEnemyPrizeCards = new List<GameObject>();

	public GameObject EnemyScrollView;
	public GameObject ScrollView;

	// Use this for initialization
	void Start () {

		SetupPlayerHand ();
		SetupEnemyHand ();

		LayoutPlayerPrizeCards ();
		LayoutEnemyPrizeCards ();

		ShowPlayerDeck ();
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

	void SetupPlayerHand()
	{
		//create and populate the player hand
		if (!playerHandInstantiated) {
			Hand = new List<GameObject> ();
			playerHandInstantiated = true;
		}

		for (int x = 0; x < HandSize; x++) {
			PlayerDrawCard ();
		}

		//if the player doesn't have a basic pokemon in their hand
		if (!CheckForBasicPokemon (Hand)) {
			//shuffle hand into deck
			for (int x = 0; x < HandSize; x++) {
				ZapDeck.Add (Hand[x]);
				Destroy (Hand [x]);
			}
			//draw 7 new cards
			SetupPlayerHand();

		}
	}

	void SetupEnemyHand()
	{
		//create and populate the enemy hand
		if (!enemyHandInstantiated) {
			EnemyHand = new List<GameObject> ();
			enemyHandInstantiated = true;
		}

		for (int x = 0; x < HandSize; x++) {
			EnemyDrawCard ();
		}

		if (!CheckForBasicPokemon (EnemyInvisibleHand)) {
			//shuffle hand into deck
			for (int x = 0; x < HandSize; x++) {
				BlackoutDeck.Add (EnemyInvisibleHand[x]);
				//Destroy (EnemyHand [x]);
				Destroy (EnemyInvisibleHand [x]);
			}
			//draw 7 new cards
			SetupEnemyHand();
		}
	}

	bool CheckForBasicPokemon(List<GameObject> HandOfCards){
		
		for (int x = 0; x < HandSize; x++) {
			if (HandOfCards [x].tag == "basic") {
				return true;
			}

		}
		return false;
	}

	void PlayerDrawCard()
	{
		CardType = Random.Range (0, ZapDeck.Count - 1);
		MyCards.Add (CardType);
		GameObject go = GameObject.Instantiate (ZapDeck [CardType]) as GameObject;
		go.transform.SetParent (ScrollView.transform);
		Vector3 positionCard = new Vector3(((Hand.Count - 1) * 3) + 1, -3, 0);
		go.transform.transform.position = positionCard;
		Hand.Add(go);
		ZapDeck.Remove (ZapDeck[CardType]);
	}

	void EnemyDrawCard()
	{
		CardType = Random.Range (0, BlackoutDeck.Count - 1);
		EnemyCards.Add(CardType);
		CardName = BlackoutDeck [CardType].ToString();
		GameObject invisibleCard = GameObject.Instantiate (BlackoutDeck [CardType]) as GameObject;
		//invisibleCard.GetComponent<SpriteRenderer> ().enabled = false;
		//GameObject go = GameObject.Instantiate (CardBack) as GameObject;
		//go.transform.SetParent (EnemyScrollView.transform);
		Vector3 positionEnemy = new Vector3(((EnemyHand.Count - 1) * 3) + 1, 17, 0);
		//go.transform.transform.position = positionEnemy;
		invisibleCard.transform.transform.position = positionEnemy;
		//EnemyHand.Add(go);
		EnemyHand.Add(invisibleCard); //----------------------remove this after testing fronts of enemy cards
		EnemyInvisibleHand.Add (invisibleCard);
		BlackoutDeck.Remove (BlackoutDeck[CardType]);
	}

	void LayoutPlayerPrizeCards()
	{
		for(int x = 0; x < 6; x++)
		{
		//select a card
		CardType = Random.Range (0, ZapDeck.Count - 1);

		//instantiate a card back 
		GameObject go = GameObject.Instantiate (CardBack) as GameObject;
		Vector3 position;
		
		//instantiate an invisible card
		GameObject invisiblePrizeCard = GameObject.Instantiate (ZapDeck[CardType]) as GameObject;

		//position the card back
			switch (x) {
			case 0:
				position = new Vector3 (-5, 4, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 1:
				position = new Vector3 (-7.5f, 4, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 2:
				position = new Vector3 (-5, 7, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 3:
				position = new Vector3 (-7.5f, 7, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 4:
				position = new Vector3 (-5, 10, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 5:
				position = new Vector3 (-7.5f, 10, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			}
		
			//remove it from the deck
			ZapDeck.Remove (ZapDeck[CardType]);
		}
	}

	void LayoutEnemyPrizeCards()
	{
		for(int x = 0; x < 6; x++)
		{
			//select a card
			CardType = Random.Range (0, BlackoutDeck.Count - 1);

			//instantiate a card back 
			GameObject go = GameObject.Instantiate (CardBack) as GameObject;
			Vector3 position;

			//instantiate an invisible card
			GameObject invisiblePrizeCard = GameObject.Instantiate (BlackoutDeck[CardType]) as GameObject;

			//position the card back
			switch (x) {
			case 0:
				position = new Vector3(19, 14, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 1:
				position = new Vector3 (21.5f, 14, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 2:
				position = new Vector3 (19, 11, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 3:
				position = new Vector3 (21.5f, 11, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 4:
				position = new Vector3 (19, 8, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			case 5:
				position = new Vector3 (21.5f, 8, 0);
				go.transform.transform.position = position;
				invisiblePrizeCard.transform.position = position;
				break;
			}

			//remove it from the deck
			BlackoutDeck.Remove (BlackoutDeck[CardType]);
		}
	}

	void ShowPlayerDeck()
	{
		for (int x = 0; x < 3; x++) {
			GameObject go = GameObject.Instantiate (CardBack) as GameObject;
			Vector3 position;

			switch (x) {
			case 0:
				position = new Vector3 (22, 4.5f, 0);
				go.transform.transform.position = position;
				break;
			case 1:
				position = new Vector3 (21.75f, 4.25f, 0);
				go.transform.transform.position = position;
				break;
			case 2:
				position = new Vector3 (21.5f, 4, 0);
				go.transform.transform.position = position;
				break;
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
