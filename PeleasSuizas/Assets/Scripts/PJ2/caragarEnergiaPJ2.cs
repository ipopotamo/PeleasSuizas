using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class caragarEnergiaPJ2 : MonoBehaviour
{
    private Slider Energia2;
    private Animator anim;
    private Movimiento2 movi;
    
    void Start()
    {
        Energia2 = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        anim = GetComponent<Animator>();
        movi = GetComponent<Movimiento2>();
    }

    // Update is called once per frame
    void Update()
    {
        Cargar();
    }
    private void Cargar(){
        if (Input.GetButton("Carga2") && movi.ENSUELO == true){
            Energia2.value += 10*(Time.deltaTime);
            anim.SetBool("cargando", true);
            CineMachineControlMovimientoCamara.Instance.MoverCamera(1,1,0.5f);
        }
        if (!Input.GetButton("Carga2")){
            anim.SetBool("cargando", false);
        }

    }
}
