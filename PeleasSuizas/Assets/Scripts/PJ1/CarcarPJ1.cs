using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarcarPJ1 : MonoBehaviour
{
    private Slider Energia1;
    private Animator anim;
    
    void Start()
    {
        Energia1 = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cargar();
    }
    private void Cargar(){
        if (Input.GetButton("Carga1")){
            Energia1.value += 10*(Time.deltaTime);
            anim.SetBool("cargando", true);
        }
        if (!Input.GetButton("Carga1")){
            anim.SetBool("cargando", false);
        }

    }
}
