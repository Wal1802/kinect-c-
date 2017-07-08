using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sigue : MonoBehaviour {

	public GameObject planeta;


	void Update () {
		if (planeta.gameObject.transform.position.x>=0 && planeta.gameObject.transform.position.z<0 ){
			transform.position = new Vector3 (planeta.gameObject.transform.position.x-100f,planeta.gameObject.transform.position.y,planeta.gameObject.transform.position.z-100);
		}
		if (planeta.gameObject.transform.position.x < 0 && planeta.gameObject.transform.position.z < 0) {
		/*	transform.position.x = planeta.gameObject.transform.position.x-30f;
			transform.position.z = planeta.gameObject.transform.position.z;
			transform.position.y = planeta.gameObject.transform.position.y;*/
			transform.position = new Vector3 (planeta.gameObject.transform.position.x-100f,planeta.gameObject.transform.position.y,planeta.gameObject.transform.position.z-100);

		}	
		if (planeta.gameObject.transform.position.x < 0 && planeta.gameObject.transform.position.z >= 0) {
		/*	transform.position.x = planeta.gameObject.transform.position.x+30f;
			transform.position.z = planeta.gameObject.transform.position.z;
			transform.position.y = planeta.gameObject.transform.position.y;*/
			transform.position = new Vector3 (planeta.gameObject.transform.position.x-100f,planeta.gameObject.transform.position.y,planeta.gameObject.transform.position.z+100);
		} 
		if(planeta.gameObject.transform.position.x>=0 && planeta.gameObject.transform.position.z>=0){
			/*transform.position.x = planeta.gameObject.transform.position.x+30f;
			transform.position.z = planeta.gameObject.transform.position.z;
			transform.position.y = planeta.gameObject.transform.position.y;*/
			transform.position = new Vector3 (planeta.gameObject.transform.position.x-100f,planeta.gameObject.transform.position.y,planeta.gameObject.transform.position.z+100);
		}
		transform.LookAt (planeta.transform);
	}
}
