using UnityEngine;
using System.Collections;

public class MenuSound : MonoBehaviour {

	public void playMenu () {

		transform.GetComponent<AudioSource> ().Play ();


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
