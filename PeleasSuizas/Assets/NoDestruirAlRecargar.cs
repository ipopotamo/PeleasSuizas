using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruirAlRecargar : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
