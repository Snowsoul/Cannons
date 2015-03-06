using UnityEngine;
using System.Collections;

public class MoveCannon : MonoBehaviour {
	

	private bool isPressed = false;
	private float angle = 0f;
	public bool fliped = false;
	private Vector3 screenPos;
	public Camera cm;
	public GameObject initialPos;
	public GameObject spawner;
	public bool myTurn = false;
	public bool frozen = false;
	public bool defrostNextTurn = false;
	public bool stopBurningNextTurn = false;
	public bool burning = false;
	private float cTime = 0f;
	private GameObject freezeP1;
	private GameObject freezeP2;
	private GameObject burnP1;
	private GameObject burnP2;
	private string playerTag;
	private bool firstBurn = true;
	private bool defense = false;
	private bool defenseExpiresNextTurn = false;
	private int defenseAmount = 2;
	private int turnCount = 0;
	public AudioClip fireSound;

	void rotateCannon(){

						float mouseX = Input.mousePosition.x;
						float mouseY = Input.mousePosition.y;
						angle = Mathf.Atan2 (mouseY - screenPos.y, mouseX - screenPos.x) * 180 / Mathf.PI;
						if (!fliped) {
								if (angle >= 20 && angle <= 160)
										transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 95));
						} else {
								if (angle <= -20 && angle >= -160)
										transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 95 ));

						}
				
	}
	void removeDefense(){
		defense = false;
		defenseExpiresNextTurn = false;
		turnCount = 0;
	}
	void changeTurn(){
		if (!myTurn)
						myTurn = true;
				else {
						myTurn = false;
					
			if (defense)
						turnCount ++;
				}

		if (!myTurn && defenseExpiresNextTurn && turnCount == 2)
						removeDefense ();

		if (!myTurn && defrostNextTurn)
			UnFreeze();

		if (!myTurn && stopBurningNextTurn)
			StopBurning();
	}

	void Shoot(){
		if (myTurn && !frozen) {

		
						spawner.SendMessage ("shoot",playerTag);
						changeTurn ();
						GameObject.Find ("TurnKeeper").SendMessage ("endTurn");
				}
	}
	void Freeze(){


		frozen = true;
		if (playerTag == "Player1")
						freezeP1.GetComponent<Renderer>().enabled = true;
		else
			if (playerTag =="Player2")
						freezeP2.GetComponent<Renderer>().enabled = true;
		defrostNextTurn = true;
			

	}

	void UnFreeze(){
		frozen = false;
		defrostNextTurn = false;
		if (playerTag == "Player1")
			freezeP1.GetComponent<Renderer>().enabled = false;
		else
			if (playerTag == "Player2")
				freezeP2.GetComponent<Renderer>().enabled = false;


	}

	void StopBurning(){
		burning = false;
		stopBurningNextTurn = false;
		if (playerTag == "Player1")
			burnP1.GetComponent<Renderer>().enabled = false;
		else
			if (playerTag == "Player2")
				burnP2.GetComponent<Renderer>().enabled = false;
	}

	void Burn(){

		burning = true;
		if (playerTag == "Player1")
			burnP1.GetComponent<Renderer>().enabled = true;
		else
			if (playerTag =="Player2")
				burnP2.GetComponent<Renderer>().enabled = true;
		stopBurningNextTurn = true;

	}
	void Defend(){
		defense = true;
		defenseExpiresNextTurn = true;
		changeTurn ();
		GameObject.Find ("TurnKeeper").SendMessage ("endTurn");
	}
	
	// Use this for initialization
	void Start () {

		playerTag = transform.gameObject.tag;
		freezeP1 = GameObject.Find ("fc-p1");
		freezeP2 = GameObject.Find ("fc-p2");
		burnP1 = GameObject.Find ("burn-p1");
		burnP2 = GameObject.Find ("burn-p2");

		 screenPos = cm.WorldToScreenPoint(initialPos.transform.position);
			
	}
	// Update is called once per frame
	void Update () {

				if (myTurn && !frozen) {
						if (isPressed)
								rotateCannon ();

						if (burning)
						{
							object[] dmgovertime = new object[2];
							if (!defense)
								dmgovertime[0] = 5;
							else
								dmgovertime[0] = 5/defenseAmount;

							dmgovertime[1] = transform.gameObject.tag;
							
							if (firstBurn)
							{
								transform.gameObject.SendMessage("doDamage",dmgovertime);
								firstBurn = false;
							}
							if (cTime > 2.0f)
							{
								transform.gameObject.SendMessage("doDamage",dmgovertime);
								cTime = 0f;
							}
							cTime +=Time.deltaTime;
							
						}




				}
		}
	void OnMouseDown(){
						isPressed = true;

	}
	void OnMouseUp(){
						isPressed = false;


	}
	void OnCollisionEnter2D(Collision2D other){

		
		if (other.gameObject.tag == "FreezeProjectile") {

						Freeze();
						Destroy (other.gameObject);
				} else
		if (other.gameObject.tag == "FireProjectile") {

						Burn();
						Destroy (other.gameObject);

				}
				else
			if (other.gameObject.tag == "SimpleProjectile") {
						
			Destroy (other.gameObject);
						object[] obj = new object[2];
						if(!defense)
							obj [0] = 10; // Damage Amount
						else
							obj [0] = 10 / defenseAmount;
						obj [1] = transform.gameObject.tag;

						transform.gameObject.SendMessage ("doDamage", obj);
				}
	}
}
