using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueCortaDistancia : MonoBehaviour
{
    [SerializeField] private float danio;
    private Animator anim;
    [SerializeField] private Transform control;
    private Combo combo;
    private VidaPJ1 Mivida;
    public Slider Energia;

    [SerializeField] private float EnergiaNecesaria;

    void Start()
    {
        Energia = GameObject.FindGameObjectWithTag("EnergiaPJ1").GetComponent<Slider>();
        combo = GetComponent<Combo>();
        anim = GetComponent<Animator>();
        Mivida = GetComponent<VidaPJ1>();

        Energia.value = Energia.maxValue;
    }

    
    void Update()
    {
        SuperAtaque();
        combo.atacando = false;
    }

    public void Ataque(){
        if (!Input.GetKeyDown(KeyCode.V)) 
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, combo.radioAtaque);

            foreach (Collider2D colisionador in objetos) {
                if (colisionador.CompareTag("Jugador2")) 
                {
                    colisionador.transform.GetComponent<VidaPJ2>().TomarDaño(danio);
                }
            }

        }
    }


    public void SuperAtaque(){
        if (Input.GetKeyDown(KeyCode.X) && combo.atacando == false && Mivida.vida > 0 && Energia.value >= EnergiaNecesaria){
            Energia.value -= EnergiaNecesaria;
            anim.SetTrigger("SuperAtaque");
            Ataque();
            combo.atacando = true;
        }
    }




}
