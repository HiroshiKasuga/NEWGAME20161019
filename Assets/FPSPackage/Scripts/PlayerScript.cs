using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {  
	public int playerHP = 3;
	public Text HPLabel;
	public GameObject hp;
	public int jump =1;
	public Text Jump;
	public GameObject jum;
	public GameObject flash;
	public static int DD;

	void Start () {
		hp = GameObject.Find ("PlayerHP");
		HPLabel = hp.GetComponent<Text> ();
		jum = GameObject.Find ("Jump");
		Jump = jum.GetComponent<Text> ();

		
	}
	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {
		HPLabel.text = "playerHP:" + playerHP.ToString ();
		Jump.text = "Jump" + jump.ToString ();
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (jump > 0) {
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 100, 0);
					jump--;
				}


		}
	}

	// ダメージを与えられた時に行いたい命令を書く
	void Damage(){
		playerHP--;
		if (playerHP <= 0) {
			SceneManager.LoadScene ("GameOver");
		}

 
	}



	void OnTriggerEnter(Collider col){

		Debug.Log ("Hit");

		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Heal") {
			playerHP = 15;
			HPLabel.text = "playerHP:" + playerHP.ToString ();
			Destroy (col.gameObject);
		
		}
		if (col.gameObject.tag == "Bakudan"){
			GameObject[] enemys = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach(GameObject enemy in enemys){
				enemy.SendMessage ("Damage");
			}
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "DoubleDamege") {
			DD = 1;
			Invoke ("reset", 10);
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "SpeedUp") {

			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Flash") {
			Instantiate (flash, this.gameObject.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Jump") {
			jump++;
			Jump.text = "Jump" + jump.ToString ();
			Destroy (col.gameObject);

		}

	
	}

	void reset(){
		DD = 0;
		
	}
}
