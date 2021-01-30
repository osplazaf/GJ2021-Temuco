using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> oraciones;

    // Start is called before the first frame update
    void Start()
    {
        oraciones = new Queue<string>();
    }

    public void IniciarDialogo (Dialogo dialogo)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogo.nombre;

        oraciones.Clear();

        foreach ( string oracion in dialogo.dialogos)
        {
            oraciones.Enqueue(oracion);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Si se terminan las oraciones, se termina el dialogo
        if ( oraciones.Count == 0)
        {
            EndDialogue();
            return;
        }

        string oracion = oraciones.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(oracion));
    }

    IEnumerator TypeSentence ( string oracion)
    {
        dialogueText.text = "";
        foreach (char letra in oracion.ToCharArray())
        {
            dialogueText.text += letra;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

    }

}
