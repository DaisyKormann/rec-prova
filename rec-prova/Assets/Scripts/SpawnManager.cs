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

        // Se o temporizador chegar a zero ou menos, instancie uma nova ma��.
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

            applesPrefab = NetworkManager.instance.Instantiate(, new Vector3(-5, 0), Quaternion.identity).GetComponent<Player>();
        }
    }

}

/*

// Usa o NetworkManager para instanciar a ma�� selecionada em uma posi��o aleat�ria ao longo do eixo X, no topo da tela.
// Reinicia o temporizador com o valor de cooldown para controlar o intervalo at� o pr�ximo spawn.

*/
