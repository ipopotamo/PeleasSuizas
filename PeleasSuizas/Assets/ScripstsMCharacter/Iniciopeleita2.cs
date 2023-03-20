using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciopeleita2 : MonoBehaviour
{
 
    void Start()
    {
        int indexJugador2 = PlayerPrefs.GetInt("JugadorIndex2");
        Instantiate(GameManager.Instancia.personajes[indexJugador2].persoJugable,transform.position,Quaternion.identity);
    }

 
}
