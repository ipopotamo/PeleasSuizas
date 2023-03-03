using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRonrdas : MonoBehaviour
{
    
    public static int ronda1;
    public static int ronda2;
  
    [SerializeField] private GameObject controlador; 

    public VidaPJ2 vidaUwU2;
    public VidaPJ1 vidaUwU1;

    void Awake()
    {
        DontDestroyOnLoad(controlador);
    }
   
    void Update()
    {
        if(vidaUwU1.vida <= 0)
        {
            ronda1++;
            print("vegeta gana");
        }

        if(vidaUwU2.vida <= 0)
        {
            ronda2++;
            print("virgil gana");
        }
    
    }
}
