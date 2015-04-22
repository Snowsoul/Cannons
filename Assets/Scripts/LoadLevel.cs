using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public void changeLevel(string sceneName)
    {
        if (sceneName !="")
        Application.LoadLevel(sceneName);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
