using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : MonoBehaviour {
	float bulletInterval;

	public GameObject bullet;
	public GameObject bulletExit;
	public Camera playerCamera;

	//爆発（自機のとこで、敵の弾を爆発）
	public GameObject explosion;

	//HP
//	Sliderと体力
//	public GameObject playerSlider;
	public Slider slider;

	public int curPlayerHp = 100;
	int fullPlayerHp;
	int damageHp = 10;
//	GameObject enemyHp;



	void start(){
		bulletInterval = 0.0f;

//		slider = playerSlider.GetComponent<Slider> ();
//		slider = playerSlider.GetComponent<Slider> ();
		curPlayerHp = 100;
//		slider.maxValue = curPlayerHp;

//		print ("slider.maxVelue初期値は" + slider.maxVelue);
	}

	// Update is called once per frame
	void Update () {
		bulletInterval += Time.deltaTime;

		//スライダーコンポーネントを取得
//		slider = GameObject.Find("Slider").GetComponent<Slider>();

		if(Input.GetKeyDown(KeyCode.Space)){
			print ("space key");
			if (bulletInterval >= 0.2f){
				//キー操作の場合
				GenerateBullet ();	
			}
		}
		//Oculus操作の場合

	}

	void GenerateBullet(){
		bulletInterval = 0.0f;

		//bulletの出現場所決定
		Vector3 pos = bulletExit.transform.position;

		//bulletの方向変更
		//		bullet.transform.rotation = playerCamera.transform.rotation;
		Instantiate (bullet, pos, playerCamera.transform.rotation);
	}

	void OnTriggerEnter(Collider other){
		print ("playerGunのOnTrigger");
		if ((other.gameObject.tag == "LeftArm1") || (other.gameObject.tag == "RightArm1")) {
		//		if (other.gameObject.tag == "Enemy") {

			//Spliderの手にやられた
			curPlayerHp -= damageHp;

			//sliderのvalueに、体力を代入する
			slider.value = curPlayerHp;

			print ("手にやられた　curPlayerHp " + curPlayerHp + " slider.valueは、" + slider.value);

			//体力が0以下になれば、自身がゲームオーバーー
			if (curPlayerHp <= 0) {
				// あとで、削除：弾があたって、爆発したら、弾自身を壊す
				//			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				Destroy (this.gameObject);

				Manager.instance.curPlayerLife--;
				//★					//ハイスコア更新
//				ScoreController obj = GameObject.Find("Main Camera").GetComponent<ScoreController>();
//				obj.SaveHighScore ();
			}

		}	
	}

}
