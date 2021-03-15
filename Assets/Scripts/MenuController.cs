using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class MenuController : PunBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject userNameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;



    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinRandomRoom();
        Debug.Log("CONNECTED");
    }

    public void ChangeUserNameInput()
    {
        if(UsernameInput.text.Length>=3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }
    public void SetUserName()
    {
        userNameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        userNameMenu.SetActive(true);
    }
    public void CreateGame()
    {
        PlayerPrefs.SetInt("PlayerType", 1);
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { MaxPlayers = 5}, null);
        
    }
    public void JoinGame()
    {
        PlayerPrefs.SetInt("PlayerType", 2);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions,TypedLobby.Default);

    }
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
