using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController3 : MonoBehaviour {
	//敵
	public GameObject enemy;
	float enemyInterval;

	public GameObject coreObj;
	Animation enemyAnimation;
	BoxCollider enemyBoxCollider;
	CapsuleCollider coreCapsuleCollider;
	bool isDead;

	//HP
	public int curHp = 100;
	int fullHp;
	int damageHp = 10;
	public Image hpGauge;
	GameObject enemyHp;

	//敵にあたったら弾を爆発
	public GameObject explosion;

	public float enemySpeed;
	public float rotateSpeed;
	protected Vector2 wayPoint;
	//★
	//	//襲撃の間隔をあける
	float motionInterval;
	//	public Transform target;
	//	public Transform[] targets;
	//	public NavMeshAgent agent;
	//	public int curTarget = 0;


	void Start () {
		motionInterval = 0.0f;
		fullHp = curHp;
		isDead = false;
		enemyBoxCollider = GetComponent<BoxCollider> ();
		coreCapsuleCollider = coreObj.GetComponent<CapsuleCollider> ();

		enemyAnimation = GetComponentInChildren<Animation>();

		enemyInterval = 0.0f;
		motionInterval = 0.0f;
		enemyHp = hpGauge.transform.parent.gameObject;
		enemySpeed = 0.8f;

	}
	// Update is called once per frame
	void Update () {

		if (enemyAnimation == true) {
			if (curHp > 0) {
				switch (enemyAnimation.name) {
				case "SPIDER":
//					enemyAnimation.Play ("Idle");
					EnemyMotion2();
					break;
				case "":
					break;
				default:
					break;
				}
			}
		}
	}


	//要編集！敵の移動(規則正しく動きすぎ	)
	void wonder(){
		wayPoint = Random.insideUnitCircle * 10;
		enemyAnimation.Play ("Walk");
	}

	void EnemyMotion2(){
		Vector2 dir = wayPoint - new Vector2 (transform.position.x, transform.position.y);
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90.0f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, Time.deltaTime * rotateSpeed);
		transform.position = Vector2.MoveTowards (transform.position, wayPoint, Time.deltaTime * enemySpeed);
		float magnitude = (new Vector2 (transform.position.x, transform.position.y) - wayPoint).magnitude;
		if (magnitude < 3.0f) {
			wonder ();
		}
	}

	//	void EnemyMotion3(Vector3 origin, float dist, int layermask){
	//
	//		//		Quaternion q = Quaternion.Euler (0, 180, 0);
	//
	//			//ランダムな行き先を決める
	//		float x = Random.Range(- dist, dist);
	////		float y = 0.0f;
	//		float y = Random.Range(- dist, dist);
	//		float z = Random.Range(- dist, dist);
	//
	//		Vector3 randDirection = new Vector3 (x, y, z);
	//
	//		transform.Translate (-1 * transform.forward * Time.deltaTime * enemySpeed);	
	//		motionInterval += Time.deltaTime;
	//		print ("intervalは" + motionInterval + ": " + "前");
	//		enemyAnimation.Play ("Walk");
	//
	//
	//		if ((motionInterval >= 0.8f) && (motionInterval < 1.4f)) {
	//			print ("右に移動");
	//			transform.Translate (Vector3.right * Time.deltaTime * enemySpeed);
	//			enemyAnimation.Play ("Walk");
	//		}else if ((motionInterval >= 1.4f) && (motionInterval < 2.0f)) {
	//			print ("左");
	//			transform.Translate (Vector3.left * Time.deltaTime * enemySpeed);
	//			enemyAnimation.Play ("Walk");
	//		}else if(motionInterval >= 2.0f){
	//			motionInterval = 0.0f;			
	//		} 
	//	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "PlayerBullet") {
			curHp -= damageHp;
			hpGauge.fillAmount = (float)curHp / fullHp;
			if (curHp <= 0) {
				Die ();
			}
		}
	}

	void OnTriggerExit(Collider other){

	}

	public void Die(){
		if (isDead == false) {
			if (enemyAnimation == true) {
				switch (enemyAnimation.name) {
				case "SPIDER":
					enemyAnimation.Play ("Death");
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
			Destroy (enemyHp, 3.0f);
			Manager.instance.curEnemyNum -= 1;
			isDead = true;
		}
	}


	//要編集！うまく、いってない
	//	void HpPosition(){
	//		//positionではなく、向きを取得すること
	//★		GameObject gun = Manager.instance.gun.GetComponent<GameObject> ().gameObject;
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

