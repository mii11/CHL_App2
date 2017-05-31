using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public static StageManager instance;

	public GameObject playerGun;
	public GameObject enemyObj;
	PlayerGunController2 playerGunCtrlScript;
	EnemyController1 enemyController1Script;

//	public int curPlayerLife;
//	public int curEnemyLife;
//	public int generateEnemyNum;
//	int PlayerLife = 3;
//	int totalEnemyNum = 50;
//	int totalStagesNum = 1;

	public static int[] stages = { 0, 1, 2, 3 };
	public int curStageNo = 1;
	string stageName;

	enum State{
		Ready,
		Start,
		Play,
		GameOver,
		ReStart
	}

	State state;


	void Start () {
		if (instance == null) {
			instance = this;
		}
		DontDestroyOnLoad (this);

		playerGunCtrlScript = playerGun.GetComponent<PlayerGunController2>();
		enemyController1Script = enemyObj.GetComponent<EnemyController1> ();


		curStageNo = stages[1];
		stageName = "";

		//Start画面作ったら、要変更
		state = State.Play;

	}


	void MoveNextStage(int stageNo){
		string stageName;
		stageName = "Level" + stageNo;

		if (stageNo == 1) {
			SceneManager.LoadScene ("Main");

		}else if((stageNo > 2) && (stageNo <= stages.Length)){
			SceneManager.LoadScene (stageName);
		}
	}

	void CompleteGameScene (){
		SceneManager.LoadScene ("CompleteGame");
	}

	void GameOverScene(){
		SceneManager.LoadScene ("GameOver");
	}

	void ReStartScene(int stageNo){
		// ★Start画面作ったら、要変更
		SceneManager.LoadScene ("Main");
		//		SceneManager.LoadScene ("Start");
	}



}
