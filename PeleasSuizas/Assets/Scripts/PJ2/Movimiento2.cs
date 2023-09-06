using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    private Animator PlayerAnimator;
    private Rigidbody2D RB2D;
    
    private float MovX = 0;

    private VidaPJ1 LavidaDelOtro;
    public VidaPJ2 vidaUwU;
    
    [SerializeField] public float Fsalto; 
    [SerializeField] public LayerMask EnSuelo;
    [SerializeField] private Transform controladorS; 
    [SerializeField] private Vector3 dimensioncaja;
    [SerializeField] private bool eSuelo; 
    public bool ENSUELO {get => eSuelo; set => eSuelo = value; }
    private bool salto = false;
    
    [SerializeField] public float velocidadDeMovimiento = 400;
    [SerializeField] private float SuavisadoMovimiento;
    private Vector2 movi;
    private Vector3 velocidad = Vector3.zero;
    private bool MirandoDerecha = true;
    public bool MIRANDODERECHA {get => MirandoDerecha; set => MirandoDerecha = value; }
    public bool PuedeMoverse = true;

    void Start()
    {
        MirandoDerecha = true;
        vidaUwU = GetComponent<VidaPJ2>();
        RB2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       LavidaDelOtro = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();
        if(vidaUwU.vida > 0 && LavidaDelOtro.vida > 0 && PuedeMoverse == true){
          if(Input.GetKey("left"))
          {
            MovX = -1*velocidadDeMovimiento;            
          }
          if(!Input.GetKey("left"))
          {
            MovX = 0*velocidadDeMovimiento; 
          }
          if(Input.GetKey("right"))
          {
            MovX = 1*velocidadDeMovimiento;           
          }
          
          if(Input.GetKeyDown(KeyCode.UpArrow) && eSuelo && vidaUwU.vida > 0)
          {
            PlayerAnimator.SetTrigger("saltando");  
            salto = true;        
          }
          
        }

        movi = new Vector2(MovX * Time.deltaTime * velocidadDeMovimiento , 0f).normalized;
        
        PlayerAnimator.SetFloat("velocidad", movi.magnitude);
    }

    private void FixedUpdate()
    {
       eSuelo = Physics2D.OverlapBox(controladorS.position,dimensioncaja,0f,EnSuelo);
       Mover(MovX * Time.fixedDeltaTime, salto);
       salto = false;
          
    }

    public void Mover(float m, bool saltar)
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

    private void NoMoverse(){
      PuedeMoverse = false;
    }

    public void VolverAMoverse(){
      PuedeMoverse = true;
    }

    public void VolverIdle(){
        PlayerAnimator.SetBool("SuperAtaque", false);
        PlayerAnimator.SetBool("SuperAtaque2", false);
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
    private void Salto()
    {            
        salto = false;
        RB2D.AddForce(new Vector2(0f, Fsalto));      
    }
}
