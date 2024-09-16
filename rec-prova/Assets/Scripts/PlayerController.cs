using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEditor;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviourPun
{
    const float speed = 10f;
    float direction;
    Rigidbody2D rigidbody2D;

    bool playerLocal;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    [PunRPC]
    void Initialize()
    {
        playerLocal = photonView.IsMine;

        if (!playerLocal)
        {
            Color color = Color.white;
            color.a = 0.2f;
            GetComponent<SpriteRenderer>().color = color; 
        }
    }

    void Update()
    {
        if (playerLocal) 
        {
            direction = Input.GetAxis("Horizontal");
        }

        Move();
    }
    
    void Move()
    {
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);
        Vector3 position = transform.position;

        float screenboundsX = GameManager.Instance.GetscreenBounds().x;
        position.x = Mathf.Clamp(position.x, -screenboundsX, screenboundsX);

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple") && playerLocal)
        {
            int AppleScoreValue = GetComponent<Apple>().GetScoreValue();

        }

        /* 
       
        PhotonView.Get(GameManager.Instance).RPC("AddScore", RpcTarget.All, xScoreValue);
        PhotonNetwork.Destroy(collision.gameObject); 
         if (collision.gameObject.tag == "Obstacle")
            {
                photonView.RPC("ReduceLife", RpcTarget.All);
                GameManager.instance.photonView.RPC("SetScore", RpcTarget.All, -10);
            }
            else if (collision.gameObject.tag == "Score")
            {
                GameManager.instance.photonView.RPC("SetScore", RpcTarget.All, 1);
            }
         */
    }
}
