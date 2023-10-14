using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarcarPJ1 : MonoBehaviour
{
    private Slider Energia1;
    private Animator anim;
    private Movimiento movi;
    
    void Start()
    {
        Energia1 = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        movi = GetComponent<Movimiento>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cargar();
    }
    private void Cargar(){
        if (Input.GetButton("Carga1") && movi.ENSUELO == true){
            Energia1.value += 10*(Time.deltaTime);
            anim.SetBool("cargando", true);
            CineMachineControlMovimientoCamara.Instance.MoverCamera(1,1,0.5f);
        }
        if (!Input.GetButton("Carga1")){
            anim.SetBool("cargando", false);
        }

    }
}
