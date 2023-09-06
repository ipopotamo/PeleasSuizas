using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertarImagenes : MonoBehaviour
{
    [SerializeField] private Image imagenJugador2;
    private GameMMMMANAGER gamemanager;
    private int index; 

    
    void Start()
    {
        index   = PlayerPrefs.GetInt("JugadorIndex");
        //gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMMMMANAGER>();
        //int indexJugadorImg = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameMMMMANAGER.Instance.Personajes[index].Imagen, transform.position, Quaternion.identity);       
    }
}
