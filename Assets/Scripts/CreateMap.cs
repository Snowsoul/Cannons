using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {


	public int totalMaps=0;


	void Start () {
			totalMaps = PlayerPrefs.GetInt("Maps");
	}

	void saveMap(){

		int mapNumber = totalMaps + 1;
		int objectsNumber = 0;

		Debug.Log ("Map " + mapNumber + " was successfuly saved !");

		// Getting the objects with tag from the scene

		GameObject[] shapes = GameObject.FindGameObjectsWithTag ("level-shapes");

		foreach (GameObject shape in shapes) {

			int shapeType = -1;

			switch(shape.name){

				case "rotatingCross-shape" :
				
					shapeType = 0;
				
				break;

				case "curved-shape" :

					shapeType = 1;

				break;

			}

			PlayerPrefs.SetInt("map["+totalMaps+"].object["+objectsNumber+"].type",shapeType);

			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].position.x",shape.transform.position.x);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].position.y",shape.transform.position.y);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].position.z",shape.transform.position.z);

			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].scale.x",shape.transform.localScale.x);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].scale.y",shape.transform.localScale.y);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].scale.z",shape.transform.localScale.z);

			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].rotation.x",shape.transform.rotation.eulerAngles.x);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].rotation.y",shape.transform.rotation.eulerAngles.y);
			PlayerPrefs.SetFloat("map["+totalMaps+"].object["+objectsNumber+"].rotation.z",shape.transform.rotation.eulerAngles.z);


			objectsNumber ++;

		}


		PlayerPrefs.SetInt("map["+totalMaps+"].objects",objectsNumber);
		PlayerPrefs.SetInt ("Maps", mapNumber);
		PlayerPrefs.Save ();
	}
	

	void Update () {


		if (Input.GetKeyDown ("f2")) {
			saveMap();
		}

		if (Input.GetKeyDown ("f6")) {

			Debug.Log("All maps have been deleted");
			PlayerPrefs.DeleteAll();
		}
	
	}
}
