using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


public class CrondasP : MonoBehaviour
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

    public VidaPJ1 vidaUwU1 ;
    public VidaPJ2 vidaUwU2 ;
  
    // SELECTOR CHARACTER

    private GameManager gameManager;
    public static int indexJugador1;

    private string pj1;
    private string pj2;
  
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
   
    public void policia()
    {
       indexJugador1 = PlayerPrefs.GetInt("JugadorIndex");
       int indexJugador2 = PlayerPrefs.GetInt("JugadorIndex2");
       string   pj1 = GameManager.Instancia.person[indexJugador1].nombre;
       string   pj2 = GameManager.Instancia.personajes[indexJugador2].nombre;
       string p1 = pj1+"(Clone)"; 
       string p2 = pj2+"(Clone)"; 

       Personaje  = GameObject.Find(p1).GetComponent<Animator>();
       Personaje2 = GameObject.Find(p2).GetComponent<Animator>();


       PJ2 = GameObject.Find(p2).GetComponent<Movimiento2>();
       PJ1 = GameObject.Find(p1).GetComponent<Movimiento>();
       
             
       vidaUwU2   = GameObject.Find(p2).GetComponent<VidaPJ2>();
       vidaUwU1   = GameObject.Find(p1).GetComponent<VidaPJ1>();

    }

    void Update()
    {
        
        policia();  
   
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
                Personaje.SetTrigger("Victoria");
                PJ1.Fsalto = 0;
                if (Input.GetKey("c") || Input.GetKey("v") || Input.GetKeyDown(KeyCode.W)) 
                {
                    Debug.Log("Nada");
                }
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
         SceneManager.LoadScene("PELEAEJEMPLO");
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        if(vidaUwU2.vida <= 0){
         SceneManager.LoadScene("PELEAEJEMPLO");
         Debug.Log(win1P1 + "/" + win1P2);
         
        }
        
    }
}
