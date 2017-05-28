using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour {
	public GameObject enemyObj;
	EnemyController enemyController;


	void Start(){
		//EnemyControllerクラスの変数にenemyオブジェクトのコンポーネントを代入する
		enemyController = enemyObj.GetComponent<EnemyController> ();
	}

	void OnTriggerEnter(Collider other){
		print ("CoreのColliderの中");

		if (other.gameObject.tag == "PlayerBullet") {
			if (gameObject.tag == "Core") {
				//				print ("Core にあたった");
				enemyController.curHp = 0;
				enemyController.Die();
			}
		}

	}
}
