using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbarch : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
      slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima; 
    }

    public void CambiarVidaActual(float cantVida)
    {
        slider.value = cantVida;
    }

    public void InicializarBarraDeVida(float cantVida)
    {
       CambiarVidaMaxima(cantVida);
        CambiarVidaActual(cantVida);
    }
}
