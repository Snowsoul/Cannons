using UnityEngine;
using System.Reflection;
using System.IO;
using System.Collections;

public class RandomMap : MonoBehaviour {

		
	public string sMap ="";
	public object[] oMap = new object[9];
	private float cTime = 0f;
	private bool start = true;
	private StreamWriter sw;

	// Use this for initialization

	void stringConcat(string t){
		sMap += t;
	}
	void generateMap(){

		for (int p=1; p<=9; p++) {
			
			stringConcat(Random.Range (1, 4).ToString ());
			stringConcat(" ");
			
			if (p % 3 == 0 && p<9)
				stringConcat("| ");
	
		}


	}
	void parseMap(){
		int j = 0;
		for (int i=0; i<sMap.Length; i++)
		if (sMap [i].ToString () != " " && sMap [i].ToString () != "|") {
			oMap [j] = sMap [i];
			j++;
		}
	}
	void showMap(){
		for (int x=0; x<oMap.Length; x++)
			print (oMap [x]+" ");
	}
	void Start () {
		//File.WriteAllText (Application.dataPath + "/test.txt", "test\nline2");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cTime > 3.0f && start) {
			generateMap();
			//parseMap();
			//showMap();
				}
	
		if (cTime < 3.0f)
						cTime += Time.deltaTime;
				else
						start = false;
	}
}
