using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMMMMANAGER : MonoBehaviour
{
    public static GameMMMMANAGER Instance;
    public List<Personaje> Personajes;

    public List<Personaje> PersonajesJugador2;  

    private void Awake() {
        if (GameMMMMANAGER.Instance == null){
            GameMMMMANAGER.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
