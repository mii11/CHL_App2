using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController1 : MonoBehaviour {
	public GameObject coreObj;
	Animation enemyAnimation;
	BoxCollider enemyBoxCollider;
	CapsuleCollider coreCapsuleCollider;
	bool isDead;

	public GameObject AttackCentreZone;
	public GameObject AttackLeftZone;
	public GameObject AttackRightZone;

	//HP
	public int curHp = 100;
	int fullHp;
	int damageHp = 10;
	public Image hpGauge;
	GameObject enemyHp;

	//敵にあたったら弾を爆発
	public GameObject explosion;

	public float enemySpeed;

	//★
	//	//襲撃の間隔をあける
	float motionInterval;
	//	public Transform target;
	//	public Transform[] targets;
	//	public NavMeshAgent agent;
	//	public int curTarget = 0;


	void Start () {
		fullHp = curHp;
		isDead = false;
		motionInterval = 0.0f;

		enemyBoxCollider = GetComponent<BoxCollider> ();
		coreCapsuleCollider = coreObj.GetComponent<CapsuleCollider> ();

		enemyAnimation = GetComponentInChildren<Animation>();

		enemyHp = hpGauge.transform.parent.gameObject;
//		enemySpeed = 0.8f;
//		isAttackCentre = false;
	}

	// Update is called once per frame
	void Update () {
//		print ("curHp" + curHp);
		motionInterval += Time.deltaTime;

		if (curHp > 0) {
			if (enemyAnimation == true) {
				switch (enemyAnimation.name) {
				case "SPIDER":
					enemyIdle ();
					break;

				case "":
					break;
				default:
					break;
				}
			}
		}

	}

	public void attackCentreArm(){
		enemyAnimation.CrossFadeQueued("Attack", 0.3F, QueueMode.PlayNow);
	}

	public void attackLeftArm(){
		enemyAnimation.CrossFadeQueued("Attack_Left", 0.3F, QueueMode.PlayNow);
	}

	public void attackRightArm(){
		enemyAnimation.CrossFadeQueued ("Attack_Right", 0.3f, QueueMode.PlayNow);
	}


	void enemyIdle(){
		if (motionInterval >= 0.8f) {
			enemyAnimation.PlayQueued("Idle");
			motionInterval = 0;
		}
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PlayerBullet") {
			curHp -= damageHp;
			hpGauge.fillAmount = (float)curHp / fullHp;
			if (curHp <= 0) {
				Die ();
			}
		}
	}
		

//	void OnTriggerExit(Collider other){
//
//	}

	public void Die(){
		if (isDead == false) {
			if (enemyAnimation == true) {
				switch (enemyAnimation.name) {
				case "SPIDER":
//					enemyAnimation.PlayQueued ("Death");
					enemyAnimation.CrossFadeQueued ("Death", 0.3f, QueueMode.PlayNow);
					break;
				case "":
					Instantiate (explosion, transform.position, Quaternion.identity);
					break;
				default:
					break;
				}

			}
			Destroy (enemyBoxCollider);
			Destroy (coreCapsuleCollider);
			Destroy (AttackCentreZone);
			Destroy (AttackLeftZone);
			Destroy (AttackRightZone);
			Destroy (enemyHp, 5.0f);
			GameManager.managerInstance.curEnemyLife -= 1;
			isDead = true;
		}
	}



	//要編集！敵の移動(規則正しく動きすぎ	)
	void EnemyMotion1(){
		transform.Translate (-1 * transform.forward * Time.deltaTime * enemySpeed);	

		motionInterval += Time.deltaTime;
//		print ("intervalは" + motionInterval + ": " + "前");
		enemyAnimation.PlayQueued ("Walk");


		if ((motionInterval >= 0.8f) && (motionInterval < 1.4f)) {
//			print ("右に移動");
			transform.Translate (Vector3.right * Time.deltaTime * enemySpeed);
			enemyAnimation.PlayQueued ("Walk");
		}else if ((motionInterval >= 1.4f) && (motionInterval < 2.0f)) {
//			print ("左");
			transform.Translate (Vector3.left * Time.deltaTime * enemySpeed);
			enemyAnimation.PlayQueued ("Walk");
		}else if(motionInterval >= 2.0f){
			motionInterval = 0.0f;			
		} 
	}
		
	//要編集！うまく、いってない
	//	void HpPosition(){
	//		//positionではなく、向きを取得すること
	//★		GameObject gun = .managerInstance.gun.GetComponent<GameObject> ().gameObject;
	//		print ("gun.name" + gun.name);
	//
	//		Vector3 gunPos;
	//		gunPos.x = gun.transform.position.x;
	//		gunPos.y = gun.transform.position.y;
	//		gunPos.z = gun.transform.position.z;
	//
	//		//		gunPos.x = gunTransform.position.x;
	//		//		gunPos.y = gunTransform.position.y;
	//		//		gunPos.z = gunTransform.position.z;
	//
	//		hpGauge.transform.parent.transform.position = gunPos;
	//
	//	}


}

