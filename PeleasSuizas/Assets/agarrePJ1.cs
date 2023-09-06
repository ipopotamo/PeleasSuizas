using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrePJ1 : MonoBehaviour
{
    [SerializeField] private float danoAgarre;
    private float radio = 0.5f;
    private bool agarrando = false;
    private Transform pjEnemigo;
    [SerializeField]private Transform posAgarre;
    [SerializeField]private Transform dondeSePosicionaAlSerAgarrado; // posicion en la cual se queda el pj que sufra el agarre.
    [SerializeField]private Movimiento2 pos2;
    


    // Start is called before the first frame update
    void Start()
    {
        pjEnemigo = GameObject.FindGameObjectWithTag("Jugador2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && agarrando == false){ //Greater<<<<<<<>>>>>>>>>>>
            print("agarre");
            agarrando = true; 
        }
        if(agarrando == true){
            //Hacer animacion, soltar despues de terminar, no moverse mientras esto pasa
            pjEnemigo.position = dondeSePosicionaAlSerAgarrado.position;
        }


        
    }
    private void SoltarAgarre(){
        agarrando = false; //
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(posAgarre.position, radio);
    }
}
