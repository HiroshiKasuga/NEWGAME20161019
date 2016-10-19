using UnityEngine;
using System.Collections;

public class flashban : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("des", 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void des(){
		Destroy (this.gameObject);
	}
	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Enemy") {
			Debug.Log ("やったー");
			col.gameObject.GetComponent<NavMeshAgent> ().speed = 0;		
		}
	}
}
