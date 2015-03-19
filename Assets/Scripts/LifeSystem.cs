using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeSystem : MonoBehaviour {

	public int health = 100;
	public GameObject player1HP;
	public GameObject player2HP;
    private bool decreaseP1 = false;
    private bool decreaseP2 = false;

	

	void doDamage(object[] obj){
		int dmg =  (int)obj [0];
		string player = obj [1].ToString();
		health -= dmg;
  
		if (health < 0)
						health = 0;
		if (player == "Player1")
        {
            //player1HP.GetComponent<Image>().fillAmount = (float)health / 100;
            decreaseP1 = true;
        }			
				else
            if (player == "Player2")
            {
                //player2HP.GetComponent<Image>().fillAmount = (float)health / 100;
                decreaseP2 = true;
            }
               

		if (health == 0 && player == "Player1")
						Debug.Log ("Player 2 Wins!!");
		else
			if (health == 0 && player == "Player2")
						Debug.Log ("Player1 Wins !!");



	}
	void Start () {
		player1HP = GameObject.Find ("Player1HP");
		player2HP = GameObject.Find ("Player2HP");
	}
	

	void Update () {

        if (decreaseP1)
        {
            if (player1HP.GetComponent<Image>().fillAmount > (float)health / 100)
                player1HP.GetComponent<Image>().fillAmount -= 0.01f;
            else
                decreaseP1 = false;
        }
        if (decreaseP2)
        {
            if (player2HP.GetComponent<Image>().fillAmount > (float)health / 100)
                player2HP.GetComponent<Image>().fillAmount -= 0.01f;
            else
                decreaseP2 = false;
        }
	
	}
}
