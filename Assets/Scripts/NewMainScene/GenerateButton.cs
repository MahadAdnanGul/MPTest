using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private Text dropDownL;
    [SerializeField] private Text dropDownM;
    [SerializeField] private Text dropDownS;
    [SerializeField] private GameObject[] smallObjects;
    [SerializeField] private GameObject[] mediumObjects;
    [SerializeField] private GameObject[] largeObjects;
    [SerializeField] private GameObject field;

    private Vector3 smallRoomPos = new Vector3(7.5f, 1.25f, -0.5f);
    private Vector3 medRoomPos = new Vector3(0, 1.875f, 5f);
    private Vector3 largeRoomPos = new Vector3(-10f, 2.5f, 10f);

    public void Generate()
    {
        foreach (Transform child in field.transform)
        {
            Destroy(child.gameObject);
        }
        //Large Object Spawn
        if (dropDownL.text == "Wood")
        {
           
            GameObject large = PhotonNetwork.Instantiate(largeObjects[0].name, largeRoomPos,Quaternion.identity,0);
            //large.transform.parent = field.transform;
        }
        else if (dropDownL.text == "Glass")
        {
            GameObject large = PhotonNetwork.Instantiate(largeObjects[1].name, largeRoomPos, Quaternion.identity, 0);
            //large.transform.parent = field.transform;
        }
        else if (dropDownL.text == "Metal")
        {
            GameObject large = PhotonNetwork.Instantiate(largeObjects[2].name, largeRoomPos, Quaternion.identity, 0);
            //large.transform.parent = field.transform;
        }
        //End

        //Medium Object Spawn
        if (dropDownM.text == "Wood")
        {
            GameObject med = PhotonNetwork.Instantiate(mediumObjects[0].name, medRoomPos, Quaternion.identity, 0);
            //med.transform.parent = field.transform;
        }
        else if (dropDownM.text == "Glass")
        {
            GameObject med = PhotonNetwork.Instantiate(mediumObjects[1].name, medRoomPos, Quaternion.identity, 0);
            //med.transform.parent = field.transform;
        }
        else if (dropDownM.text == "Metal")
        {
            GameObject med = PhotonNetwork.Instantiate(mediumObjects[2].name, medRoomPos, Quaternion.identity, 0);
            //med.transform.parent = field.transform;
        }
        //End

        //Small Object Spawn
        if (dropDownS.text == "Wood")
        {
            GameObject small = PhotonNetwork.Instantiate(smallObjects[0].name, smallRoomPos, Quaternion.identity, 0);
            //small.transform.parent = field.transform;
        }
        else if (dropDownS.text == "Glass")
        {
            GameObject small = PhotonNetwork.Instantiate(smallObjects[1].name, smallRoomPos, Quaternion.identity, 0);
            //small.transform.parent = field.transform;
        }
        else if (dropDownS.text == "Metal")
        {
            GameObject small = PhotonNetwork.Instantiate(smallObjects[2].name, smallRoomPos, Quaternion.identity, 0);
            //small.transform.parent = field.transform;
        }

    }
}
