using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciarLargaDistanciaPJ1 : MonoBehaviour
{
    [SerializeField]private GameObject AtaqueDespertar;
    [SerializeField]private GameObject AtaqueBase;
    private Animator anim;
    private Combo combo;

    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    [SerializeField]public float TiempoDeVida;
    private float Tiempo;

    [SerializeField] private float EnergiaNecearia;
    private Slider Energia1;

    //Cuenta regresiva para la recarga
    private Image fillableImage;
    private Text textoTiempo;

    private string texto;
    private float tiempoRestante;

    void Start() {

        anim = GetComponent<Animator>();
        Energia1 = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        combo = GetComponent<Combo>();

        textoTiempo = GameObject.FindGameObjectWithTag("TextX").GetComponent<Text>();
        fillableImage = GameObject.FindGameObjectWithTag("ContHabX").GetComponent<Image>();
        
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

        if (Input.GetKey("x") && tiempoSiguienteAtaque <= 0 && Energia1.value >= EnergiaNecearia){
            anim.SetBool("SuperAtaque", true);
            fillableImage.fillAmount = 1;
            textoTiempo.enabled = true;
            tiempoRestante = tiempoEntreAtaques;   
        }       
        
    }

    public void LanzarBase(){
            if (combo.TRANSFORMADOO == false){
                Energia1.value -= EnergiaNecearia;
                Instantiate(AtaqueBase, transform.position, transform.rotation);
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            
    }

    public void LanzarTransform(){
        Energia1.value -= EnergiaNecearia;
        Instantiate(AtaqueDespertar, transform.position, transform.rotation);
        tiempoSiguienteAtaque = tiempoEntreAtaques;
    }
}
