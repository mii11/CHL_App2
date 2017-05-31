using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour {
	public GameObject enemyObj;
	EnemyController1 enemyController;
//	EnemyController2 enemyController;
//	EnemyController3 enemyController;


	void Start(){
		//EnemyControllerクラスの変数にenemyオブジェクトのコンポーネントを代入する
		enemyController = enemyObj.GetComponent<EnemyController1> ();
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "PlayerBullet") {
			if (gameObject.tag == "Core") {
				//				print ("Core にあたった");
				enemyController.curHp = 0;
				enemyController.Die();
			}
		}

	}
}
