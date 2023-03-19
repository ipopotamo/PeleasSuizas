using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciopeleita2 : MonoBehaviour
{
    private GameObject juan;
    
    void Start()
    {
        int indexJugador02 = PlayerPrefs.GetInt("JugadorIndex2");
        juan  = GameManager.Instancia.person[indexJugador02].persoJugable;
        Instantiate(juan,juan.transform);
    }

 
}
