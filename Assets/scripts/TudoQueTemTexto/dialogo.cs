using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using TMPro;

public class dialogo : MonoBehaviour
{
    public TextMeshProUGUI CaixaTexto;
    public string[] Frases;
    public float TempoEntreFrases = 0.5f;
    public string NomeDoProximoEvento;

    private AudioSource audiosouce;
    [SerializeField] public AudioClip somdafala;

    [Tooltip("Referência ao componente FalasDepois deste NPC.")]
    public FalasDepois FalasDepoisScript;

    private int FraseAtual;
    private Coroutine coroutineDigitar;
    private bool dialogoIniciado;
    private bool digitando;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!dialogoIniciado)
            {
                ComecaDialogo();
                dialogoIniciado = true;
            }
            else if (digitando)
            {
                CompletarTextoAtual();
            }
            else
            {
                ProximaFrase();
            }
        }
    }

    void OnMouseDown()
    {
        if (!dialogoIniciado)
        {
            ComecaDialogo();
            dialogoIniciado = true;
        }
        else if (digitando)
        {
            CompletarTextoAtual();
        }
        else
        {
            ProximaFrase();
        }
    }

    void Start()
    {
        audiosouce = GetComponent<AudioSource>();
        if (FalasDepoisScript == null)
        {
            FalasDepoisScript = GetComponent<FalasDepois>();
        }

        if (FalasDepoisScript == null)
        {
            Debug.LogWarning($"FalasDepois não encontrado em {name}. Adicione o componente ou atribua pelo inspetor.");
        }  
    }

    void ComecaDialogo()
    {
        if (Frases == null || Frases.Length == 0)
        {
            return;
        }

        if (coroutineDigitar != null)
        {
            StopCoroutine(coroutineDigitar);
        }

        FraseAtual = 0;
        CaixaTexto.text = string.Empty;
        digitando = true;
        coroutineDigitar = StartCoroutine(Digitar());
    }

    void CompletarTextoAtual()
    {
        if (coroutineDigitar != null)
        {
            StopCoroutine(coroutineDigitar);
            coroutineDigitar = null;
        }

        CaixaTexto.text = Frases[FraseAtual];
        digitando = false;
    }

    void ProximaFrase()
    {
        if (coroutineDigitar != null)
        {
            StopCoroutine(coroutineDigitar);
            coroutineDigitar = null;
        }

        if (FraseAtual < Frases.Length - 1)
        {
            FraseAtual++;
            CaixaTexto.text = string.Empty;
            digitando = true;
            coroutineDigitar = StartCoroutine(Digitar());
        }
        else
        {
            if (FalasDepoisScript != null)
            {
                FalasDepoisScript.MarcarConversa();
            }
            SceneManager.LoadScene(NomeDoProximoEvento);
        }
    }

    IEnumerator Digitar()
    {
        foreach (char c in Frases[FraseAtual])
        {
            CaixaTexto.text += c;
            if (audiosouce != null && somdafala != null)
            {
                audiosouce.PlayOneShot(somdafala);
            }
            yield return new WaitForSeconds(TempoEntreFrases);
        }

        digitando = false;
        coroutineDigitar = null;
    }
}
