using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueLargaDistancia : MonoBehaviour
{
    
    [SerializeField]private float velocidad;
    [SerializeField]private float VeloRotacion;
    private Movimiento2 movi;
    [SerializeField]private Transform Ataque;
    [SerializeField]private bool Rotacion;
    
    [SerializeField]private float TiempoDeVida;

    private Animator anim;
    [SerializeField] private float Dano;
    private Transform pj2;


    private Vector3 newScale; // Copia la escala actual

    void Start() {
        pj2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Transform>();
        movi = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        Destroy(gameObject, TiempoDeVida);
        newScale = Ataque.transform.localScale; // Copia la escala actual
        newScale.x = -newScale.x;               // Invierte la coordenada X
    }

    void Update() {
        /*print(this.transform.position);
        pj2.transform.position = this.transform.position;*/
        anim = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Animator>();
        movi = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        
        if(movi.MIRANDODERECHA == true){
            transform.Translate(Vector3.right * velocidad *Time.deltaTime);
        }
        else {
             Ataque.transform.localScale = newScale; // Aplica el cambio de direccion
            transform.Translate(Vector3.left * velocidad *Time.deltaTime);
        }

        if (Rotacion == true ){
            Ataque.transform.Rotate(Vector3.forward * VeloRotacion * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D colisionador) {
        if (colisionador.CompareTag("Jugador1"))
            {
                movi.VolverIdle();
                movi.VolverAMoverse();
                colisionador.transform.GetComponent<VidaPJ1>().TomarDaño1(Dano);
                Destroy(this.gameObject);
            }
            if (colisionador.CompareTag("Habilidad"))
            {
                movi.VolverIdle();
                movi.VolverAMoverse();
                Destroy(this.gameObject);
            }
    }

}
