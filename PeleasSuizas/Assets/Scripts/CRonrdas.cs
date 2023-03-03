using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CRonrdas : MonoBehaviour
{
    public GameObject ronda1win;
    public GameObject ronda1win2;
   
    [SerializeField] private GameObject controlador; 


    static private float win1P1;
    static private float win1P2;

    public VidaPJ1 vidaUwU1;
    public VidaPJ2 vidaUwU2;
  

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
            win1P2++;     
            if(win1P2 == 1f){
               round2();
            }     
            if(win1P2 == 2f){
               round2();
            }    
            if(win1P2 == 3f)
            {
                SceneManager.LoadScene("Ganador");
            }  
        }


        if(vidaUwU2.vida <= 0)
        {
            win1P1++;
            if(win1P1 == 1f){
               round2();
            } 
            if(win1P1 == 2f){
               round2();
            }  
            if(win1P1 == 3f){
               SceneManager.LoadScene("Ganador");
            }   
        
        }
    
    }

    public void round2()
    {  
        if(vidaUwU1.vida <= 0){
         SceneManager.LoadScene("SampleScene");
        
         print(win1P2);
         print("-----------");
         print(win1P1);
        }
        if(vidaUwU2.vida <= 0){
         SceneManager.LoadScene("SampleScene");
         
         print(win1P1);
         print("-----------");
         print(win1P2);
         
         
        }
        
    }



}
