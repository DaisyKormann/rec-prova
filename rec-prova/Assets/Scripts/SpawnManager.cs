using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;

public class SpawnManager : MonoBehaviourPun
{
    public string[] applesPrefab = { "GoldApple", "GreenApple", "RedApple" };
    float timer;
    const float cooldown = 1;

    void Update()
    {
        if (NetworkManager.instance.IsMasterClient)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        timer -= Time.deltaTime;

        // Se o temporizador chegar a zero ou menos, instancie uma nova maçã.
        if (timer <= 0)
        {

           float appleIndex = Random.Range(0, 1);
           string appleSelected;

            switch(appleIndex)
            {
                case <= 0.5f:
                    {
                        appleSelected = "GoldApple";
                        break;
                    }

                case > 0.5f and <= 0.8f:
                    {
                        appleSelected = "GreenApple";
                        break;
                    }
                case >= 0.8f:
                    {
                        appleSelected = "RedApple";
                        break;
                    }

            }

            // Usa o NetworkManager para instanciar a maçã selecionada em uma posição aleatória ao longo do eixo X, no topo da tela.
            NetworkManager.instance.Instantiate(applesPrefab, new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity);
            timer = cooldown;

        }
    }

}

/*

// Usa o NetworkManager para instanciar a maçã selecionada em uma posição aleatória ao longo do eixo X, no topo da tela.

*/
