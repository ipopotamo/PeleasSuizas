using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueCortaDistancia2 : MonoBehaviour
{
    [SerializeField] private float danio_habilidad;
    private Animator anim;
    [SerializeField] private Transform control;

    private comboPJ2 combo;
    private VidaPJ2 Mivida;
    
    public Slider Energia;
    [SerializeField] private float EnergiaNecesaria;

    private Movimiento2 movim;
    [SerializeField] private float XMetros;
    private float Metros;
    private bool Avanza;
    

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    
    void Start()
    {
        movim = GetComponent<Movimiento2>();
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        combo = GetComponent<comboPJ2>();
        anim = GetComponent<Animator>();
        Mivida = GetComponent<VidaPJ2>();
        Energia.value = 50;
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
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        if (tiempoSiguienteAtaque>0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        Metros = XMetros;

        SuperAtaque();
        combo.atacando = false;
    }

    public void Ataque(){
        if (!Input.GetKeyDown(KeyCode.P)) 
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, combo.radioAtaque);

            foreach (Collider2D colisionador in objetos) {
                if (colisionador.CompareTag("Jugador1")) 
                {
                    colisionador.transform.GetComponent<VidaPJ1>().TomarDaño1(danio_habilidad);
                }
            }

        }
    }

    private void MoverAHORA(){
        DondeIr();
    }

    public void SuperAtaque(){
        if (Input.GetKeyDown(KeyCode.O) && combo.atacando == false && Mivida.vida > 0 && Energia.value >= EnergiaNecesaria && movim.ENSUELO == true && tiempoSiguienteAtaque <= 0){
            tiempoSiguienteAtaque = tiempoEntreAtaques;
            Energia.value -= EnergiaNecesaria;
            anim.SetTrigger("SuperAtaque");
            //Ataque();
            Avanza = true;
            //DondeIr();
            combo.atacando = true;
        }
    }
}
