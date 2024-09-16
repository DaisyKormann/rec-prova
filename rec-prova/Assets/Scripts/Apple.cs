using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;
using Photon.Pun.Demo.PunBasics;
using static UnityEditor.Progress;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Apple : MonoBehaviourPun
{
    const float speed = 5f;
    [SerializeField] int score;
    Rigidbody2D rigidbody2D;
    public int Score { get => score; set => score = value; }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = Vector2.down * speed;

        if (transform.position.y < -GameManager.instance.ScreenBounds.y)
        {
            photonView.RPC("Destroy", RpcTarget.All);
        }
    }

    [PunRPC]
    void DestroyRPC()
    {
        Destroy(gameObject);
    }
}
