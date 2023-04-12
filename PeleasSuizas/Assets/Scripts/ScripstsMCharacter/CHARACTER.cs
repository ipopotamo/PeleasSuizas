using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]

public class CHARACTER : ScriptableObject
{
 
    public GameObject persoJugable;
    public Sprite imagen;
    public string nombre;
}
