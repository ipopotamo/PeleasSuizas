using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador2 : MonoBehaviour
{
    void Start()
    {
        
        int indexJugador2 = PlayerPrefs.GetInt("JugadorIndex2");
        Instantiate(GameMMMMANAGER.Instance.PersonajesJugador2[indexJugador2].PersonajeJugable, transform.position, Quaternion.identity);       
    }
}
