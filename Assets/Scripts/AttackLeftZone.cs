using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLeftZone : MonoBehaviour {
	public GameObject enemyObj;
	EnemyController1 enemyController1Script;

	void Start () {
		enemyController1Script = enemyObj.GetComponent<EnemyController1> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlayerGun") {
			enemyController1Script.attackLeftArm ();
		}

	}

}
