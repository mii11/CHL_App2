using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackCentre : MonoBehaviour {
	public EnemyController1 enemyController1Script;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlayerGun") {
			enemyController1Script.attackCentreArm ();

			print ("isAttackCentre OnTrigger" );
		}

	}
		
}
