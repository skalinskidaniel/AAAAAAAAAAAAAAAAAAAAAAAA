using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using TMPro;

public class escolhas : MonoBehaviour
{
    public TextMeshProUGUI CaixaTexto;
    public TextMeshProUGUI TextoDasEscolhas;
    public string[] Frases;
    public string[] Qual;
    public float TempoEntreFrases = 0.5f;
    public GameObject opcoes;
    public GameObject personagem;

    private int FraseAtual;
    private int QualAtual;
    private bool usandoQual;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (usandoQual)
            {
                if (CaixaTexto.text == Qual[QualAtual])
                {
                    ProximaFrase();
                }
                else
                {
                    StopAllCoroutines();
                    CaixaTexto.text = Qual[QualAtual];
                }
            }
            else
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
    }

    void Start()
    {
        CaixaTexto.text = string.Empty;
        usandoQual = false;
        ComecaDialogo();
        opcoes.SetActive(false);
    }

    void ComecaDialogo()
    {
        FraseAtual = 0;
        StartCoroutine(Digitar());
    }

    void ProximaFrase()
    {
        if (usandoQual)
        {
            if (QualAtual < Qual.Length - 1)
            {
                QualAtual++;
                CaixaTexto.text = string.Empty;
                StartCoroutine(Digitar());
            }
            else
            {
                personagem.SetActive(true);
            }
        }
        else
        {
            if (FraseAtual < Frases.Length - 1)
            {
                FraseAtual++;
                CaixaTexto.text = string.Empty;
                StartCoroutine(Digitar());
            }
            else
            {
                opcoes.SetActive(true);
            }
        }
    }

    public void Sim()
    {
        opcoes.SetActive(false);
        StopAllCoroutines();
        usandoQual = true;
        QualAtual = 0;
        CaixaTexto.text = string.Empty;
        StartCoroutine(Digitar());
    }

    public void Nao()
    {
        
    }

    IEnumerator Digitar()
    {
        string[] arrayAtual = usandoQual ? Qual : Frases;
        int indiceAtual = usandoQual ? QualAtual : FraseAtual;

        foreach (char c in arrayAtual[indiceAtual].ToCharArray())
        {
            CaixaTexto.text += c;
            yield return new WaitForSeconds(TempoEntreFrases);
        }
    }
}
