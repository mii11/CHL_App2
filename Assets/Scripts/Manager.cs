using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	public static Manager instance;

	public int curPlayerLife;
	public int curEnemyNum;
	int PlayerLife = 3;
	int totalEnemyNum = 50;
	int totalStagesNum = 1;

	public string[] Stages = {
		"stgStart",
		"stg1",
		"stgOver"
	};

	public GameObject gun;

	//	public int curStageNo = 0; //start画面なし 
	public int curStageNo = 1;
	//	public string curStageName = "";

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		DontDestroyOnLoad (this);

		curPlayerLife = PlayerLife;
		curEnemyNum = totalEnemyNum;
	}

	// Update is called once per frame
	void Update () {

	}
}
