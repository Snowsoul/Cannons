using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject projectile;
	public GameObject projectileSpawner;
	private GameObject newProjectile;
	private string projType="setSimple";

	public AudioClip freezeSound;
	public AudioClip fireSound;
	public AudioClip simpleSound;

	// Use this for initialization
	void Start () {
	
	}
	void setProjectyleType(string type){
		switch (type) {
		case "Freeze":
			projType = "setFreeze";
		break;

		case "Fire":
			projType = "setBurn";
			break;
		case "Simple":
			projType = "setSimple";
			break;

				}
	}
	void shoot(string player){

		newProjectile = Instantiate(projectile,projectileSpawner.transform.position,projectileSpawner.transform.rotation) as GameObject;
		newProjectile.SendMessage("setPlayer",player);
		switch(projType){

			case "setFreeze":
				transform.GetComponent<AudioSource>().clip = freezeSound;
				transform.GetComponent<AudioSource>().Play ();
			break;
		case "setBurn":
			transform.GetComponent<AudioSource>().clip = fireSound;
			transform.GetComponent<AudioSource>().Play();


			break;

		case "setSimple":
			transform.GetComponent<AudioSource>().clip = simpleSound;
			transform.GetComponent<AudioSource>().Play();



			break;

		}
		if (projType != "") {
					

						newProjectile.SendMessage (projType);
						
						
				}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnDrawGizmos(){
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = new Color(1,0,0.25f);
		Gizmos.DrawCube (new Vector3 (0f,0.35f,0f) , new Vector3 (0.10f, 0.5f, 0.15f));
		Gizmos.DrawCube (new Vector3(0,0,0), new Vector3 (0.25f,0.25f,0.25f));


	}
}
