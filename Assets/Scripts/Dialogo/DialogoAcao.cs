using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoAcao : MonoBehaviour
{
    public Dialogo dialogueacao;
    public UI_EscolhaProps escolhaPropsCombo;

    void Awake()
    {
        dialogueacao = escolhaPropsCombo.dialogosetado;
    }

    void Start()
    {
        dialogueacao = escolhaPropsCombo.dialogosetado;
    }

    public void trigar()
    {


        if (dialogueacao == null) return;

        FindObjectOfType<DialogueManager>().ComecarDialogo(dialogueacao);
    }


}

