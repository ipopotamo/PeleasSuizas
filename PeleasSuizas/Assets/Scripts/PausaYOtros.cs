using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PausaYOtros : MonoBehaviour
{
    [SerializeField] public GameObject cartelPausa;
    [SerializeField] private GameObject Config;
    public bool juegopausado = false;
    [SerializeField] private CRonrdas rondas;
    void Start()
    {
        
        /*rondas = GetComponent<CRonrdas>();*/
        rondas = GameObject.FindGameObjectWithTag("ControlRondas").GetComponent<CRonrdas>();
        juegopausado = false;
        GameObject[] ELcartelPausa = FindObjectsOfType<GameObject>(true);
        foreach (GameObject g in ELcartelPausa)
        {
            if(g.tag == "cartelPausa"){
                cartelPausa = g;
            }
        }
        
        cartelPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rondas = GameObject.FindGameObjectWithTag("ControlRondas").GetComponent<CRonrdas>();
        GameObject[] ELcartelPausa = FindObjectsOfType<GameObject>(true);
        foreach (GameObject g in ELcartelPausa)
        {
            if(g.tag == "cartelPausa"){
                cartelPausa = g;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegopausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        cartelPausa.SetActive(false);
        Config.SetActive(false);
    }
    private void Pausa(){
        cartelPausa.SetActive(true);
        juegopausado = true;
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        rondas.WINSPJ1 = 0;
        rondas.WINSPJ2 = 0;
        juegopausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cartelPausa.SetActive(false);
        Config.SetActive(false);
    }

    public void Salir_al_Menu()
    {
        rondas.WINSPJ1 = 0;
        rondas.WINSPJ2 = 0;
        SceneManager.LoadScene("Seletor");
        cartelPausa.SetActive(false);
        Config.SetActive(false);
        Time.timeScale = 1f;
        Destroy(rondas.gameObject);
    }

    public void MostrarConfig(){
        cartelPausa.SetActive(false);
        Config.SetActive(true);
    }
    public void VolverMenuOpcionesEnJuego(){
        cartelPausa.SetActive(true);
        Config.SetActive(false);    
    }
}