using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public RectTransform dialogo;
    float posFinal;
    bool abrirDialogo = true;
    public float tiempo = 0.5f;

    private void Start()
    {
        posFinal = Screen.width / 2;
        dialogo.position = new Vector3(-posFinal, dialogo.position.y, 0);
    }

    IEnumerator Mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;
        while ( elapsedTime < time)
        {
            dialogo.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        dialogo.position = posFin;
    }

    void MoverDialogo( float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin) );
    }

    public void BUTTON_Sub_Menu()
    {
        int signo = 1;
        if (!abrirDialogo)
            signo = -1;

        MoverDialogo(tiempo, dialogo.position, new Vector3 ( signo * posFinal, dialogo.position.y, 0));
        abrirDialogo = !abrirDialogo;
    }

}
