using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MSPO2 : MonoBehaviour
{
    private int index;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private Image img2;
    [SerializeField] private TextMeshProUGUI name2;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instancia;
        index = PlayerPrefs.GetInt("JuadorIndex");

        if(index > gameManager.person.Count -1)
        {
            index = 0;
        }


        CambiarPantalla();
    }


    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        img2.sprite = gameManager.person[index].imagen;
        name2.text = gameManager.person[index].nombre;
        img.sprite = gameManager.person[index].imagen;
        name.text = gameManager.person[index].nombre;
    }

    public void SiguientePersonaje()
    {
        if(index == gameManager.person.Count -1 )
        {
            index = 0;
        }
        else{
            index +=1;
        }

        CambiarPantalla();
    }

    public void AnteriorPERSONAJE()
    {
        if(index == 0 )
        {
            index = gameManager.person.Count -1;
        }
        else{
            index +=1;
        }

        CambiarPantalla();
    
    }

    private void StarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}