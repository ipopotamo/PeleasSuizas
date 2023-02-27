using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
     private Animator PlayerAnimator;
    private Rigidbody2D RB2D;

    private float MovX = 0;
    private float MOvY = 0;
    
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float SuavisadoMovimiento;
    private Vector2 movi;
    private Vector3 velocidad = Vector3.zero;
    private bool MirandoDerecha = true;

    private bool salto = true;
    [SerializeField] private float Tiempoenelaire; 
    [SerializeField] private float Sigsalto;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(Input.GetKey("a"))
        {
            MovX = -1*velocidadDeMovimiento;            
        }
        if(!Input.GetKey("a"))
        {
            MovX = 0*velocidadDeMovimiento; 
        }
        if(Input.GetKey("d"))
        {
            MovX = 1*velocidadDeMovimiento;           
        }

        if(salto == true && Sigsalto > 0 && Input.GetKey("space")){
            
            Salto();

            if(salto == false && Tiempoenelaire < 0){
            MOvY = -1;
            }
        }
        

        movi = new Vector2(MovX * Time.deltaTime * velocidadDeMovimiento , MOvY * Time.deltaTime * velocidadDeMovimiento).normalized;
        
        PlayerAnimator.SetFloat("velocidad", movi.magnitude);
    }

    private void FixedUpdate()
    {
       Mover(MovX * Time.fixedDeltaTime);
       
    }

    private void Mover(float m)
    {
        Vector3 velocidadObjetivo = new Vector2(MovX * Time.deltaTime * velocidadDeMovimiento , MOvY * Time.deltaTime * velocidadDeMovimiento).normalized;
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, velocidadObjetivo, ref velocidad,0);
        
        if (m > 0 && !MirandoDerecha) {
            Girar();
        }
        else if (m < 0 && MirandoDerecha) {
            Girar();
        }
    }

    private void Salto()
    {
        Sigsalto -= Time.deltaTime; 
        salto = false;
        MOvY  = 1;
        Sigsalto = Tiempoenelaire; 
      
    }


    private void Girar() {
        MirandoDerecha = !MirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
