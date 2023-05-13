using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class caragarEnergiaPJ2 : MonoBehaviour
{
    private Slider Energia2;
    private Animator anim;
    
    void Start()
    {
        Energia2 = GameObject.FindGameObjectWithTag("EnergiaPJ2").GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cargar();
    }
    private void Cargar(){
        if (Input.GetButton("Carga2")){
            Energia2.value += 10*(Time.deltaTime);
            anim.SetBool("cargando", true);
        }
        if (!Input.GetButton("Carga2")){
            anim.SetBool("cargando", false);
        }

    }
}
