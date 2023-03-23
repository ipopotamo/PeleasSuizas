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

    void Start() {
        anim = GetComponent<Animator>();
        Energia2 = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        combo = GetComponent<comboPJ2>();
    }

    void Update()
    {
        if (tiempoSiguienteAtaque>0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetKey("o") && tiempoSiguienteAtaque <= 0 && Energia2.value >= EnergiaNecearia){
            anim.SetBool("SuperAtaque", true);
        }       
        
    }

    private void LanzarBase(){
            if (combo.TRANSFORMADOO == false){
                Energia2.value -= EnergiaNecearia;
                Instantiate(AtaqueBase, transform.position, transform.rotation);
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            
    }

    private void LanzarTransform(){
        Energia2.value -= EnergiaNecearia;
        Instantiate(AtaqueDespertar, transform.position, transform.rotation);
        tiempoSiguienteAtaque = tiempoEntreAtaques;
    }

    private void VolverIdle(){
        anim.SetBool("SuperAtaque", false);
    }
}
