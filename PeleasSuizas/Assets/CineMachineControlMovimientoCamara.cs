using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineControlMovimientoCamara : MonoBehaviour
{
    public static CineMachineControlMovimientoCamara Instance;
    
    private CinemachineVirtualCamera CinemahineCamera;
    private CinemachineBasicMultiChannelPerlin Perlin;

    private float tiempoMov;
    private float tiempoMovTotal;
    private float intensidadInicial;

    private void Awake() {
        Instance = this;
        CinemahineCamera = GetComponent<CinemachineVirtualCamera>();
        Perlin = CinemahineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    
    public void MoverCamera(float intencidad, float frecuencia, float tiempo){
        Perlin.m_AmplitudeGain = intencidad;
        Perlin.m_FrequencyGain = frecuencia;
        tiempoMovTotal = tiempo;
        tiempoMov = tiempo;
        intensidadInicial = intencidad;
    }



    // Update is called once per frame
    void Update()
    {
        if (tiempoMov > 0){
            tiempoMov -= Time.deltaTime;
            Perlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMov/ tiempoMovTotal));
        }
    }
}
