using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Animator PlayerAnimator;
    private Rigidbody2D RB2D;

    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float SuavisadoMovimiento;
    private Vector2 movi;
    private Vector3 velocidad = Vector3.zero;
    private bool MirandoDerecha = true;
    
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        movi = new Vector2(movimientoHorizontal, 0).normalized;
        //PlayerAnimator.SetFloat("Horizontal", movimientoHorizontal);
        PlayerAnimator.SetFloat("velocidad", movi.magnitude);
    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal*Time.fixedDeltaTime);
    }
    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, RB2D.velocity.y);
        RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, velocidadObjetivo, ref velocidad, SuavisadoMovimiento);

        if (mover > 0 && !MirandoDerecha) {
            Girar();
        }
        else if (mover<0 && MirandoDerecha) {
            Girar();
        }
    }

    private void Girar() {
        MirandoDerecha = !MirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
