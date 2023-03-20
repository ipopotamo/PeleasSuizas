using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador1 : MonoBehaviour
{
    
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameMMMMANAGER.Instance.Personajes[indexJugador].PersonajeJugable, transform.position, Quaternion.identity);       
    }
}
