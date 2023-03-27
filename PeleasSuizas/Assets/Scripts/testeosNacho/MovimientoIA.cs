using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoIA : MonoBehaviour
{

   

    [SerializeField] public float movi;

    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] private float tiempoEntreAtaques;
    
    [SerializeField] private GameObject ControlEnemigo;

    [SerializeField] private float dano;

    private Transform objetivo;

    private Rigidbody2D rb;

    private Animator animacion;

    private Vector2 movimiento;
    public  Vector3 Direccion;

    public LayerMask WhatIsPlayer;

    public float checkradius; // Determina cuando empieza a perseguir al jugador
    public float RadioAtaque; // Determina cuando ataca al jugador

    public  bool ShouldRotate; //Should Rotate significa "Debe rotar"
    private bool isInChaseRange; // pregunta si esta a rango para perseguir 
    private bool isInAttackRange; // pregunta si tiene que atacar o no

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        objetivo = GameObject.FindWithTag("Jugador1").transform;
    }

    
    void Update()
    {
        if (tiempoSiguienteAtaque > 0) 
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        animacion.SetBool("Corriendo", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkradius, WhatIsPlayer); // Crea un circulo en representacion al radio de la vista    
        isInAttackRange = Physics2D.OverlapCircle(transform.position, RadioAtaque, WhatIsPlayer);// Crea un circulo en representacion al radio de ataque    

        Direccion = objetivo.position - transform.position;
        float amgulo = Mathf.Atan2(Direccion.x,Direccion.y) * Mathf.Rad2Deg; // En el tutorial usan "Atan", NO Atan2, pero con el 1 hay un error

        Direccion.Normalize();
        movimiento = Direccion;
       
                   
        
        if (ShouldRotate)
        {
            animacion.SetFloat("X", Direccion.x);
            animacion.SetFloat("Y", Direccion.y);
        }

    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange) 
        {
            MoveCharacter(movimiento);
         //   animacion.SetBool("Ataque", isInAttackRange);
        }

    }
    private void MoveCharacter(Vector2 Direccion)
    {
        rb.MovePosition((Vector2)transform.position + (Direccion * movi * Time.deltaTime));
    }


    private void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControlEnemigo.transform.position, RadioAtaque);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Jugador1"))
            {
                colisionador.transform.GetComponent<VidaPJ1>().TomarDaño1(dano);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ControlEnemigo.transform.position, RadioAtaque);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControlEnemigo.transform.position, checkradius);
    }


}
