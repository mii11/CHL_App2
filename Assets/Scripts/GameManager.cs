using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager managerInstance;

	public Camera cameraObj;
	CameraGUIcontroller cameraScript;

	public int curPlayerLife;
	public int curEnemyLife;
	public int generateEnemyNum;
	int PlayerLife = 3;
	int totalEnemyNum = 50;
	int totalStagesNum = 1;

	//Player自身（player Gun）
	bool isPlayerDead;

	public GameObject playerGun;
	public GameObject enemyObj;
	GameObject enemies;
	PlayerGunController2 playerGunCtrlScript;
	EnemyController1 enemyController1Script;

	public GameObject playerGunPivot;

	public Slider slider;

	float enemyInterval;


	//	float playerInterval;

	void Start(){
		if (managerInstance == null) {
			managerInstance = this;
		}
		DontDestroyOnLoad (this);

		//playerScript = player.GetComponent<PlayerGunController2> ();
		playerGunCtrlScript = playerGun.GetComponent<PlayerGunController2>();
		enemyController1Script = enemyObj.GetComponent<EnemyController1> ();
		cameraScript = cameraObj.GetComponent<CameraGUIcontroller> ();

		curPlayerLife = PlayerLife;
		curEnemyLife = totalEnemyNum;
		generateEnemyNum = 0;

//		cameraScript.tryText.text = "";
		setNullToText();

		//		stageManagerScript = stageManagerObj.GetComponent<StageManager> ();

		enemyInterval = 0.0f;
		//		playerInterval = 0.0f;
		isPlayerDead = false;
		SetActivePlayerGun ();
		enemies = enemyObj.transform.parent.gameObject;
		//		sliderValueSet (100f);


	}
		


	void Update () {

		//敵を生成
		if (generateEnemyNum <= 50) {
			
			enemyInterval += Time.deltaTime;
			if (enemyInterval >= 10.0f) {
				GenerateEnemy ();
//				StartCoroutine ("GenerateEnemy");
			}
		}
	}

	void setNullToText(){
		cameraScript.setStringToText ("");
	}

	void setTryagainToText(){
		cameraScript.setStringToText ("Try again !");
	}

	//敵を生成
//	IEnumerator GenerateEnemy (){
	void GenerateEnemy(){
//		yield return new WaitForSeconds (3.0f);
		Quaternion q = Quaternion.Euler (0, 0, 0);
		//		Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20f), q);
		//ランダムな場所に生成
		GameObject newEnemy = (GameObject)Instantiate (enemyObj, new Vector3 (Random.Range(-40, 40), transform.position.y, Random.Range(-40, 40)), q);
		newEnemy.transform.parent = enemies.gameObject.transform;

		generateEnemyNum += 1;
		enemyInterval = 0.0f;
	}

	//
	// Update is called once per frame
//	void Update () {
//		if (playerScript.getDestroy) {
//			StartCoroutine ("GenerateEnemy");
//			playerScript.getDestroy = false;
//		}
//	}
//
//	IEnumerator GenerateEnemy(){
//		yield return new WaitForSeconds (3.0f);
//		Instantiate(enemy,
//			new Vector3(Random.Range(-stageWidth/2, stageWidth/2), 1, Random.Range(-stageHeight/2,stageHeight/2)),
//			Quaternion.identity);
//
//	}
//


	public void playerFailed(){
		//		if (isPlayerDead == false) {
		SetInActivePlayerGun();
		Invoke("SetInActiveEnemies", 1.5f);
		curPlayerLife--;
		//			isPlayerDead = true;
		//		}

		if (curPlayerLife > 0) {
			//再度、いろりろアクティブにする
			Invoke ("setTryagainToText", 2.0f);
			Invoke ("setNullToText", 4.5f);
			Invoke("SetActivePlayerGun", 5.0f);
			Invoke ("SetActiveEnemies", 6.5f);

		} else if (curPlayerLife == 0) {
			Invoke("playerDie", 3.0f);
		}

	}

	public void playerDie(){
		SceneManager.LoadScene ("GameOver");
	}

	void SetInActiveEnemies(){
		enemies.SetActive (false);	
	}

	void SetActiveEnemies(){
		enemies.SetActive (true);	
	}

	//Playerをアクティブ
	void SetActivePlayerGun(){
//		print ("GunとSliderをアクティブ！で、hp１００に");
		playerGun.SetActive (true);
		playerGunCtrlScript.curPlayerHp = 100;
		slider.gameObject.SetActive (true);
		sliderValueSet (playerGunCtrlScript.curPlayerHp);
		isPlayerDead = false;
	}

	//Playerを非アクティブ
	void SetInActivePlayerGun(){
//		print ("GunとSliderを非アクティブ化");
		playerGun.SetActive (false);
		slider.gameObject.SetActive (false);
	}


	public void sliderValueSet(float hp){
		slider.value = hp;
	}



	//	void GeneratePlayerGun(){
	//bulletの出現場所決定
	//		Vector3 pos = playerGunPivot.transform.position;
	//		//bulletの方向変更
	//		Quaternion q = Quaternion.Euler (0, -90, 0);;
	//		GameObject newPlayerGun = (GameObject) Instantiate (playerGun, pos, q);
	//		newPlayerGun.transform.parent = playerGunPivot.transform;
	//	}

	//	void GeneratePlayerSlider(){
	//		//出現場所決定
	//		Vector3 pos = playerSliderPivot.transform.position;
	//		//方向設定
	//		Quaternion q = Quaternion.Euler (0, 0, 0);;
	//		Slider newSlider = (Slider) Instantiate (slider, pos, q);
	//		newSlider.transform.parent = playerSliderPivot.transform;
	//		sliderValueSet (100f);
	//	}


	//	void ManageStage(){
	//		//		if (state == State.Ready) {
	//		if (playerGunCtrlScript.curPlayerHp <= 0) {
	//			if (curPlayerLife <= 0) {
	//				state = State.GameOver;
	//				print ("GameOver　" + curPlayerLife);
	//				//					GameOverScene ();	
	//			} else {
	//				//				state = State.Play;
	//				//					MoveNextStage (curStageNo);
	//				print ("2,3回目チャレンジ curPlayerLife :" + curPlayerLife);
	//			}
	//		} else {
	//			if (enemyController1Script.curHp <= 0) {
	//				if (curEnemyLife <= 0) {
	//
	//					if (curStageNo >= stages.Length - 1) {
	//						state = State.Ready;
	//						print ("stageクリア");
	//						//							CompleteGameScene ();
	//					} else {
	//						curStageNo += 1;
	//						//							MoveNextStage (curStageNo);
	//					}
	//				}
	//			}
	//		}
	//	}
	/// <summary>
	/// /////////////
	/// </summary>
}

