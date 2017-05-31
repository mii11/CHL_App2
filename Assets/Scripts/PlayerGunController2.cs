using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGunController2 : MonoBehaviour {
	//player
	public GameObject gameManagerObj;
	GameManager gameManagerScript;

	float bulletInterval;
	bool notAttackYet;

	public GameObject bullet;
	public GameObject bulletExit;
	public Camera playerCamera;

	//爆発（自機のとこで、敵の弾を爆発）
	public GameObject explosion;


	//Player HP slider
	//	public Slider slider;
	public int curPlayerHp = 100;
	int fullPlayerHp;
	int damageHp = 20;

	// Use this for initialization
	void Start () {
		bulletInterval = 0.0f;
		curPlayerHp = 100;
		notAttackYet = true;

		gameManagerScript = gameManagerObj.GetComponent<GameManager> ();

//		print ("初期値は" + notAttackYet);

	}
	
	// Update is called once per frame
	void Update () {
		bulletInterval += Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.Space)){
			if (bulletInterval >= 0.3f){
				//キー操作の場合
				GenerateBullet ();	
			}
		}

	}

	void GenerateBullet(){
		//bulletの出現場所決定
		Vector3 pos = bulletExit.transform.position;
		//bulletの方向変更
		Quaternion q = playerCamera.transform.rotation;
		//bullet生成
		Instantiate (bullet, pos, q);
		bulletInterval = 0.0f;
	}

	void OnTriggerEnter(Collider other){
		if (notAttackYet == true) {
			if ((other.gameObject.tag == "LeftArm1") || (other.gameObject.tag == "RightArm1")) {
				notAttackYet = false;

				//Spliderの手にやられた
				curPlayerHp -= damageHp;

				//sliderのvalueに、体力を代入する
				//			slider.value = curPlayerHp;
				gameManagerScript.sliderValueSet (curPlayerHp);
				print (other.gameObject.tag + "にやられた。curPlayerHp :" + curPlayerHp);
				notAttackYet = true;

				//体力が0以下になれば、自身がゲームオーバーー
				if (curPlayerHp <= 0) {
					gameManagerScript.playerFailed ();
				}
			}

		}
	}


}

