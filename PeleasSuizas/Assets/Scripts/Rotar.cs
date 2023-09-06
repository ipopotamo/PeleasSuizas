using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    [SerializeField]private float VeloRotacion;

    void Update()
    {
        this.transform.Rotate(Vector3.forward * VeloRotacion * Time.deltaTime);
    }
}
