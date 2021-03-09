using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class GameManager : Photon.PunBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public Text pingText;
    public GameObject disconnectUI;
    private bool Off = false;

    public GameObject PlayerFeed;
    public GameObject FeedGrid;




    private void Awake()
    {
        GameCanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void CheckInput()
    {
        if(Off &&Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            Off = false;
        }
        else if(!Off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            Off = true;
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }    

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        pingText.text = "Ping: " + PhotonNetwork.GetPing();
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + " joined the game";
        obj.GetComponent<Text>().color = Color.green;
    }
    public override void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + " Left the game";
        obj.GetComponent<Text>().color = Color.red;
    }
}
