using UnityEngine;
using System.Collections;

public class CountDOwn : MonoBehaviour {

    public GameObject player1Cannon;
    public GameObject player2Cannon;
    public GameObject keeper;
    public GameObject cm;
    public GameObject[] p1ui;

    public int countdown = 3;
    float cTime = 0f;
    float nTime = 1.0f;
	// Use this for initialization
	void Start () {
        transform.GetComponent<AudioSource>().Play();
        p1ui = GameObject.FindGameObjectsWithTag("P1-UI");
	}
	
	// Update is called once per frame
	void Update () {

        if (cTime > nTime && cTime < 5.0f)
        {
            if (cTime < 4.0f)
            transform.GetComponent<AudioSource>().Play();

            if (nTime == 1.0f)
            {
                GameObject.Find("3").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("2").GetComponent<SpriteRenderer>().enabled = true;

            }
            if (nTime == 2.0f)
            {
                GameObject.Find("2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("1").GetComponent<SpriteRenderer>().enabled = true;
            }

            if (nTime == 3.0f)
            {
                GameObject.Find("1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("fight").GetComponent<SpriteRenderer>().enabled = true;
            }
            if (nTime == 4.0f)
            {
                GameObject.Find("fight").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("CountBG").GetComponent<SpriteRenderer>().enabled = false;
                player1Cannon.GetComponent<MoveCannon>().frozen = false;
                player2Cannon.GetComponent<MoveCannon>().frozen = false;
                keeper.GetComponent<KeepTheTurns>().status = false;
                cm.GetComponent<mapLoaderFromPlayerPrefs>().setMap();
                foreach (GameObject g1 in p1ui)
                    g1.GetComponent<ShootSystem>().setActive();
            }



            if (cTime < 5.0f)
                nTime += 1.0f;
           

        }
        else
        cTime += Time.deltaTime;
	    
	}
}
