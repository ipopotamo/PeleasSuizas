using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // PARA USAR CANVAS

public class CRonrdas : MonoBehaviour
{
    public GameObject ronda1win;
    public GameObject ronda1win2;
    public static int ronda1;
    public static int ronda2;
  
    [SerializeField] private GameObject controlador; 

    public VidaPJ2 vidaUwU2;
    public VidaPJ1 vidaUwU1;

    private void Start()
    {
        ronda1win  = GameObject.FindGameObjectWithTag("Ronda1PJ1");
        ronda1win2 = GameObject.FindGameObjectWithTag("Ronda1PJ2");

    }
    void Awake()
    {
        DontDestroyOnLoad(controlador);
    }
   
    void Update()
    {
        if(vidaUwU1.vida <= 0)
        {
            ronda1++;
            //ronda1win2.SetActive(true);
            print("vegeta gana");
        }

        if(vidaUwU2.vida <= 0)
        {
            ronda2++;
            //ronda1win.SetActive(true);
            print("virgil gana");
        }
    
    }
}
