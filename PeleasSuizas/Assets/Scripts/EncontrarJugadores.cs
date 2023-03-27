using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EncontrarJugadores : MonoBehaviour
{
    private CinemachineTargetGroup grupo;

    private GameObject Jugador1;
    private GameObject Jugador2;
    private GameObject IA;

    void Start() {
        grupo = GetComponent<CinemachineTargetGroup>();

        Jugador1 = GameObject.FindGameObjectWithTag("Jugador1");
        Jugador2 = GameObject.FindGameObjectWithTag("Jugador2");
        IA = GameObject.FindGameObjectWithTag("IA");

        grupo.AddMember(Jugador1.transform,1,2);
        grupo.AddMember(IA.transform,1,2);
        grupo.AddMember(Jugador2.transform,1,2);
    }


}
