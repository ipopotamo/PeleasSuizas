using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAgeneral : MonoBehaviour
{
    private float rangoVision = 50f;      //En este rango te sigue
    private float rangoATQdista = 50f;    //PARA LOS ATQ DISTANCIA
    private float rangoATQcorta = 50f;    //En este rango te sigue
    private float rangoTP;
    private float rangoATQBasico = 0.5f;

    private GameObject ControlAtaque; //Basico + corto
    private GameObject ControlAtaqueDistancia;
    private GameObject ControlTP;
    private GameObject ControlSuelo;

    private float dano;
    public float vida;
    private float defensa;
    [SerializeField] public float movi; //VeloMove
    private float daniio_H; // Daño de las habilidades del J1

    private int CantTP;

    private bool MirandoDerecha;
    private bool saltando;
    private bool atacando;
    private bool cargando;
    private bool defendiendo;

    private float TiempoEntreRand;
    private int randComportamiento;
    /*
        0: CAMINAR HACIA EL JUGADOR 
        1: ATAQUE DISTANCIA
        2: ATAQUE CORTA DISTANCIA
        3: COMBO 3 GOLPES
        4: CARGO ENERGIA
        5: Salto 
        6: Bloqueo
        7: TP
    */

    private Slider Vidaslider;
    private Animator anim;
    private VidaPJ1 LavidaDelOtro;

    
    [SerializeField] private GameObject ControlEnemigo;

    private Transform   objetivo;
    private Rigidbody2D rb;    
    private Animator    animacion;

    private Vector2 movimiento;
    public  Vector3 Direccion;
    public LayerMask WhatIsPlayer;

    public float checkradius; // Determina cuando empieza a perseguir al jugador    
    public  bool ShouldRotate; //Should Rotate significa "Debe rotar"
    private bool isInChaseRange; // pregunta si esta a rango para perseguir 
    private bool isInAttackRange;
    
    // Start is called before the first frame update
    void Start()
    {
        vida = 200;
        Vidaslider = GameObject.FindGameObjectWithTag("VidaPJ2").GetComponent<Slider>();                //Busca su vida
        Vidaslider.value = vida;
        anim = GetComponent<Animator>();
        LavidaDelOtro = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<VidaPJ1>();       //Busca la vida del otro

        rb = GetComponent<Rigidbody2D>();
        objetivo = GameObject.FindWithTag("Jugador1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vidaslider.value = vida;
        if (vida > 0 && LavidaDelOtro.vida > 0)
            {
                if (defendiendo)
                {
                    //anim.SetTrigger("Defensa");
                }

                if (defendiendo && atacando) 
                {
                    //anim.SetTrigger("0");
                }
            
            }
        if (vida <= 0) 
        {
            //anim.SetTrigger("Muerto");
        }

        //anim.SetBool("caminar", isInChaseRange);
        isInChaseRange  = Physics2D.OverlapCircle(transform.position, checkradius, WhatIsPlayer); // Crea un circulo en representacion al radio de la vista    
        Direccion = objetivo.position - transform.position;
        float amgulo = Mathf.Atan2(Direccion.x,Direccion.y) * Mathf.Rad2Deg; // En el tutorial usan "Atan", NO Atan2, pero con el 1 hay un error

        Direccion.Normalize();
        movimiento = Direccion;
                           
        if (ShouldRotate)
        {
            //anim.SetFloat("X", Direccion.x);
            //anim.SetFloat("Y", Direccion.y);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange) 
        {
            MoveCharacter(movimiento);
        }        
    }

    private void MoveCharacter(Vector2 Direccion)
    {
        rb.MovePosition((Vector2)transform.position + (Direccion * movi * Time.deltaTime));
    }

    public void TomarDaño(float dano)
    {
         if(defendiendo && !atacando)
        {
            dano  = dano - defensa;
            vida -= dano;           
        }
        
        if(!defendiendo && vida>0)
        {
            //anim.SetTrigger("LePegan");
            vida -= dano;
        }

        if (vida <= 0)
        {
            //anim.SetTrigger("Muerto");
            movi = 0;
        }
    }

    public void TomarHabilidadIA(float danio_habilidad){
        daniio_H = danio_habilidad;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("HabilidadPJ1") ){
            vida -= daniio_H;
            //anim.SetTrigger("LePegan");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControlEnemigo.transform.position, checkradius);
    }
}
