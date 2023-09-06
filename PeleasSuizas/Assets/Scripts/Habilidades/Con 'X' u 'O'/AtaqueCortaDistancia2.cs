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

    //Cuenta regresiva para la recarga
    private Image fillableImage;
    private Text textoTiempo;

    private string texto;
    private float tiempoRestante;
    
    void Start()
    {
        movim = GetComponent<Movimiento2>();
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        combo = GetComponent<comboPJ2>();
        anim = GetComponent<Animator>();
        Mivida = GetComponent<VidaPJ2>();
        Energia.value = Energia.maxValue;

        textoTiempo = GameObject.FindGameObjectWithTag("TextX2").GetComponent<Text>();
        fillableImage = GameObject.FindGameObjectWithTag("ContHabX2").GetComponent<Image>();
        
        textoTiempo.enabled = false;
        tiempoRestante = tiempoEntreAtaques;

        
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
        texto = tiempoSiguienteAtaque.ToString("F0");
        textoTiempo.text = texto;

        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        if (tiempoSiguienteAtaque>0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;

            tiempoRestante -= Time.deltaTime;
            float fillAmount = tiempoRestante / tiempoEntreAtaques;
            fillableImage.fillAmount = fillAmount;

            if (tiempoRestante <= 0)
                {
                    tiempoRestante = 0;
                    fillableImage.fillAmount = 0;
                    textoTiempo.enabled = false;
                    // Aquí puedes agregar cualquier lógica adicional que desees cuando el cronómetro llegue a cero.
                }
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

            fillableImage.fillAmount = 1;
            textoTiempo.enabled = true;
            tiempoRestante = tiempoEntreAtaques; 

        }
    }
}
