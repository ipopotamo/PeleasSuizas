using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarOponente : MonoBehaviour
{
    [SerializeField] private bool ContraJ2;
    private VidaPJ1 PJ1;
    void Start()
    {
       PJ1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();
       PJ1.ContraJ2 = ContraJ2;
    }

    // Update is called once per frame
    void Update()
    {
       PJ1.ContraJ2 = ContraJ2;        
    }
}
