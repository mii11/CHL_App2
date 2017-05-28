using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	float bulletInterval;

	public GameObject bullet;
	public GameObject bulletExit;
	public Camera playerCamera;
	//	public float speed = 20;


	void start(){
		bulletInterval = 0.0f;
	}

	// Update is called once per frame
	void Update () {

		bulletInterval += Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.Space)){
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

}
