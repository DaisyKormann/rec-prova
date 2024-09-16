using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    const float velocity = 10f;
    int direction;
    Rigidbody2D rigidbody2D;

    bool playerLocal;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    [PunRPC]
    private void Initialize()
    {
        if (!photonView.IsMine)
        {
            Color color = Color.white;
            color.a = 0.1f;
            GetComponent<SpriteRenderer>().color = color;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
