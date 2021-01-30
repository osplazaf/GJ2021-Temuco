using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeerNombre : MonoBehaviour
{
    private string inputNombre;

    public void LeerString( string s )
    {
        inputNombre = s;
        Debug.Log(inputNombre);
        PlayerPrefs.SetString("nombreJugador", inputNombre);
    }

}
