using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameMMMMANAGER.Instance.Personajes[indexJugador].PersonajeJugable, transform.position, Quaternion.identity);       
    }
}
