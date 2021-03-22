using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
public class GameManagerNew : Photon.PunBehaviour,IPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject sceneCamera;
    public GameObject sideUI;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("PlayerType",1)==2)
        {
            SpawnPlayer();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }

  

   
    
    

    

    public void SpawnPlayer()
    {
        sideUI.SetActive(false);
        //float randomValue = Random.Range(-1f, 1f);
        sceneCamera.SetActive(false);
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        
    }
}
