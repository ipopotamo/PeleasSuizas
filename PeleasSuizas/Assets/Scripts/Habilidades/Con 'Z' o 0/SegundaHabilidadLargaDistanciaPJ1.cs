using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegundaHabilidadLargaDistanciaPJ1 : MonoBehaviour
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


    void Start() {
        anim = GetComponent<Animator>();
        Energia1 = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        combo = GetComponent<Combo>();
    }

    void Update()
    {
        if (tiempoSiguienteAtaque>0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetKey("z") && tiempoSiguienteAtaque <= 0 && Energia1.value >= EnergiaNecearia){
            anim.SetBool("SuperAtaque2", true);
        }       
        
    }

    public void da2LanzarBase(){
            if (combo.TRANSFORMADOO == false){
                Energia1.value -= EnergiaNecearia;
                Instantiate(AtaqueBase, transform.position, transform.rotation);
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            
    }

    public void da2LanzarTransform(){
        Energia1.value -= EnergiaNecearia;
        Instantiate(AtaqueDespertar, transform.position, transform.rotation);
        tiempoSiguienteAtaque = tiempoEntreAtaques;
    }
}
