using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLeft : MonoBehaviour {
	public EnemyController1 enemyController1Script;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlayerGun") {
			enemyController1Script.attackLeftArm ();

			print ("isAttackLeft のOnTrigger" );
		}

	}

}
