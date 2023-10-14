using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class CRonrdas : MonoBehaviour
{
    public GameObject ronda1win;
    public GameObject ronda1win2;
    public float contador;
    public GameObject CartelVictoria;

    [SerializeField] private GameObject controlador;
    [SerializeField] private PausaYOtros pausa;

    [SerializeField]private TextMeshProUGUI  MostrarResultados;

    private Movimiento  PJ1;
    private Movimiento2 PJ2;

    private Animator Personaje;
    private Animator Personaje2;

    static private float win1P1 = 0.0f;
    public float WINSPJ1{get => win1P1; set => win1P1 = value; }

    static private float win1P2 = 0.0f;
    public float WINSPJ2{get => win1P2; set => win1P2 = value; }

    public VidaPJ1 vidaUwU1;
    public VidaPJ2 vidaUwU2;
  

    private void Start()
    {
        //CartelVictoria = GameObject.FindGameObjectWithTag("CartelVictoria");
        ronda1win  = GameObject.FindGameObjectWithTag("Ronda1PJ1");
        ronda1win2 = GameObject.FindGameObjectWithTag("Ronda1PJ2");

        GameObject[] ELCartelVictoria = FindObjectsOfType<GameObject>(true);
        foreach (GameObject g in ELCartelVictoria)
        {
            if(g.tag == "CartelVictoria"){
                CartelVictoria = g;
            }
        }

        CartelVictoria.SetActive(false);
    }
    /*void Awake()
    {
        DontDestroyOnLoad(controlador);
    }*/

    void Update()
    {
        MostrarResultados.text = (win1P1.ToString("F0")+ " - " + win1P2.ToString("F0"));
        vidaUwU2   = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<VidaPJ2>();
        vidaUwU1   = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();

        Personaje = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Animator>();
        Personaje2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Animator>();


        PJ2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        PJ1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Movimiento>();

        if (vidaUwU1.vida <= 0 && win1P2 < 3f)
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
                CartelVictoria.SetActive(true);
                Debug.Log(win1P1 + "/" + win1P2);
            }  
        }

        if (vidaUwU2.vida <= 0 && win1P1 < 3f)
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

    public void ReiniciarDeVictoria()
    {
        vidaUwU2.vida ++; // Se aumenta la vida para que no aumente nuevamente la cantidad de victorias de 0 a 1 del vencedor porque
        vidaUwU1.vida ++; // sino se empezaria con 1/0 o 0/1
        win1P1 = 0.0f;
        win1P2 = 0.0f;
        pausa.juegopausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pausa.cartelPausa.SetActive(false);
        Debug.Log(win1P1 + "/" + win1P2);
    }

}
