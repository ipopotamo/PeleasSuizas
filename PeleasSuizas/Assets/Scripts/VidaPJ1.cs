using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPJ1 : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] public float defe;
    private Slider slider;
    private Animator anim;
    private Movimiento movi;

    // Start is called before the first frame update
    void Start()
    {

        vida = 100;
        movi = GetComponent<Movimiento>();
        slider = GameObject.FindGameObjectWithTag("VidaPJ1").GetComponent<Slider>();
        slider.value = vida;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = vida;

        if (Input.GetKey("v"))
        {
            anim.SetTrigger("Defensa");
        }
        if (Input.GetKey("v") && Input.GetKey("c"))
        {
            anim.SetTrigger("0");
        }
        if (vida <= 0)
        {
            anim.SetTrigger("Muerto");
        }
    }
    public void TomarDaño1(float dano)
    {
        
        if(Input.GetKey("v"))
        {
            dano  = dano - defe;
            vida -= dano;           
        }
        
        if(!Input.GetKey("v") && vida > 0)
        {
            anim.SetTrigger("LePegan");
            vida -= dano;
        }
        if (vida <= 0)
        {
            anim.SetTrigger("Muerto");
            movi.velocidadDeMovimiento = 0;
        }
    }
}
