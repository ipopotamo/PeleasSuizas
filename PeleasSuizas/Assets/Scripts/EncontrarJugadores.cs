using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EncontrarJugadores : MonoBehaviour
{
    private CinemachineTargetGroup grupo;

    

    void Start() {
        grupo = GetComponent<CinemachineTargetGroup>();

    
       int indexJugador1 = PlayerPrefs.GetInt("JugadorIndex");
       int indexJugador2 = PlayerPrefs.GetInt("JugadorIndex2");
       GameObject   pj1 = GameManager.Instancia.person[indexJugador1].persoJugable;
       GameObject   pj2 = GameManager.Instancia.person[indexJugador2].persoJugable;


        grupo.AddMember(pj1.transform,1,2);
        grupo.AddMember(pj2.transform,1,2);
    }
    
}
