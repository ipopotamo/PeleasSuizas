using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPJ1 : MonoBehaviour
{
    [SerializeField] private Transform areaTP;
    private float radioTP = 4f;
    [SerializeField] private float maxTP = 4f;
    private float cantTP;
    private float regeneracionTP = 20f;
    [SerializeField] private float tiempoRTP;

    private float tiempoEntreTP = 3;
    private float tiempoSiguienteTP;
    private Transform TPaca;

    private Text textoCant;
    private string texto;
    // Start is called before the first frame update
    void Start()
    {
        cantTP = maxTP;
        TPaca = GameObject.FindGameObjectWithTag("TPPJ2").GetComponent<Transform>();
        textoCant = GameObject.FindGameObjectWithTag("TextTP1").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texto = cantTP.ToString("F0");
        
        textoCant.text = texto; 
        if (tiempoSiguienteTP>0)
        {
            tiempoSiguienteTP -= Time.deltaTime;
        }
        if(cantTP < maxTP){
            tiempoRTP -= Time.deltaTime;
        }
        if(tiempoRTP < 0){
            cantTP ++;
            tiempoRTP = regeneracionTP;
        }

        TPalPJ2();

    }
    
    public void TPalPJ2(){
        if (Input.GetKey("q")){
            Collider2D[] objetos = Physics2D.OverlapCircleAll(areaTP.position, radioTP);

            foreach (Collider2D colisionador in objetos) {
                if (colisionador.CompareTag("Habilidad")) 
                {
                    if(cantTP > 0 && tiempoSiguienteTP <= 0 ){
                        tiempoSiguienteTP = tiempoEntreTP;
                        this.transform.position = TPaca.transform.position;
                        cantTP = cantTP - 1;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(areaTP.position, radioTP);
    }
}
