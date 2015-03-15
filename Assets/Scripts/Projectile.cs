using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float maxSpeed = 10f;
	public float destroyTime = 10f;
	public bool freeze = false;
	public bool fire = false;
	public bool simple = true;
	private string player="";
	public bool stopForce = false;

	// Use this for initialization

	void setPlayer(string pl){

		player = pl;
	}
	void setFreeze(){
		freeze = true;
		fire = false;
		simple = false;
		setProjectileType ();
	}
	void setBurn(){
		fire = true;
		freeze = false;
		simple = false;
		setProjectileType ();
	}
	void setSimple(){
		simple = true;
		freeze = false;
		fire = false;
		setProjectileType ();
	}
	void setProjectileType(){
		if (freeze)
			transform.gameObject.tag = "FreezeProjectile";
		else
			if (fire)
				transform.gameObject.tag = "FireProjectile";
		else
			if (simple)
				transform.gameObject.tag = "SimpleProjectile";
	}
	void Start () {
		//Debug.Log (player);
		setProjectileType ();
		Destroy (transform.gameObject, destroyTime);
		switch (player) {
		case "Player1" :

			transform.GetComponent<Rigidbody2D>().gravityScale = 1;
			//transform.rigidbody2D.AddForce (Vector3.up *maxSpeed);
			
			break;
			
		case "Player2" :
			transform.GetComponent<Rigidbody2D>().gravityScale = -1;
			//transform.rigidbody2D.AddForce (Vector3.down *maxSpeed);
			break;
		}


	}
	
	//void Update(){

	
	
	//}
	void FixedUpdate () {

		if (!stopForce) {
						switch (player) {
						case "Player1":
								transform.Translate (Vector3.up * Time.deltaTime * maxSpeed);
								break;

						case "Player2":
								transform.Translate (Vector3.down * Time.deltaTime * maxSpeed * -1);
								break;
						}
				}


	}
	void OnCollisionEnter2D(Collision2D col){
        if (!stopForce)
        {
            /*switch (player)
            {
                case "Player1":

                    transform.GetComponent<Rigidbody2D>().gravityScale = 1;
                    //transform.rigidbody2D.AddForce (Vector3.up *maxSpeed);

                    break;

                case "Player2":
                    transform.GetComponent<Rigidbody2D>().gravityScale = -1;
                    //transform.rigidbody2D.AddForce (Vector3.down *maxSpeed);
                    break;
            }*/
            stopForce = true;
        }
		

        if (col.gameObject.tag == "mapWall")
        {
            Destroy(transform.gameObject);
        }
	}

	
}
