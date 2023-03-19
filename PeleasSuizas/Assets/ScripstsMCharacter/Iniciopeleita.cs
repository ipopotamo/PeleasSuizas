using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciopeleita : MonoBehaviour
{
    private GameObject juan;
    [SerializeField] private GameObject epic;

    private void Start()
    {
        
        int indexJugador01 = PlayerPrefs.GetInt("JugadorIndex");
        juan  = GameManager.Instancia.person[indexJugador01].persoJugable;
        Instantiate(juan,juan.transform);
    }

}
