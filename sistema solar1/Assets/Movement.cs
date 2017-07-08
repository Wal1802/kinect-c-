using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Use this for initialization
    public Vector3 Rotation;
    public int rotationVertical;
    public int rotationHorizontal;
    public  Quaternion finalRotation;
    private void Start()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position= new Vector3(0,0,0);
        rotationHorizontal = rotationVertical = 0;        
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotateRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotateUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rotateDown();
        }


    }
    void rotateLeft()
    {
        rotationHorizontal--;
        if(rotationHorizontal==-1)
        {
            rotationHorizontal = 3;
            
        }
        if(rotationVertical==0 || rotationVertical==2)
            transform.Rotate(new Vector3(0, -90, 0));
        if (rotationVertical == 1 || rotationVertical==3)
            transform.Rotate(new Vector3(0, 0, -90));
        

    }
    void rotateUp()
    {
        rotationVertical ++;
        if (rotationVertical == 4)
        {
            rotationVertical = 0;

        }
        if (rotationHorizontal == 0 || rotationHorizontal == 2)
            transform.Rotate(new Vector3(90, 0, 0));
        if (rotationHorizontal == 1 || rotationHorizontal == 3)
            transform.Rotate(new Vector3(0, 0, 90));
    }
    void rotateDown()
    {
        rotationVertical--;
        if (rotationVertical == -1)
        {
            rotationVertical = 3;

        }

        if(rotationHorizontal==0 || rotationHorizontal == 2)
            transform.Rotate(new Vector3(-90, 0, 0));
        if (rotationHorizontal == 1 || rotationHorizontal == 3)
            transform.Rotate(new Vector3(0, 0, -90));
    }
    void rotateRight()
    {
        rotationHorizontal++;
        if (rotationHorizontal == 4)
        {
            rotationHorizontal = 0;

        }
        if (rotationVertical == 0 || rotationVertical == 2)
            transform.Rotate(new Vector3(0, 90, 0));
        if (rotationVertical == 1 || rotationVertical == 3)
            transform.Rotate(new Vector3(0, 0, 90));

    }

    void setGreen()
    {
        transform.localEulerAngles=new Vector3(0, 90, 0);
    }
    void setYellow()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    void setBlue()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    void setRed()
    {
        transform.localEulerAngles = new Vector3(0, 270, 0);
    }
}
