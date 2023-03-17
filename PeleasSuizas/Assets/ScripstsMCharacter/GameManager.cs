using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public List<CHARACTER> person;

    
    public List<CHARACTER> personajes;

    private void Awake()
    {
        if(GameManager.Instancia == null)
        {
            GameManager.Instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
