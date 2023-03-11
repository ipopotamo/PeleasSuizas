using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Animator PlayerAnimator;
    private Rigidbody2D RB2D;

    private float MovX;

    public VidaPJ1 vidaUwU;
    
    [SerializeField] public float velocidadDeMovimiento;
    [SerializeField] private float SuavisadoMovimiento;
    private Vector2 movi;
    private Vector3 velocidad = Vector3.zero;
    private bool MirandoDerecha = true;

    
    [SerializeField] public float Fsalto; 
    [SerializeField] private LayerMask EnSuelo;
    [SerializeField] private Transform controladorS; 
    [SerializeField] private Vector3 dimensioncaja;
    [SerializeField] private bool eSuelo; 
    private bool salto = false;


    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        vidaUwU = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(vidaUwU.vida > 0){
         if(Input.GetKey("a"))
        {
            MovX = -1 * velocidadDeMovimiento;            
        }
        if(!Input.GetKey("a"))
        {
            MovX = 0 * velocidadDeMovimiento; 
        }
        if(Input.GetKey("d"))
        {
            MovX = 1 * velocidadDeMovimiento;           
        }

        if(Input.GetKeyDown(KeyCode.W) && eSuelo)
        {
                PlayerAnimator.SetTrigger("saltando"); 
                salto = true;        
        }

        }
       
        movi = new Vector2(MovX * Time.deltaTime * velocidadDeMovimiento ,0f).normalized;
        
        PlayerAnimator.SetFloat("velocidad", movi.magnitude);
    }

    private void FixedUpdate()
    {
       eSuelo = Physics2D.OverlapBox(controladorS.position,dimensioncaja,0f,EnSuelo);
        //PlayerAnimator.SetBool("saltando", salto);
        Mover(MovX * Time.fixedDeltaTime, salto);
       salto = false;
          
    }

    private void Mover(float m, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(m, RB2D.velocity.y);
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, velocidadObjetivo, ref velocidad ,SuavisadoMovimiento);
        
        if (m > 0 && !MirandoDerecha) {
            Girar();
        }
        else if (m < 0 && MirandoDerecha) {
            Girar();
        }
        if(eSuelo && saltar)
        {
            eSuelo = false;
            RB2D.AddForce(new Vector2(0f,Fsalto));
        }
    }

    private void Salto()
    {    
        salto = false;
        RB2D.AddForce(new Vector2(0f, Fsalto));      
    }


    private void Girar() {
        MirandoDerecha = !MirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(controladorS.position,dimensioncaja);
    }
}
