using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CRonrdas : MonoBehaviour
{
    public GameObject ronda1win;
    public GameObject ronda1win2;
    public float contador;
    public GameObject CartelVictoria;

    [SerializeField] private GameObject controlador;

    private Movimiento  PJ1;
    private Movimiento2 PJ2;

    private Animator Personaje;
    private Animator Personaje2;

    static private float win1P1;
    static private float win1P2;

    public VidaPJ1 vidaUwU1;
    public VidaPJ2 vidaUwU2;
  

    private void Start()
    {
        CartelVictoria = GameObject.FindGameObjectWithTag("CartelVictoria");
        ronda1win  = GameObject.FindGameObjectWithTag("Ronda1PJ1");
        ronda1win2 = GameObject.FindGameObjectWithTag("Ronda1PJ2");

        vidaUwU2   = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<VidaPJ2>();
        vidaUwU1   = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();

        Personaje = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Animator>();
        Personaje2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Animator>();


        PJ2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        PJ1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Movimiento>();

        CartelVictoria.SetActive(false);
    }
    void Awake()
    {
        DontDestroyOnLoad(controlador);
    }
   
   

    void Update()
    {

        if (vidaUwU1.vida <= 0)
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
                Personaje2.SetTrigger("Victoria");
                PJ2.Fsalto = 0;
                if (Input.GetKey("p") || Input.GetKey("i") || Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    Debug.Log("Nada");
                }
                PJ2.velocidadDeMovimiento = 0;
                //Time.timeScale = 0f;
                CartelVictoria.SetActive(true);
                //SceneManager.LoadScene("Ganador");
                Debug.Log(win1P1 + "/" + win1P2);
            }  
        }

        if (vidaUwU2.vida <= 0)
        {
            win1P1++;
        
            if(win1P1 == 1f){
               round2();
            } 
            if(win1P1 == 2f){
               round2();
            }  
            if(win1P1 == 3f)
            {
                PJ1.velocidadDeMovimiento = 0; 
                //Time.timeScale = 0f;
                //SceneManager.LoadScene("Ganador");
                CartelVictoria.SetActive(true);
                Debug.Log(win1P1 + "/" + win1P2);
            }   
        
        }
    
    }

    public void round2()
    {  
        if(vidaUwU1.vida <= 0){
         SceneManager.LoadScene("SampleScene");
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        if(vidaUwU2.vida <= 0){
         SceneManager.LoadScene("SampleScene");
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        
    }



}
