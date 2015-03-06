using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mapLoaderFromPlayerPrefs : MonoBehaviour {



	public class mapObj{
		
		public int type;
		public Vector3 pos;
		public Vector3 scale;
		public Vector3 rot ; 

	}

	public class Map {

		public List<mapObj> mapObj;

	}

	public GameObject[] shapes;
	private List<Map> allMaps;
	private int randomMapNumber;
	private int totalMaps;
	private int lastMap = -1;


	void setMap(List<Map> maps,int rand){

		GameObject[] shapez = GameObject.FindGameObjectsWithTag ("level-shapes");
		
		foreach (GameObject shape in shapez) {
			Destroy(shape.gameObject);
		}

		GameObject shapePick = shapes[0];

		for (int i=0; i<maps[rand].mapObj.Count; i++) {

			switch(maps[rand].mapObj[i].type){
				
			case 0:
				shapePick = shapes[0];
				
				break;
				
			case 1:
				shapePick = shapes[1];
				break;
				
				
			}
			
			GameObject shape = Instantiate(shapePick,maps[rand].mapObj[i].pos,Quaternion.Euler(maps[rand].mapObj[i].rot)) as GameObject;
			shape.transform.localScale = maps[rand].mapObj[i].scale;
			
		}

		
	}


	void Start () {

		totalMaps = PlayerPrefs.GetInt ("Maps");
		allMaps = new List<Map>();

		for (int i=0; i<totalMaps; i++) {

			Map currentMap = new Map();
			List<mapObj> mapObjects = new List<mapObj>();
			int currentTotalMapObjects = PlayerPrefs.GetInt("map["+i+"].objects");

			for (int j=0;j<currentTotalMapObjects;j++){

				mapObj obj = new mapObj();

				obj.type = PlayerPrefs.GetInt("map["+i+"].object["+j+"].type");
				obj.pos = new Vector3 ( PlayerPrefs.GetFloat("map["+i+"].object["+j+"].position.x"), PlayerPrefs.GetFloat("map["+i+"].object["+j+"].position.y"),PlayerPrefs.GetFloat("map["+i+"].object["+j+"].position.z") );
				obj.scale = new Vector3 ( PlayerPrefs.GetFloat("map["+i+"].object["+j+"].scale.x"), PlayerPrefs.GetFloat("map["+i+"].object["+j+"].scale.y"),PlayerPrefs.GetFloat("map["+i+"].object["+j+"].scale.z") );
				obj.rot = new Vector3 ( PlayerPrefs.GetFloat("map["+i+"].object["+j+"].rotation.x"), PlayerPrefs.GetFloat("map["+i+"].object["+j+"].rotation.y"),PlayerPrefs.GetFloat("map["+i+"].object["+j+"].rotation.z") );

				mapObjects.Add(obj);
			}

			currentMap.mapObj = mapObjects;
			allMaps.Add(currentMap);



		}

	}
	

	void Update () {

		if (Input.GetKeyDown ("l"))
		{
			do{
				randomMapNumber = Random.Range(0,totalMaps);
			}
			while (randomMapNumber == lastMap && totalMaps > 1);

			setMap (allMaps,randomMapNumber);
			lastMap = randomMapNumber;
		}
		
	}

}
