using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estela : MonoBehaviour
{

   [SerializeField] private ParticleSystem estela;
    private float velocidadDeReproduccion = 1.0f; // Puedes ajustar esta velocidad según tus necesidades

    void Start()
    {
        estela.playbackSpeed = velocidadDeReproduccion; // Establece la velocidad de reproducción al iniciar
        estela.Play(); // Reproduce el sistema de partículas
    }

    void Update()
    {
            velocidadDeReproduccion = 2.0f; // Cambia la velocidad a 2x cuando se presiona la barra espaciadora
            estela.playbackSpeed = velocidadDeReproduccion; // Aplica el cambio de velocidad
    }

    private void PlayEstela(){
        estela.Play();
    }
}

