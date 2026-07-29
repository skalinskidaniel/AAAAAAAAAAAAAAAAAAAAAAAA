using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using TMPro;

public class dialogos : MonoBehaviour
{
    public TextMeshProUGUI CaixaTexto;
    public string[] Frases;
    public float TempoEntreFrases = 0.5f;

    private int FraseAtual;
    private int ano;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (CaixaTexto.text == Frases[FraseAtual])
            {
                ProximaFrase();
            }
            else
            {
                StopAllCoroutines();
                CaixaTexto.text = Frases[FraseAtual];
            }
        }
    }

    void Start()
    {
        CaixaTexto.text = string.Empty;
        ComecaDialogo();
    }

    void ComecaDialogo()
    {
        FraseAtual = 0;
        StartCoroutine(Digitar());

    }

    void ProximaFrase()
    {
        if (FraseAtual < Frases.Length - 1)
        {
            FraseAtual++;
            CaixaTexto.text = string.Empty;
            StartCoroutine(Digitar());
        }
        else
        {
            ano++;
            SceneManager.LoadScene("SampleScene");

        }
    }

    IEnumerator Digitar()
    {
        foreach (char c in Frases[FraseAtual].ToCharArray())
        {
            CaixaTexto.text += c;
            yield return new WaitForSeconds(TempoEntreFrases);
        }
    }
}
