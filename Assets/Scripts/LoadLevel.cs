using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public void changeLevel(string sceneName)
    {
        if (sceneName !="" && sceneName !="hardcore" && sceneName!="normal")
        Application.LoadLevel(sceneName);

        if (sceneName == "hardcore")
        {
            PlayerPrefs.SetInt("hardcore", 1);
            Application.LoadLevel("MainScene");

        }
        if (sceneName == "normal")
        {
            PlayerPrefs.SetInt("hardcore", 0);
            Application.LoadLevel("MainScene");
        }
        
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
