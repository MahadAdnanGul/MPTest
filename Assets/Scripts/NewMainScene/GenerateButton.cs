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

    public void Generate()
    {
        foreach (Transform child in field.transform)
        {
            Destroy(child.gameObject);
        }
        //Large Object Spawn
        if (dropDownL.text == "Wood")
        {
            Instantiate<GameObject>(largeObjects[0], field.transform);
        }
        else if (dropDownL.text == "Glass")
        {
            Instantiate<GameObject>(largeObjects[1], field.transform);
        }
        else if (dropDownL.text == "Metal")
        {
            Instantiate<GameObject>(largeObjects[2], field.transform);
        }
        //End

        //Medium Object Spawn
        if (dropDownM.text == "Wood")
        {
            Instantiate<GameObject>(mediumObjects[0], field.transform);
        }
        else if (dropDownM.text == "Glass")
        {
            Instantiate<GameObject>(mediumObjects[1], field.transform);
        }
        else if (dropDownM.text == "Metal")
        {
            Instantiate<GameObject>(mediumObjects[2], field.transform);
        }
        //End

        //Small Object Spawn
        if (dropDownS.text == "Wood")
        {
            Instantiate<GameObject>(smallObjects[0], field.transform);
        }
        else if (dropDownS.text == "Glass")
        {
            Instantiate<GameObject>(smallObjects[1], field.transform);
        }
        else if (dropDownS.text == "Metal")
        {
            Instantiate<GameObject>(smallObjects[2], field.transform);
        }

    }
}
