using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionDePersonas : MonoBehaviour
{
    private int index; 
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    private int indexJ2;
    [SerializeField] private Image imagenJugador2;
    [SerializeField] private TextMeshProUGUI nombreJugador2;
    private GameMMMMANAGER gamemanager;

    private void Start() {
        gamemanager = GameMMMMANAGER.Instance;

        CambiarPantalla2();
        CambiarPantalla();
    }
    private void Update() {
        index   = PlayerPrefs.GetInt("JugadorIndex");
        indexJ2 = PlayerPrefs.GetInt("JugadorIndex2");


        if(Input.GetKey("a")){
            AnteriorPersonaje();
        }

        if(Input.GetKey("d")){
            SiguientePersonaje();
        }
    }

    private void CambiarPantalla(){
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gamemanager.Personajes[index].Imagen;
        nombre.text = gamemanager.Personajes[index].nombre;
    }

    public void SiguientePersonaje(){
        if(index == gamemanager.Personajes.Count - 1){
            index = 0;
        }
        else{
            index += 1;
        }
        CambiarPantalla();
    }

    public void AnteriorPersonaje(){
        if(index == 0){
            index = gamemanager.Personajes.Count - 1;
        }
        else{
            index -= 1;
        }
        CambiarPantalla();
    }
    
    public void IniciarJuego(){
        SceneManager.LoadScene("EjemploPelea");
    }

    //---------------------------------------------cODIGOpj2---------------------------------------------------

    private void CambiarPantalla2(){
        PlayerPrefs.SetInt("JugadorIndex2", indexJ2);
        imagenJugador2.sprite = gamemanager.PersonajesJugador2[indexJ2].Imagen;
        nombreJugador2.text = gamemanager.PersonajesJugador2[indexJ2].nombre;
    }

    public void SiguientePersonajeJugador2(){
        if(indexJ2 == gamemanager.PersonajesJugador2.Count - 1){
            indexJ2 = 0;
        }
        else{
            indexJ2 += 1;
        }
        CambiarPantalla2();
    }

    public void AnteriorPersonajeJugador2(){
        if(indexJ2 == 0){
            indexJ2 = gamemanager.PersonajesJugador2.Count - 1;
        }
        else{
            indexJ2 -= 1;
        }
        CambiarPantalla2();
    }
}
