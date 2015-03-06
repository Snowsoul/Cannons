using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeepTheTurns : MonoBehaviour {

	public GameObject currentPlayer;
	public GameObject nextPlayer;
	public int playerTurn = 1;
	private float currentTime = 0f;
	public bool status = false;
	public float timer = 3.0f;
	private GameObject turntext;
	private Text text;
	private Text timetext;
	private int resultTime;
	private GameObject[] p1ui;
	private GameObject[] p2ui;



	void Start () {
		if (!status) {
						
						p1ui = GameObject.FindGameObjectsWithTag("P1-UI");
						p2ui = GameObject.FindGameObjectsWithTag("P2-UI");

						currentPlayer = GameObject.FindWithTag ("Player1");
						nextPlayer = GameObject.FindWithTag ("Player2");
						//turntext = GameObject.Find("TurnText");
						//text = turntext.GetComponent<Text>();
						timetext = GameObject.Find("TimeLeft").GetComponent<Text>();
				}

	}

	void endTurn(){
		currentTime = 0f;
		if (playerTurn == 1) {
						playerTurn = 2;
			GameObject.Find("TimeLeft").GetComponent<RectTransform>().Rotate(0f,180f,0f);
						//Physics2D.gravity *= -1;
			nextPlayer.SendMessage ("changeTurn");

			foreach(GameObject g2 in p2ui)
				g2.GetComponent<ShootSystem>().setActive();
			foreach(GameObject g1 in p1ui)
				g1.GetComponent<ShootSystem>().setFalse();

		
			//text.text = "Player2 Turn";
				} else {
						playerTurn = 1;
			GameObject.Find("TimeLeft").GetComponent<RectTransform>().Rotate(0f,-180f,0f);
						//Physics2D.gravity *= -1;


			foreach(GameObject g2 in p2ui)
				g2.GetComponent<ShootSystem>().setFalse();
			foreach(GameObject g1 in p1ui)
				g1.GetComponent<ShootSystem>().setActive();



			currentPlayer.SendMessage ("changeTurn");
						//text.text = "Player1 Turn";
				}
	}
	float twoDecimals( float num ){
		return  Mathf.Round(num * 100f) / 100f;
	}

	void Update () {
				if (!status) {
			resultTime = (int)timer - (int)currentTime;
			timetext.text = resultTime.ToString()+"s";

						if (currentTime > timer) {
								if (playerTurn == 1) {
									
										currentPlayer.SendMessage ("changeTurn");
										nextPlayer.SendMessage ("changeTurn");
					foreach(GameObject g2 in p2ui)
						g2.GetComponent<ShootSystem>().setActive();
					foreach(GameObject g1 in p1ui)
						g1.GetComponent<ShootSystem>().setFalse();
										//text.text = "Player2 Turn";
					GameObject.Find("TimeLeft").GetComponent<RectTransform>().Rotate(0f,180f,0f);
										playerTurn = 2;
								} else {
										nextPlayer.SendMessage ("changeTurn");
										currentPlayer.SendMessage ("changeTurn");
										//text.text = "Player1 Turn";
					foreach(GameObject g2 in p2ui)
						g2.GetComponent<ShootSystem>().setFalse();
					foreach(GameObject g1 in p1ui)
						g1.GetComponent<ShootSystem>().setActive();

										playerTurn = 1;
					GameObject.Find("TimeLeft").GetComponent<RectTransform>().Rotate(0f,-180f,0f);
								}
								currentTime = 0f;
						}
						currentTime += Time.deltaTime;
				}
		}

}
