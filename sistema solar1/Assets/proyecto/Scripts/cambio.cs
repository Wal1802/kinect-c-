using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class cambio : MonoBehaviour {

	// atributos del otro script ******************************
	
		public bool slideChangeWithGestures = true;
		public bool isBehindUser = false;
		private static int MAX=70, MIN=40;
		private GestureListener gestureListener;

	//*********************************************************

	// Atributos de mi script**********************************
	public Camera camara;
		//public Camera[] camaras;

		
		private int escala;
		public GameObject[] planetas;
		private int i=0;
		private int [] fieldView;
		private bool control;
	//*********************************************************
	

    private void Start()
    {
		//inicializacion del otro script **************************
	
		    Cursor.visible = false;

		//slideWaitUntil = Time.realtimeSinceStartup + slideChangeAfterDelay;

		Debug.Log(" INICIOOOOOOO x = " + camara.transform.eulerAngles.x + "// y=" + camara.transform.eulerAngles.y + "z= " + camara.transform.eulerAngles.z);

		gestureListener = Camera.main.GetComponent<GestureListener>();

		//*********************************************************

		

		//Mi inicializacion****************************************
			fieldView = new int[9];
			fieldView[0] = 40;
			fieldView[1] = 8;
			fieldView[2] = 10;
			fieldView[3] = 20;
			fieldView[4] = 15;
			fieldView[5] = 60;
			fieldView[6] = 50;
			fieldView[7] = 40;
			fieldView[8] =40;
		
		//**********************************************************
		decremento();
		control = true;
		
    }
    void Update() {

		moveCamera();

		//pa que no corra si no hay gente presente
		KinectManager kinectManager = KinectManager.Instance;
		//if (!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected())
		//	return;
		
			
		//****************OTRO SCRIPT***********************************************************************************

		if (slideChangeWithGestures && gestureListener)
			{
			
			
			Debug.Log("i= " + i);
			Debug.Log("control= " + control);

			
			/*if  (gestureListener.IsSwipeLeft())  
			{
				incremento();
				
			}
			else if ((gestureListener.IsSwipeRight()) )
			{
				decremento();
			}
			else*/ if ((Input.GetKeyUp(KeyCode.D)|| gestureListener.IsSwipeLeft()) && (i !=8) )
			{		
				//Input.get
				Debug.Log("i== " + i + " Dentro de swipe izquierda");
				if (control == true)
					incremento();
				else
					RotateToNext();
				
			}
			else if ((Input.GetKeyUp(KeyCode.A) || gestureListener.IsSwipeRight()) && (i >=0) )
			{
				Debug.Log("i== " + i + " Dentro de swipe derecha");
				if ((control == false) && i==0)
					decremento();
				else 
					RotateToPrevious();
			
			}

			else if (/* Input.GetKey(KeyCode.I) ||*/ gestureListener.IsPush() && camara.fieldOfView >= MIN)
			{
				Acercar();
				Debug.Log("i== "+i+" Dentro de push");
			}
			else if (/*Input.GetKey(KeyCode.O) ||*/gestureListener.IsPull() && camara.fieldOfView <= MAX)
			{
				alejar();
				Debug.Log("i== " + i + " Dentro de pull");
			}
			/*else if ((size == false) && (i == 0) && ((gestureListener.IsJump() || Input.GetKey(KeyCode.Space))))
			{
				decremento();

			}
			else if ((size == true) && (i == 0) && Input.GetKey(KeyCode.Space))
			{
				incremento();
			}*/

			//moveCamera();


			Debug.Log("x = " + camara.transform.eulerAngles.x + "// y=" + camara.transform.eulerAngles.y + "z= " + camara.transform.eulerAngles.z);
		}
	}
			
		/*else
		{
		}*/
		

   
    private void moveCamera()
    {
		if (i >0 ){
			if (planetas [i].gameObject.transform.position.x >= 0 && planetas [i].gameObject.transform.position.z < 0) {
				camara.transform.position = new Vector3 (planetas [i].gameObject.transform.position.x - 100f, planetas [i].gameObject.transform.position.y, planetas [i].gameObject.transform.position.z - 100);

			}
			if (planetas [i].gameObject.transform.position.x < 0 && planetas [i].gameObject.transform.position.z < 0) {
				camara.transform.position = new Vector3 (planetas [i].gameObject.transform.position.x - 100f, planetas [i].gameObject.transform.position.y, planetas [i].gameObject.transform.position.z - 100);

			}
			if (planetas [i].gameObject.transform.position.x < 0 && planetas [i].gameObject.transform.position.z >= 0) {
				camara.transform.position = new Vector3 (planetas [i].gameObject.transform.position.x - 100f, planetas [i].gameObject.transform.position.y, planetas [i].gameObject.transform.position.z + 100);
			}
			if (planetas [i].gameObject.transform.position.x >= 0 && planetas [i].gameObject.transform.position.z >= 0) {
				camara.transform.position = new Vector3 (planetas [i].gameObject.transform.position.x - 100f, planetas [i].gameObject.transform.position.y, planetas [i].gameObject.transform.position.z + 100);
			}


		}else  if (i == 0  && control==false)  {
			/*camaras [0].transform.Rotate (0, 175, 0);
			camaras [0].transform.position = new Vector3 (0, 0, 315);

			camaras [1].transform.Rotate (0, 0, 0);
			camaras [1].transform.position = new Vector3 (0, 0, -315);

			camaras [2].transform.Rotate (0, 265, 0);
			camaras [2].transform.position = new Vector3 (315, 0, 0);

			camaras [3].transform.Rotate (0, 350 , 0);
			camaras [3].transform.position = new Vector3 (-315, 0, 0);*/


			camara.transform.position = new Vector3(0,0 ,260);
			camara.transform.eulerAngles = new Vector3(0, 180, 0);
			camara.farClipPlane = 2000;


		}



		//camara.fieldOfView = fieldView[i];


		//camara.fieldOfView = 40;
		if (control== false && i>=0)
			camara.transform.LookAt(planetas[i].transform);
		else if(control == true && i>=0)
			camara.transform.LookAt(planetas[i].transform);
	}	


	private void RotateToNext()
	{
		i++;	
	}


	private void RotateToPrevious()
	{
		i--;	
	}

	private void Acercar()
	{
		camara.fieldOfView -= 10;
	}

	private void alejar()
	{
		camara.fieldOfView+=10;
		//camara.fieldOfView = Mathf.Lerp(-camara.fieldOfView, 1, Time.deltaTime * 2);
	}
	private void decremento()
	{
		for (int j = 0; j < 9; j++)
		{
			Vector3 vector = new Vector3 (planetas[j].transform.localScale.x*0.1f , planetas[j].transform.localScale.y * 0.1f, planetas[j].transform.localScale.z * 0.1f);
			planetas[j].transform.localScale = vector;
			vector = new Vector3(planetas[j].transform.position.x*0.1f, planetas[j].transform.position.y*0.1f, planetas[j].transform.position.z*0.1f);
			planetas[j].transform.position = vector;
		}
	
		camara.transform.position = new Vector3(10,450, 0);
		camara.transform.eulerAngles = new Vector3(90, 90, 0);

		control = true;
	}

	private void incremento()
	{
		for (int j=0; j < 9; j++)
		{
			Vector3 vector = new Vector3(planetas[j].transform.localScale.x * 10f, planetas[j].transform.localScale.y * 10f, planetas[j].transform.localScale.z * 10f);
			planetas[j].transform.localScale = vector;
			vector = new Vector3(planetas[j].transform.position.x * 10, planetas[j].transform.position.y*10, planetas[j].transform.position.z *10);
			planetas[j].transform.position = vector;
		}
	
		//camara.transform.position = new Vector3(250, 700, 0);
		//camara.transform.eulerAngles = new Vector3(90, 90, 0);
		camara.transform.position = new Vector3(0, 0, 260);
		camara.transform.eulerAngles = new Vector3(0, 180, 0);
		control = false;
	}

	
}


