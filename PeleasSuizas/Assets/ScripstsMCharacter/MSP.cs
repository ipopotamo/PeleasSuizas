using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MSP : MonoBehaviour
{
    public static int index;
    public static int index2;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI name1;
    [SerializeField] private Image img2;
    [SerializeField] private TextMeshProUGUI name2;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instancia;
        index = PlayerPrefs.GetInt("JuadorIndex");
        index2 = PlayerPrefs.GetInt("JuadorIndex2");

        if(index > gameManager.person.Count -1)
        {
            index = 0;
        }



        CambiarPantalla();
        CambiarPantalla2();
    }


    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        img.sprite = gameManager.person[index].imagen;
        name1.text = gameManager.person[index].nombre;
    }

    private void CambiarPantalla2()
    {
        PlayerPrefs.SetInt("JugadorIndex2", index2);
        img2.sprite = gameManager.personajes[index2].imagen;
        name2.text = gameManager.personajes[index2].nombre;
        
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
    public void SiguientePersonaje2()
    {
        if(index2 == gameManager.personajes.Count -1 )
        {
            index2 = 0;
        }
        else{
            index2 +=1;
        }

        CambiarPantalla2();
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
    public void AnteriorPERSONAJE2()
    {
        if(index2 == 0 )
        {
            index2 = gameManager.personajes.Count -1;
        }
        else{
            index2 +=1;
        }

        CambiarPantalla2();
    
    }


    public void StarGame()
    {
        SceneManager.LoadScene("PELEAEJEMPLO");
    }
}
