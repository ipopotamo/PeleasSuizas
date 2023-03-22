using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] private Transform control;
    [SerializeField] public float radioAtaque;
    [SerializeField] private float Dano;

    private bool puedeTransformarse = false;
    private bool transformado = false;

    private VidaPJ1 Mivida;

    public Animator anim;
    public int combo;
   // [SerializeField] public Movimiento moviminto;
    public bool atacando;
    public AudioSource audio_s;
    public AudioClip[] sonido;
    
    void Start()
    {
        Mivida = GetComponent<VidaPJ1>();
        //moviminto = GetComponent<Moviminto>();
        anim = GetComponent<Animator>();
        audio_s = GetComponent<AudioSource>();
    }

    

    private void Golpe() {

        if (!Input.GetKeyDown(KeyCode.V)) 
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, radioAtaque);

            foreach (Collider2D colisionador in objetos) {
                if (colisionador.CompareTag("Jugador2")) 
                {
                    colisionador.transform.GetComponent<VidaPJ2>().TomarDaño(Dano);
                }
            }

        }
    }
    public void Combos() {
        if (Input.GetKeyDown(KeyCode.C) && !atacando && Mivida.vida > 0) {
            Golpe();
            atacando = true;
            anim.SetTrigger("" + combo);
            //audio_s.clip = sonido[combo];
            //audio_s.Play();
        }
    }



    public void EMPEZAR_COMBO() {
        //moviminto.velocidadDeMovimiento = 0;
        atacando = false;
        if (combo < 3) {
            combo++;
        }
    }

    public void Final_Combo() {
        //movimiento.velocidadDeMovimiento = 400;
        atacando = false;
        combo = 0;
    }
    // Update is called once per frame
    void Update()
    {

        Combos();
        if (Mivida.vida <= 100){
            puedeTransformarse = true;

        }
        
        if(Input.GetKey("e") && puedeTransformarse == true && transformado == false)
            {
                anim.SetTrigger("tranformer");
                transformado = true;
                    if (transformado)
                        {
                            anim.SetTrigger("tranformer");
                            anim.SetLayerWeight(0, 0);
                            anim.SetLayerWeight(1, 1);
                            
                        }
                    //anim.SetTrigger("tranformer");
            } 
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(control.position, radioAtaque);
    }
}
