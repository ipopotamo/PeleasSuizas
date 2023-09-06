using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstanciarAtaqueDistancia : MonoBehaviour
{
    [SerializeField]private GameObject AtaqueDespertar;
    [SerializeField]private GameObject AtaqueBase;
    private Animator anim;
    private comboPJ2 combo;

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    [SerializeField]public float TiempoDeVida;
    private float Tiempo;

    [SerializeField] private float EnergiaNecearia;
    private Slider Energia2;

    //Cuenta regresiva para la recarga
    private Image fillableImage;
    private Text textoTiempo;

    private string texto;
    private float tiempoRestante;

    void Start() {
        anim = GetComponent<Animator>();
        Energia2 = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        combo = GetComponent<comboPJ2>();

        textoTiempo = GameObject.FindGameObjectWithTag("TextX2").GetComponent<Text>();
        fillableImage = GameObject.FindGameObjectWithTag("ContHabX2").GetComponent<Image>();
        
        textoTiempo.enabled = false;
        tiempoRestante = tiempoEntreAtaques;
    }

    void Update()
    {
        texto = tiempoSiguienteAtaque.ToString("F0");
        textoTiempo.text = texto;
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

        if (Input.GetKey("o") && tiempoSiguienteAtaque <= 0 && Energia2.value >= EnergiaNecearia){
            anim.SetBool("SuperAtaque", true);
            fillableImage.fillAmount = 1;
            textoTiempo.enabled = true;
            tiempoRestante = tiempoEntreAtaques;   
        }       
        
    }

    public void LanzarBase(){
            if (combo.TRANSFORMADOO == false){
                Energia2.value -= EnergiaNecearia;
                Instantiate(AtaqueBase, transform.position, transform.rotation);
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            
    }

    public void LanzarTransform(){
        Energia2.value -= EnergiaNecearia;
        Instantiate(AtaqueDespertar, transform.position, transform.rotation);
        tiempoSiguienteAtaque = tiempoEntreAtaques;
    }
}
