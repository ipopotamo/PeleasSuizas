using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPJ1 : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] public float defe;
    public Slider slider;
    private Animator anim;
    private Movimiento movi;

    private VidaPJ2 LavidaDelOtro;
    private IAgeneral IALavidaDelOtro;

    public bool ContraJ2;
    // Start is called before the first frame update
    void Start()
    {
        vida = 200;
        movi = GetComponent<Movimiento>();
        slider = GameObject.FindGameObjectWithTag("VidaPJ1").GetComponent<Slider>();
       
        slider.value = vida;
        anim = GetComponent<Animator>();
        
       if (ContraJ2 == true)
        {
            GameObject jugador2Obj = GameObject.FindGameObjectWithTag("Jugador2");
            if (jugador2Obj != null)
                {
                    LavidaDelOtro = jugador2Obj.GetComponent<VidaPJ2>();
                }
        }
        else
            {
            GameObject iaObj = GameObject.FindGameObjectWithTag("IA");
            if (iaObj != null)
                {
                    IALavidaDelOtro = iaObj.GetComponent<IAgeneral>();
                }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ContraJ2 == true){
            LavidaDelOtro = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<VidaPJ2>();
        }else{
            IALavidaDelOtro = GameObject.FindGameObjectWithTag("IA").GetComponent<IAgeneral>();
        }
        slider.value = vida;
        if(ContraJ2){
            if(vida > 0 && LavidaDelOtro != null && LavidaDelOtro.vida > 0){
                if (Input.GetKey("v") && vida > 0)
                {
                    anim.SetTrigger("Defensa");
                }
                if (Input.GetKey("v") && Input.GetKey("c"))
                {
                    anim.SetTrigger("0");
                }
            }
        }else{
            if(vida > 0 && IALavidaDelOtro != null && IALavidaDelOtro.vida > 0){
                if (Input.GetKey("v") && vida > 0)
                {
                    anim.SetTrigger("Defensa");
                }
                if (Input.GetKey("v") && Input.GetKey("c"))
                {
                    anim.SetTrigger("0");
                }
            }
        }
        

        if (vida <= 0)
            {
                anim.SetTrigger("Muerto");
            }
    }
    public void TomarDaño1(float dano)
    {
        
        if(Input.GetKey("v") && !Input.GetKey("c"))
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
