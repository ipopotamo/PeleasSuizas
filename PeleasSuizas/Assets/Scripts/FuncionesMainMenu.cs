using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionesMainMenu : MonoBehaviour
{
    public void IrAlSelector(){
        SceneManager.LoadScene(4);
    }

    public void Salir(){
        Application.Quit();
    }

    public void IrPractica(){
        SceneManager.LoadScene(6);
    }

    public void VolverAlMenu(){
        SceneManager.LoadScene(5);
    }
}
