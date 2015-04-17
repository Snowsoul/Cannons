using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

public class CreateMap : MonoBehaviour {


	public int totalMaps=0;


	void Start () {
        string filePath = Application.dataPath + @"/maps/maps.xml";
        XmlDocument xmlDoc = new XmlDocument();

        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);

            XmlNodeList transformList = xmlDoc.GetElementsByTagName("map");
            totalMaps = transformList.Count;

        }

	}

	void saveMap(){

		int mapNumber = totalMaps;
		//int objectsNumber = 0;

		Debug.Log ("Map " + mapNumber + " was successfuly saved !");

		// Getting the objects with tag from the scene

		GameObject[] shapes = GameObject.FindGameObjectsWithTag ("level-shapes");

       

            string newPath = Application.dataPath + @"/maps/level-" + totalMaps + ".xml";
            File.WriteAllText(newPath,"<map></map>");
            XmlDocument newLevel = new XmlDocument();

            if (File.Exists(newPath))
            {  
                
                newLevel.Load(newPath);
                XmlElement elmRoot = newLevel.DocumentElement;
               
                XmlElement elmObjects = newLevel.CreateElement("mapObjects");


                foreach (GameObject shape in shapes)
                {

                    int shapeType = -1;
                    string[] shapeName = shape.name.Split(' ');

                    switch (shapeName[0])
                    {

                        case "rotatingCross-shape":

                            shapeType = 0;

                            break;

                        case "curved-shape":

                            shapeType = 1;

                            break;

                        case "wrecking-ball":

                            shapeType = 2;


                            break;
                        case "powerUp":
                            shapeType = 3;
                            break;

                    }




                    
                    XmlElement elmObject = newLevel.CreateElement("object");

                    XmlElement type = newLevel.CreateElement("type");
                    XmlElement position = newLevel.CreateElement("position");
                    XmlElement scale = newLevel.CreateElement("scale");
                    XmlElement rotation = newLevel.CreateElement("rotation");

                    type.InnerText = shapeType.ToString();
                    position.InnerText = shape.transform.position.x + "," + shape.transform.position.y + "," + shape.transform.position.z;
                    scale.InnerText = shape.transform.localScale.x + "," + shape.transform.localScale.y + "," + shape.transform.localScale.z;
                    rotation.InnerText = shape.transform.rotation.eulerAngles.x + "," + shape.transform.rotation.eulerAngles.y + "," + shape.transform.rotation.eulerAngles.z;


                    elmObject.AppendChild(type);                    
                    elmObject.AppendChild(position);
                    elmObject.AppendChild(scale);
                    elmObject.AppendChild(rotation);
                    elmObjects.AppendChild(elmObject);





                }
                elmRoot.AppendChild(elmObjects);

                newLevel.Save(newPath);
                 

               
            

			/*PlayerPrefs.SetInt("map["+totalMaps+"].object["+objectsNumber+"].type",shapeType);

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
             */
                string mapPath = Application.dataPath + @"/maps/maps.xml";
                XmlDocument newMap = new XmlDocument();


                newMap.Load(mapPath);

                XmlElement elementRoot = newMap.DocumentElement;

                XmlElement map = newMap.CreateElement("map");                
                XmlElement mapId = newMap.CreateElement("id");
                XmlElement mapObjects = newMap.CreateElement("totalObjects");

                mapId.InnerText = totalMaps.ToString();
                mapObjects.InnerText = "0";

                map.AppendChild(mapId);
                map.AppendChild(mapObjects);

                elementRoot.AppendChild(map);


                newMap.Save(mapPath);




		}


		/*PlayerPrefs.SetInt("map["+totalMaps+"].objects",objectsNumber);
		PlayerPrefs.SetInt ("Maps", mapNumber);
		PlayerPrefs.Save ();*/

	}
	

	void Update () {


		if (Input.GetKeyDown ("f2")) {
			saveMap();
		}

		if (Input.GetKeyDown ("f6")) {

			/*Debug.Log("All maps have been deleted");
			PlayerPrefs.DeleteAll();
            */
            string mapPath = Application.dataPath + @"/maps/maps.xml";
            XmlDocument newMap = new XmlDocument();


            newMap.Load(mapPath);

            XmlElement elementRoot = newMap.DocumentElement;
            XmlNodeList mapElements = newMap.GetElementsByTagName("map");
            
            foreach (XmlNode mapElement in mapElements)
            {
                XmlNodeList maps = mapElement.ChildNodes;
                foreach (XmlNode el in maps)
                {
                    if (el.Name == "id")
                    {
                        if (el.InnerText == "3")
                        {
                            elementRoot.RemoveChild(mapElement);
                            File.Delete(Application.dataPath + @"/maps/level-3.xml");
                            Debug.Log("Map 3 deleted");
                        }
                        else
                        {
                            Debug.Log("Map 3 not found!");
                        }
                    }
                }
            }

            newMap.Save(mapPath);
		}
	
	}
}
