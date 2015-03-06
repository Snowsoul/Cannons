using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Console : MonoBehaviour {

	private bool consoleShown = false;
	string inputText;
	Text ConsoleText;
	// Use this for initialization
	void Start () {
	
	}
	void consoleToggle(){


		if (!consoleShown)
		{
			consoleShown = true;
			GameObject.Find ("InputField").GetComponent<RectTransform>().localPosition = new Vector3(0.01250017f,128.5f,0f);
			GameObject.Find ("TextArea").GetComponent<RectTransform>().localPosition = new Vector3(0f,312f,0f);


		} 
		else
		{
			consoleShown = false;
			GameObject.Find ("InputField").GetComponent<RectTransform>().localPosition = new Vector3(0.01250017f,268.5f,0f);
			GameObject.Find ("TextArea").GetComponent<RectTransform>().localPosition = new Vector3(0f,250f,0f);
		}



	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.BackQuote)){
			consoleToggle();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {


		
			inputText = GameObject.Find ("inputText").GetComponent<Text>().text;
			GameObject.Find("ConsoleText").GetComponent<Text>().text += "\n"+inputText;
			GameObject.Find ("inputText").GetComponent<Text>().text = null;

		}
	
	}
}
