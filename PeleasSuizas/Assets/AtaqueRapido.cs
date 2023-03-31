using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueRapido : MonoBehaviour
{
    [SerializeField]private float velocidad;
    [SerializeField]private float VeloRotacion;
    private Movimiento movi;
    [SerializeField]private Transform Ataque;
    [SerializeField]private bool Rotacion;
    
    [SerializeField]private float TiempoDeVida;

    private Animator anim;
    [SerializeField] private float Dano;
    private Transform pj1;

    void Start() {
        
        pj1 = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Transform>();
        movi = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Movimiento>();
        movi.MIRANDODERECHA = true;
        Destroy(gameObject, TiempoDeVida);
        
    }

    void Update() {
        print(this.transform.position);
        pj1.transform.position = this.transform.position;

        anim = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Animator>();
        movi = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Movimiento>();
        
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
        if (colisionador.CompareTag("Jugador2"))
            {
                movi.VolverIdle();
                movi.VolverAMoverse();
                colisionador.transform.GetComponent<VidaPJ2>().TomarDaño(Dano);
                Destroy(this.gameObject);
            }
    }
}
