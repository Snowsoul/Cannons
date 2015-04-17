using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

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
    public bool setMaps = true;


	public void setMap(){

        do
        {
            randomMapNumber = Random.Range(0, totalMaps);
        }
        while (randomMapNumber == lastMap && totalMaps > 1);
        lastMap = randomMapNumber;

        Debug.Log("Current Level is: " + randomMapNumber);

		GameObject[] shapez = GameObject.FindGameObjectsWithTag ("level-shapes");
		
		foreach (GameObject shape in shapez) {
			Destroy(shape.gameObject);
		}

		GameObject shapePick = shapes[0];

		for (int i=0; i<allMaps[randomMapNumber].mapObj.Count; i++) {

			switch(allMaps[randomMapNumber].mapObj[i].type){
				
			case 0:
				shapePick = shapes[0];
				
				break;
				
			case 1:
				shapePick = shapes[1];
				break;
				
            case 2:
                shapePick = shapes[2];
            break;

            case 3:
                shapePick = shapes[3];
            break;
				
			}
			
			GameObject shape = Instantiate(shapePick,allMaps[randomMapNumber].mapObj[i].pos,Quaternion.Euler(allMaps[randomMapNumber].mapObj[i].rot)) as GameObject;
			shape.transform.localScale = allMaps[randomMapNumber].mapObj[i].scale;
			
		}

		
	}


	void Start () {

		//totalMaps = PlayerPrefs.GetInt ("Maps");
		allMaps = new List<Map>();

        List<int> mapsIds = new List<int>();

        string filePath = Application.dataPath + @"/maps/maps.xml";
        XmlDocument xmlDoc = new XmlDocument();

        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);

            XmlNodeList transformList = xmlDoc.GetElementsByTagName("map");

            foreach (XmlNode transformInfo in transformList)
            {
                XmlNodeList transformContent = transformInfo.ChildNodes;
                foreach (XmlNode transformItems in transformContent)
                {
                    if (transformItems.Name == "id")
                    {
                        mapsIds.Add(int.Parse(transformItems.InnerText));
                    }

                }

            }
        }
        else
            Debug.Log("Map Path does not exist " + filePath);

        totalMaps = mapsIds.Count;

        foreach(int mId in mapsIds)
        {

            string fPath = Application.dataPath + @"/maps/level-" + mId + ".xml";
            XmlDocument levelMap = new XmlDocument();
            Map currentMap = new Map();
            List<mapObj> mapObjects = new List<mapObj>();
            if (File.Exists(fPath))
            {
                levelMap.Load(fPath);
                

                XmlNodeList objectsList = levelMap.GetElementsByTagName("object");

                foreach (XmlNode objectInfo in objectsList)
                {
                    XmlNodeList objectContent = objectInfo.ChildNodes;
                    mapObj obj = new mapObj();
                    foreach (XmlNode objectItems in objectContent)
                    {
                       
                        switch (objectItems.Name)
                        {
                            case "type":
                                obj.type = int.Parse(objectItems.InnerText);
                                break;
                            case "position":
                                string[] objPos = objectItems.InnerText.Split(',');
                                obj.pos = new Vector3(float.Parse(objPos[0]), float.Parse(objPos[1]), float.Parse(objPos[2]));
                                break;
                            case "scale":
                                string[] objScale = objectItems.InnerText.Split(',');
                                obj.scale = new Vector3(float.Parse(objScale[0]), float.Parse(objScale[1]), float.Parse(objScale[2]));
                                break;
                            case "rotation":
                                string[] objRot = objectItems.InnerText.Split(',');
                                obj.rot = new Vector3(float.Parse(objRot[0]), float.Parse(objRot[1]), float.Parse(objRot[2]));
                                break;

                        }
                        
                    }
                    mapObjects.Add(obj);
                }


            }
            else
            {
                Debug.Log("Level Path does not exists " + fPath);
            }

            currentMap.mapObj = mapObjects;
            allMaps.Add(currentMap);

            


        }

		/*for (int i=0; i<totalMaps; i++) {

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
        */
        if (setMaps)
        setMap();
	}
	

	void Update () {

		if (Input.GetKeyDown ("l"))
		{
			/*do{
				randomMapNumber = Random.Range(0,totalMaps);
			}
			while (randomMapNumber == lastMap && totalMaps > 1);
            */
			setMap ();
			//lastMap = randomMapNumber;
		}
		
	}

}
