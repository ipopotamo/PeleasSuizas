using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoManager : MonoBehaviour
{
    public static SonidoManager Instance;
    public static float volumenMusica = 0.2f;

    private void Awake() {
        if (SonidoManager.Instance == null){
            SonidoManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
