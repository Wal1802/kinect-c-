using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_sigue_planeta : MonoBehaviour {

	public GameObject planeta;


	void Update () {
		

		transform.LookAt (planeta.transform);

	}
}
