using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueCortaDistancia : MonoBehaviour
{
    [SerializeField] private float danio_habilidad;
    private Animator anim;
    [SerializeField] private Transform control;

    private Combo combo;
    private VidaPJ1 Mivida;
    
    public Slider Energia;
    [SerializeField] private float EnergiaNecesaria;

    private Movimiento movim;
    [SerializeField] private float XMetros;
    private float Metros;
    private bool Avanza;
    

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    
    void Start()
    {
        movim = GetComponent<Movimiento>();
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        combo = GetComponent<Combo>();
        anim = GetComponent<Animator>();
        Mivida = GetComponent<VidaPJ1>();

        Energia.value = Energia.maxValue;

        
    }

    private void DondeIr(){
        if (Avanza == true && movim.MIRANDODERECHA == false){
            
            Metros *= -100000;
            movim.Mover(Metros, false);
        }
        if (Avanza == true && movim.MIRANDODERECHA == true){
            Metros *= 100000;
            movim.Mover(Metros, false);
        }
    }

    void Update()
    {
        if (tiempoSiguienteAtaque>0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        Metros = XMetros;

        SuperAtaque();
        combo.atacando = false;
    }

    public void Ataque(){
        if (!Input.GetKeyDown(KeyCode.V)) 
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, combo.radioAtaque);

            foreach (Collider2D colisionador in objetos) {
                if (colisionador.CompareTag("Jugador2")) 
                {
                    colisionador.transform.GetComponent<VidaPJ2>().TomarDaño(danio_habilidad);
                }
            }

        }
    }


    public void SuperAtaque(){
        if (Input.GetKeyDown(KeyCode.X) && combo.atacando == false && Mivida.vida > 0 && Energia.value >= EnergiaNecesaria && movim.ENSUELO == true && tiempoSiguienteAtaque <= 0){
            tiempoSiguienteAtaque = tiempoEntreAtaques;
            Energia.value -= EnergiaNecesaria;
            anim.SetTrigger("SuperAtaque");
            //Ataque();
            Avanza = true;
            DondeIr();
            combo.atacando = true;
        }
    }



}
