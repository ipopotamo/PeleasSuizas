using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPJ1 : MonoBehaviour
{
    private Transform TPaca;
    // Start is called before the first frame update
    void Start()
    {
        TPaca = GameObject.FindGameObjectWithTag("TPPJ2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TPalPJ2();   
    }
    public void TPalPJ2(){
        if(Input.GetKey("q")){
            this.transform.position = TPaca.transform.position;
        }
    }
}
