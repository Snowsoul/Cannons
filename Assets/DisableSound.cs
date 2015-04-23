using UnityEngine;
using System.Collections;

public class DisableSound : MonoBehaviour {

    bool soundRemoved = false;
    public void removeSound()
    {
        if (!soundRemoved)
        {
            AudioListener.volume = 0f;
            soundRemoved = true;
        }
        else
        {
            AudioListener.volume = 1f;
            soundRemoved = false;
        }

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
