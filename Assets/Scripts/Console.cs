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
            GameObject.Find("ConsoleCanvas").GetComponent<Canvas>().enabled = true;
            GameObject.Find("InputField").GetComponent<InputField>().Select();
            GameObject.Find("InputField").GetComponent<InputField>().ActivateInputField();

			


		} 
		else
		{
			consoleShown = false;
            GameObject.Find("ConsoleCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("InputField").GetComponent<InputField>().text = "";
            GameObject.Find("InputField").GetComponent<InputField>().DeactivateInputField();
	
		}



	}
	// Update is called once per frame
	void Update () {

   
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject.Find("InputField").GetComponent<InputField>().Select();
            GameObject.Find("InputField").GetComponent<InputField>().ActivateInputField();

        }
		if (Input.GetKeyDown(KeyCode.BackQuote)){
			consoleToggle();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {


		
			inputText = GameObject.Find ("inputText").GetComponent<Text>().text;
           
            GameObject testText = GameObject.Find("InputField");
            InputField newText = testText.GetComponent<InputField>();
            newText.text = "";
			GameObject.Find("ConsoleText").GetComponent<Text>().text += "\n"+inputText;
            GameObject.Find("InputField").GetComponent<InputField>().Select();
            GameObject.Find("InputField").GetComponent<InputField>().ActivateInputField();

		}
	
	}
}
