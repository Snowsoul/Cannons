 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootSystem : MonoBehaviour {

	public GameObject Spawner;
	public GameObject Cannon;
	public static bool bState = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setActive(){

			transform.GetComponent<Button> ().interactable = true;
	}
	public void setFalse(){

			transform.GetComponent<Button> ().interactable = false;
	}

	void Shoot(){
		Cannon.SendMessage ("Shoot");
	}

	void setDefense(){
		Cannon.SendMessage("Defend");
	}

	void setFreeze(){
		Spawner.SendMessage ("setProjectyleType","Freeze");
	}
	void setBurn(){
		Spawner.SendMessage ("setProjectyleType","Fire");
	}
	void setSimple(){
		Spawner.SendMessage ("setProjectyleType","Simple");
	}
}
