using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EncontrarPjIA : MonoBehaviour
{
    private CinemachineTargetGroup grupo;

    private GameObject Jugador1;
    
    private GameObject IA;

    void Start() {
        grupo = GetComponent<CinemachineTargetGroup>();

        Jugador1 = GameObject.FindGameObjectWithTag("Jugador1");
        
        IA = GameObject.FindGameObjectWithTag("IA");

        grupo.AddMember(Jugador1.transform,1,2);
        grupo.AddMember(IA.transform,1,2);
        
    }


}
