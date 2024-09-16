using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPun
{
    string applesPrefab = "Prefabs/Apples";
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

        if (timer <= 0)
        {
            timer = cooldown;

            NetworkManager.instance.Instantiate(applesPrefab, new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity);
            // ver depois a linha de cima quaternion


        }
    }

}

/*
{
    // Array de strings para armazenar os nomes dos prefabs de ma�� que podem ser instanciados.

    // Temporizador que controla o intervalo entre os spawns.
    // Define o tempo de espera entre cada spawn como 1 segundo.


    {
        // Verifica se o cliente atual � o Master Client no Photon.
        {
            // Se for o Master Client, chama o m�todo Spawn para instanciar as ma��s.
        }
    }


    {
        // Diminui o valor do temporizador baseado no tempo decorrido desde o �ltimo frame.

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
