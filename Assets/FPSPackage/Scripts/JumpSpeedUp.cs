using UnityEngine;
using System.Collections;

public class JumpSpeedUp : MonoBehaviour {
	public float Speed = 60f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")){
			transform.position += transform.forward*Speed;
		}
		if (Input.GetKey ("a")){
			transform.position -= transform.right*Speed;
		}
		if (Input.GetKey ("d")){
			transform.position +=transform.right*Speed;
		}
		if (Input.GetKey ("s")){
			transform.position -= transform.forward*Speed;
		}
		
	
	}
}


