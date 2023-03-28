using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class CrondasIA : MonoBehaviour
{
    public GameObject ronda1win;
    public GameObject ronda1win2;
    public float contador;
    public GameObject CartelVictoria;

    [SerializeField] private GameObject controlador;

    private MovimientoVSIA   PJ1;
    private MovimientoIA     PJ2;

    private Animator Personaje;
    private Animator Personaje2;

    static private float win1P1;
    static private float win1P2;

    public VidaPJ1IA vidaUwU1;
    public VidaIa  vidaUwU2;
  

    private void Start()
    {
        CartelVictoria = GameObject.FindGameObjectWithTag("CartelVictoria");
        ronda1win  = GameObject.FindGameObjectWithTag("Ronda1PJ1");
        ronda1win2 = GameObject.FindGameObjectWithTag("Ronda1PJ2");

        CartelVictoria.SetActive(false);
    }
    void Awake()
    {
        DontDestroyOnLoad(controlador);
    }
   
   

    void Update()
    {
        vidaUwU2   = GameObject.FindGameObjectWithTag("IA").GetComponent<VidaIa>();
        vidaUwU1   = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1IA>();

        Personaje = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Animator>();
        Personaje2 = GameObject.FindGameObjectWithTag("IA").GetComponent<Animator>();


        PJ2 = GameObject.FindGameObjectWithTag("IA").GetComponent<MovimientoIA>();
        PJ1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<MovimientoVSIA>();

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
                //PJ2.Fsalto = 0;
                if (Input.GetKey("p") || Input.GetKey("i") || Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    Debug.Log("Nada");
                }
                PJ2.movi = 0;
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
                Personaje.SetTrigger("Victoria");
                PJ1.Fsalto = 0;
                if (Input.GetKey("c") || Input.GetKey("v") || Input.GetKeyDown(KeyCode.W)) 
                {
                    Debug.Log("Nada");
                }
                PJ1.velocidadDeMovimiento = 0; 
                CartelVictoria.SetActive(true);
                Debug.Log(win1P1 + "/" + win1P2);
            }   
        
        }
    
    }

    public void round2()
    {  
        if(vidaUwU1.vida <= 0){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        if(vidaUwU2.vida <= 0){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        
    }



}
