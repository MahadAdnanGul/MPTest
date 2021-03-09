using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public GameObject playerCamera;
    public SpriteRenderer sr;
    public Text playernameText;

    public bool isGrounded;
    public float MoveSpeed;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(photonView.isMine)
        {
            playerCamera.SetActive(true);
            playernameText.text = PhotonNetwork.playerName;
            playernameText.color = Color.cyan;
        }
        else
        {
            playernameText.text = photonView.owner.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * MoveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A))
        {
            photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
        }
    }

    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }

}
