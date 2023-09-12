using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private int rand;
    public AudioClip[] musica;
    private AudioSource audio;
    [SerializeField]private AudioClip Empate;
    [SerializeField] private float volumen = 0.5f;
    [SerializeField] private CRonrdas contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = GameObject.FindGameObjectWithTag("ControlRondas").GetComponent<CRonrdas>();
        rand = Random.Range(0, musica.Length);
        audio = GetComponent<AudioSource>();
        audio.volume = volumen; 
        
        if(contador.WINSPJ2 == 2 && contador.WINSPJ1 == 2){
            audio.clip = Empate;
        }else{
            audio.clip = musica[rand];
        }
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
