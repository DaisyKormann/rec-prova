using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
           float appleSelected;

            switch(appleIndex)
            {
                case 0.5:
                    {

                    }

            }
        }
    }

}

/*
{

    {
        // Se o temporizador chegar a zero ou menos, instancie uma nova maçã.
        {
            // Gera um número aleatório entre 0 e 1 para selecionar o tipo de maçã.

            // Variável para armazenar a maçã selecionada.

            // Seleciona o prefab da maçã baseado no valor de appleIndex.
            {
                // Se appleIndex for 0.5 ou menos, seleciona o primeiro prefab de maçã.

                // Se appleIndex for entre 0.5 e 0.8, seleciona o segundo prefab.

                // Se appleIndex for maior que 0.8, seleciona o terceiro prefab.

            }

            // Usa o NetworkManager para instanciar a maçã selecionada em uma posição aleatória ao longo do eixo X, no topo da tela.

            // Reinicia o temporizador com o valor de cooldown para controlar o intervalo até o próximo spawn.
        }
    }
}
*/
