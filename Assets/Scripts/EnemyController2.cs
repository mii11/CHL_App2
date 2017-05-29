using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour {
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

	// movement
	public float wanderRadius;
	public float wanderTimer;

	private Transform target;
	public NavMeshAgent agentEnemy;
	private float timer;


//★
//	//襲撃の間隔をあける
//	float motionInterval;
//	public Transform target;
//	public Transform[] targets;
	//	public NavMeshAgent agentEnemy;
//	public int curTarget = 0;


	void Start () {
//		motionInterval = 0.0f;
		fullHp = curHp;
		isDead = false;
		enemyBoxCollider = GetComponent<BoxCollider> ();
		coreCapsuleCollider = coreObj.GetComponent<CapsuleCollider> ();

		enemyAnimation = GetComponentInChildren<Animation>();

		enemyInterval = 0.0f;
//		motionInterval = 0.0f;
		enemyHp = hpGauge.transform.parent.gameObject;
		enemySpeed = 0.8f;
	}

	// Use this for initialization
	void OnEnable () {
		agentEnemy = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
	}


	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= wanderTimer) {
			
			if (enemyAnimation == true) {
				if (curHp > 0) {
					switch (enemyAnimation.name) {
					case "SPIDER":
//						EnemyMotion2 ();
						WanderingAI();
//						enemyAnimation.Play ("Idle");
//						EnemyMotion3(transform.position, wanderRadius, -1);
//						EnemyMotion();
						break;
					case "":
						break;
					default:
						break;
					}
				}
			}
			timer = 0;

		}

	}

	void WanderingAI(){
//		Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
		Vector3 newPos = RandomNavSphere2(transform.position, wanderRadius, -1);
		enemyAnimation.Play ("Walk");


		//★★★★向き

		agentEnemy.SetDestination(newPos);

	
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		//ランダムな行き先を決める
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}

	public static Vector3 RandomNavSphere2(Vector3 origin, float dist, int layermask) {
//		//敵はY軸方向にだけ、自分の方向にだけ向かってくる
//		Quaternion q = Quaternion.Euler (0, 180, 0);

		//ランダムな行き先を決める
		float x = Random.Range(- dist, dist);
		float y = 0.0f;
		float z = Random.Range(- dist, dist);

		Vector3 randDirection = new Vector3 (x, y, z);
//		Vector3 randDirection = new Vector3 (Random.Range(-dist, dist), transform.position.y, Random.Range(-dist, dist));

		randDirection += origin;
		//戻り値の変数定義
		NavMeshHit navHit;
		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
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
