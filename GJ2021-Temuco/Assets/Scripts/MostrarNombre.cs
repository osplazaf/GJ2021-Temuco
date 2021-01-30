using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarNombre : MonoBehaviour
{
    public Text nombreJugador;


    public void Start()
    {
        Debug.Log("mostrando nombre en scene2: " + PlayerPrefs.GetString("nombreJugador"));
        nombreJugador.text = PlayerPrefs.GetString("nombreJugador");
    }
}
