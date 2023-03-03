using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPJ2 : MonoBehaviour
{
    [SerializeField]public float vida;
    [SerializeField] public float defe;
    private Slider slider;
    private Animator anim;
    private Movimiento2 movi;
    // Start is called before the first frame update
    void Start()
    {

        vida = 100;
        movi = GetComponent<Movimiento2>();
        slider = GameObject.FindGameObjectWithTag("VidaPJ2").GetComponent<Slider>();
        slider.value = vida;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = vida;        
    }

     public void def()
    {
      

    }

    public void TomarDaño(float dano)
    {
         if(Input.GetKey("p"))
        {
            dano  = dano - defe;
            vida -= dano;           
        }
        
        if(!Input.GetKey("p"))
        {
           vida -= dano;
        }
        

        if (vida <= 0)
        {
            anim.SetTrigger("Muerto");
            movi.velocidadDeMovimiento = 0;
            //Debug.Log("Gana el jugador 1");
        }
    }
}
