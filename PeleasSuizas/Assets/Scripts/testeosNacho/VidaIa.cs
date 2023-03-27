using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaIa : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] public float defe;
    private Slider slider;
    private Animator anim;
    private MovimientoIA movi;
    private float daniio_H;

    private VidaPJ1IA LavidaDelOtro;
    // Start is called before the first frame update
    void Start()
    {

        vida = 200;
        movi = GetComponent<MovimientoIA>();
        slider = GameObject.FindGameObjectWithTag("VidaPJ2").GetComponent<Slider>();
        slider.value = vida;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value  = vida;
        LavidaDelOtro = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1IA>();
        slider.value  = vida;
            if (vida > 0 && LavidaDelOtro.vida > 0)
            {
                if (Input.GetKey("p"))
                {
                    anim.SetTrigger("Defensa");
                }

                if (Input.GetKey("p") && Input.GetKey("i")) 
                {
                    anim.SetTrigger("0");
                }
            
            }
        if (vida <= 0) 
        {
            anim.SetTrigger("Muerto");
        }
    }

     public void def()
    {
      

    }

    public void TomarDaño(float dano)
    {
         if(Input.GetKey("p") && !Input.GetKey("i"))
        {
            dano  = dano - defe;
            vida -= dano;           
        }
        
        if(!Input.GetKey("p") && vida>0)
        {
            anim.SetTrigger("LePegan");
            vida -= dano;
        }

        if (vida <= 0)
        {
            anim.SetTrigger("Muerto");
            movi.movi = 0;
            //Debug.Log("Gana el jugador 1");
        }
    }

    public void TomarHabilidad2(float danio_habilidad){
        daniio_H = danio_habilidad;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("HabilidadPJ1") ){
            vida -= daniio_H;
            anim.SetTrigger("LePegan");
        }
    }
}
