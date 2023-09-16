using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{


    public Vector3[] pinPositions1 = new Vector3[10];
    public Vector3[] pinPositions2 = new Vector3[10];

    void Start()
    {
        pinPositions1[0] = new Vector3(-62.0f, 4.0f, -13.0f);
        pinPositions1[1] = new Vector3(-64.5f, 4.0f, -15.0f);
        pinPositions1[2] = new Vector3(-64.5f, 4.0f, -11.0f);
        pinPositions1[3] = new Vector3(-67.0f, 4.0f, -16.0f);
        pinPositions1[4] = new Vector3(-67.0f, 4.0f, -10.0f);
        pinPositions1[5] = new Vector3(-67.0f, 4.0f, -13.0f);
        pinPositions1[6] = new Vector3(-69.5f, 4.0f, -9.0f);
        pinPositions1[7] = new Vector3(-69.5f, 4.0f, -12.3f);
        pinPositions1[8] = new Vector3(-69.5f, 4.0f, -14.6f);
        pinPositions1[9] = new Vector3(-69.5f, 4.0f, -17.0f);


        pinPositions2[0] = new Vector3(-62.0f, 4.0f, 13.0f);
        pinPositions2[1] = new Vector3(-64.5f, 4.0f, 15.0f);
        pinPositions2[2] = new Vector3(-64.5f, 4.0f, 11.0f);
        pinPositions2[3] = new Vector3(-67.0f, 4.0f, 16.0f);
        pinPositions2[4] = new Vector3(-67.0f, 4.0f, 10.0f);
        pinPositions2[5] = new Vector3(-67.0f, 4.0f, 13.0f);
        pinPositions2[6] = new Vector3(-69.5f, 4.0f, 9.0f);
        pinPositions2[7] = new Vector3(-69.5f, 4.0f, 12.3f);
        pinPositions2[8] = new Vector3(-69.5f, 4.0f, 14.6f);
        pinPositions2[9] = new Vector3(-69.5f, 4.0f, 17.0f);

    }



    public GameObject pinPrefab;

    public GameObject[] pinList1;
    public GameObject[] pinList2;

    public GameObject setPin(Vector3 pinPos)
    {
        GameObject pin = Instantiate(pinPrefab);
        pin.transform.position = pinPos;

        return pin;
    }

    public void SetPinList1()
    {
        for (int i=0; i<10; i++)
        {
            pinList1[i] = setPin(pinPositions1[i]);     
        }
    }

    public void SetPinList2()
    {
        for (int i = 0; i < 10; i++)
        {
            pinList2[i] = setPin(pinPositions2[i]);
        }
    }

    public void DeletePinList1()
    {
        foreach(GameObject pin in pinList1){
            Destroy(pin);
        }
    }

    public void DeletePinList2()
    {
        foreach (GameObject pin in pinList2)
        {

            Destroy(pin); 
            
        }
    }


    public int HowManyGetScore()
    {

        int score = 0;

        foreach(GameObject pin in pinList2)
        {

            if(pin.transform.eulerAngles.x > 1f)
            {
                score++;
                pin.transform.position = new Vector3(900, 900, 900);
            }
        }

        return score;
    }


}
