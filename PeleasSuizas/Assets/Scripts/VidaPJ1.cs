using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPJ1 : MonoBehaviour
{
    [SerializeField] private float vida;
    private Slider slider;
    private Animator anim;
    private Movimiento movi;
    // Start is called before the first frame update
    void Start()
    {

        vida = 100;
        movi = GetComponent<Movimiento>();
        slider = GameObject.FindGameObjectWithTag("VidaPJ1").GetComponent<Slider>();
        slider.value = vida;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = vida;

    }
    public void TomarDaño1(float dano)
    {
        vida -= dano;
        Debug.Log("Me atacan ayudaaaaaaaaaaa");
        if (vida <= 0)
        {
            anim.SetTrigger("Muerto");
            movi.velocidadDeMovimiento = 0;
            //Debug.Log("Gana el jugador 2");
        }
    }
}
