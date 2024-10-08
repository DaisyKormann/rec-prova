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


            // Usa o NetworkManager para instanciar a ma�� selecionada em uma posi��o aleat�ria ao longo do eixo X, no topo da tela.
            NetworkManager.instance.Instantiate(applesPrefab[3], new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity); timer = cooldown;


        }
    }

}

/*
<<<<<<< HEAD

// Usa o NetworkManager para instanciar a ma�� selecionada em uma posi��o aleat�ria ao longo do eixo X, no topo da tela.

=======
{

    {
        // Se o temporizador chegar a zero ou menos, instancie uma nova ma��.
        {
            // Gera um n�mero aleat�rio entre 0 e 1 para selecionar o tipo de ma��.

            // Vari�vel para armazenar a ma�� selecionada.

            // Seleciona o prefab da ma�� baseado no valor de appleIndex.
            {
                // Se appleIndex for 0.5 ou menos, seleciona o primeiro prefab de ma��.

                // Se appleIndex for entre 0.5 e 0.8, seleciona o segundo prefab.

                // Se appleIndex for maior que 0.8, seleciona o terceiro prefab.

            }

            // Usa o NetworkManager para instanciar a ma�� selecionada em uma posi��o aleat�ria ao longo do eixo X, no topo da tela.

            // Reinicia o temporizador com o valor de cooldown para controlar o intervalo at� o pr�ximo spawn.
        }
    }
}

*/
