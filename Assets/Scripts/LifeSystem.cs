using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeSystem : MonoBehaviour {

	public int health = 100;
	public Text player1HP;
	public Text player2HP;
	

	void doDamage(object[] obj){
		int dmg =  (int)obj [0];
		string player = obj [1].ToString();
		health -= dmg;
		if (health < 0)
						health = 0;
						
		if (player == "Player1")
						player1HP.text = "HP: " + health;
				else
			if (player == "Player2")
						player2HP.text = "HP: " + health;

		if (health == 0 && player == "Player1")
						Debug.Log ("Player 2 Wins!!");
		else
			if (health == 0 && player == "Player2")
						Debug.Log ("Player1 Wins !!");



	}
	void Start () {
		player1HP = GameObject.Find ("Player1HP").GetComponent<Text>();
		player2HP = GameObject.Find ("Player2HP").GetComponent<Text>();
	}
	

	void Update () {
	
	}
}
