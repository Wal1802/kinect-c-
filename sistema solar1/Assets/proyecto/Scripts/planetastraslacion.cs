using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class planetastraslacion : MonoBehaviour {

	public GameObject sol; // objeto sobre el cual se va a rotar
	public float speed; //velocidad de rotacion

	// Update is called once per frame
	void Update () {
		orbitaAlrededor ();

	}

	public void orbitaAlrededor (){

		transform.RotateAround (sol.transform.position, Vector3.up, speed * Time.deltaTime);  //(objeto sobre el cual se rotara,direccion,velocidad*delta de tiempo)
	}
	
	public void setVelocidad(float velocidad)
	{
		speed = velocidad;
	}

	public float getVelocidad()
	{
		return speed;
	}
}