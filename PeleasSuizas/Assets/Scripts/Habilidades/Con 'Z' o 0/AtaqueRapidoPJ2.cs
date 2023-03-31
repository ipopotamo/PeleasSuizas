using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueRapidoPJ2 : MonoBehaviour
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

    void Start() {
        pj2 = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Transform>();
        movi = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        Destroy(gameObject, TiempoDeVida);
        
    }

    void Update() {
        print(this.transform.position);
        pj2.transform.position = this.transform.position;
        anim = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Animator>();
        movi = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Movimiento2>();
        
        if(movi.MIRANDODERECHA == true){
            transform.Translate(Vector3.right * velocidad *Time.deltaTime);
        }
        else {
            Ataque.transform.localScale = new Vector3 (-2,2,1);
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
    }
}
