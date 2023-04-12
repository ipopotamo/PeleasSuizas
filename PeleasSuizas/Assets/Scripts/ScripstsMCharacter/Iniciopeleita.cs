using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciopeleita : MonoBehaviour
{
    
    void Start()
    {
        int indexJugador1 = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instancia.person[indexJugador1].persoJugable,transform.position,Quaternion.identity);

    }

 

}
