using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AtaqueAdistanciaVSIA : MonoBehaviour
{
    [SerializeField] private float danio_habilidad;
    private Animator anim;
    [SerializeField] private Transform control;

    private ComboVSIA combo;
    private VidaPJ1IA Mivida;
    
    public Slider Energia;
    [SerializeField] private float EnergiaNecesaria;

    private MovimientoVSIA movim;
    [SerializeField] private float XMetros;
    private float Metros;
    private bool Avanza;
    

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    
    void Start()
    {
        movim = GetComponent<MovimientoVSIA>();
        
        combo = GetComponent<ComboVSIA>();
        anim = GetComponent<Animator>();
        Mivida = GetComponent<VidaPJ1IA>();
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
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
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
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
                if (colisionador.CompareTag("IA")) 
                {
                    colisionador.transform.GetComponent<VidaIa>().TomarDaño(danio_habilidad);
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