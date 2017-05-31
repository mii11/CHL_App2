using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour {
//	public Camera playerCamera;
	public GameObject pivotCamera;
	public GameObject playerGunObj;
//	public GameObject gun;

	void OnTriggerEnter(Collider other){
//		if (other.gameObject.tag == "PlayerBullet") {
//			curHp -= damageHp;
//			hpGauge.fillAmount = (float)curHp / fullHp;
//			if (curHp <= 0) {
//				Die ();
//			}
//		}

//		if (other.gameObject.tag == "PlayerGun") {

			//				print ("生成する");
			//				var newPlayerGun = (GameObject)Instantiate (playerGun, playerCamera.transform.position, Quaternion.identity);
			//				newPlayerGun.transform.parent = playerCamera.transform;
//		}
	}


}
