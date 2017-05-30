using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//Player
	public float speedX;
	public float speedY;
	public float speedZ;

	//敵
	public GameObject enemy;
	float enemyInterval;

	void Start(){
		enemyInterval = 0.0f;
	}

	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");


		if (Input.GetKey ("up") || Input.GetKey("down")) {
			if (Input.GetKey (KeyCode.LeftAlt)) {
				MoveUpDown(vertical);
			} else {
				MoveForwardBackward (vertical);
			}
		}

		if (Input.GetKey ("right") || Input.GetKey ("left")) {
			MoveRightLeft(horizontal);
		}

		//敵を生成
		if (Manager.instance.generateEnemyNum <= 50) {
			enemyInterval += Time.deltaTime;
			if (enemyInterval >= 10.0f) {
				GenerateEnemy ();
			}
		}

	}

	//敵を生成
	void GenerateEnemy(){
		Quaternion q = Quaternion.Euler (0, 0, 0);
		enemyInterval = 0.0f;
//		Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20f), q);
		//ランダムな場所に生成
//		Instantiate (enemy, new Vector3 (Random.Range(-10, 10), transform.position.y, transform.position.z + 20), q);
		Instantiate (enemy, new Vector3 (Random.Range(-50, 50), transform.position.y, Random.Range(-50, 50)), q);
		Manager.instance.generateEnemyNum += 1;
	}

	void MoveUpDown(float vertical){
		transform.Translate (0, vertical * speedY, 0); 
	}

	void MoveForwardBackward(float vertical){
		transform.Translate (0, 0, vertical * speedZ); 
	}

	void MoveRightLeft(float horizontal){
		transform.Translate (horizontal * speedX, 0, 0);
	}

//あとで削除
//	void OnTriggerEnter(Collider other){
//		if (other.gameObject.tag == "Enemy") {
//
//
//			print ("★★　自機に弾が当たった");
//
//			//弾があたれば体力を1減らす
//			playerLife--;
//			//sliderのvalueに、体力を代入する
////			slider.value = playerLife;
//			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
//			Destroy (other.gameObject);
//
//			//体力が0以下になれば、戦闘機が爆発
//			if (playerLife <= 0) {
//				Destroy (this.gameObject);
//
////				//ハイスコア更新
////				ScoreController obj = GameObject.Find("Main Camera").GetComponent<ScoreController>();
////				obj.SaveHighScore ();
//			}
//
//		}	
//	}


}
