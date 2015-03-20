using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class mapLoader : MonoBehaviour {

	public class mapObj{

		public int type;
		public Vector3 pos;
		public Vector3 scale;
		public Vector3 rot ; 
	}
	public class AllMap {
		public List<mapObj> mapObj;
	}

	public string levelsFile;
	public string[] levels;
	public GameObject[] shapes;
	public Vector3[] shapePos;
	public Vector3[] shapeScale;
	private string[] levelMap;
	public string[] coordonates;
	public List<mapObj> mapObjects;
	public List<AllMap> mapLevels;
	public int numberOfLevels;
	public int randomMap;
	private GameObject shape;
	public GameObject shapePick;

	// Use this for initialization

	void setMap(){

	

		for (int i=0; i<mapLevels[randomMap].mapObj.Count; i++) {
				switch(mapLevels[randomMap].mapObj[i].type){

					case 0:
						shapePick = shapes[0];
						
					break;

					case 1:
						shapePick = shapes[1];
					break;


			}

			shape = Instantiate(shapePick,mapLevels[randomMap].mapObj[i].pos,Quaternion.Euler(mapLevels[randomMap].mapObj[i].rot)) as GameObject;
			shape.transform.localScale = mapLevels[randomMap].mapObj[i].scale;

		}

	}
	void Start () {
	

		levelsFile = File.ReadAllText (Application.dataPath + "/levels.txt");
		levels = levelsFile.Split ('\n');
		levelMap = new string[levels.Length];
		numberOfLevels = levels.Length;
		randomMap = Random.Range (0, numberOfLevels);
		mapLevels = new List<AllMap>();

		for(int i=0;i<levels.Length;i++){
			levelMap[i] = File.ReadAllText(Application.dataPath+"/"+levels[i]);
		}

		int test = PlayerPrefs.GetInt("map[1].objects");
		Debug.Log (test);



		for (int i=0; i< levelMap.Length; i++) {

			mapObjects = new List<mapObj>();
			string[] lines = levelMap [i].Split ('\n');
			for (int x=0;x<lines.Length;x++)
			{
				string[] objectInfo = lines [x].Split (',');

			

				mapObj obj = new mapObj();

				int oType = int.Parse(objectInfo[0]);
				float posX = float.Parse(objectInfo[1]);
				float posY = float.Parse(objectInfo[2]);
				float posZ = float.Parse(objectInfo[3]);
				float scaleX = float.Parse(objectInfo[4]);
				float scaleY = float.Parse(objectInfo[5]);
				float scaleZ = float.Parse(objectInfo[6]);
				float rotX = float.Parse(objectInfo[7]);
				float rotY = float.Parse(objectInfo[8]);
				float rotZ = float.Parse(objectInfo[9]);

				obj.type = oType;
				obj.pos = new Vector3(posX,posY,posZ);
				obj.scale = new Vector3(scaleX,scaleY,scaleZ);
				obj.rot =  new Vector3(rotX,rotY,rotZ);

				mapObjects.Add(obj);
			

			}


					

			AllMap data = new AllMap ();
			data.mapObj = mapObjects;


			mapLevels.Add (data);





		
		}

		setMap ();



	}
	

	void Update () {
	
	}
}
