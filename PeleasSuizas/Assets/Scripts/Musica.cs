using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Musica : MonoBehaviour
{
    private int rand;
    public AudioClip[] musica;
    private AudioSource audio;
    [SerializeField]private AudioClip Empate;
    //[SerializeField] private float volumen = 0.5f;
    private CRonrdas contador;
    [SerializeField] private Slider volumenSlider;

    private SonidoManager SonidoManager;
    // Start is called before the first frame update
    void Start()
    {
        SonidoManager = GameObject.FindGameObjectWithTag("ManagerSonidos").GetComponent<SonidoManager>(); 
        contador = GameObject.FindGameObjectWithTag("ControlRondas").GetComponent<CRonrdas>();
        rand = Random.Range(0, musica.Length);
        audio = GetComponent<AudioSource>();
        volumenSlider.value = SonidoManager.volumenMusica;

        if(contador.WINSPJ2 == 2 && contador.WINSPJ1 == 2){
            audio.clip = Empate;
        }else{
            audio.clip = musica[rand];
        }
        SonidoManager.volumenMusica = volumenSlider.value; 
        audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        SonidoManager.volumenMusica = volumenSlider.value; 
        audio.volume = SonidoManager.volumenMusica; 
    }
}
