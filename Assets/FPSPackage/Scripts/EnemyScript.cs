using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	float random;
	public int damage = 1;
	public int enemyHP = 3; // 敵の体力
	public GameObject Bomb; // 爆発のオブジェクト
	public GameObject Jump;
	public GameObject SpeedUp;
	public GameObject Heal;
	public GameObject Bakudan;
	public GameObject Flash;
	public GameObject DoubleDamage;

	// Playerにダメージを与えられた時
	void Damage(){
		enemyHP -= damage; //体力を1減らす。
		// 体力がゼロになったら
		if (enemyHP == 0) {
			if (Bomb) {
				// 爆発を起こす
				Instantiate (Bomb, transform.position, transform.rotation);
			}
			// 敵を倒した数を1増やす
			ScoreManager.instance.enemyCount++;

			Destroy (this.gameObject); //自分をしょうめつさせる

		}
	}
	// 物にさわった時に呼ばれる
	void OnTriggerEnter(Collider col){
		// もしPlayerにさわったら
		if (col.gameObject.tag == "Player") {
			col.SendMessage ("Damage"); //ダメージを与えて
			Destroy (this.gameObject);
		}
	}
	void OnDisable() {
		random = Random.Range (1, 200);
		if (random <= 10.0f) {
			Instantiate (Jump, this.transform.position, this.transform.rotation);
		}
		if (11.0f <= random && random <= 20.0f) {
			Instantiate (SpeedUp,this.transform.position, this.transform.rotation);
		}
		if (21.0f <= random && random <= 30.0f) {	
			Instantiate (Heal,this.transform.position, this.transform.rotation);
		}
		if (31.0f <= random && random <= 40.0f) {
			Instantiate (Bakudan,this.transform.position, this.transform.rotation);
		}
		if (41.0f <= random && random <= 50.0f) {
			Instantiate (Flash,this.transform.position, this.transform.rotation);
		}
		if (51.0f <= random && random<= 60.0f){
			Instantiate(DoubleDamage,this.transform.position,this.transform.rotation);
	    }
	}
}
