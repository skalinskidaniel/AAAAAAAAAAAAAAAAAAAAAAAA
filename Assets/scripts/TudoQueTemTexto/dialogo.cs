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
        audiosouce = GetComponent<AudioSource>();
        if (FalasDepoisScript == null)
        {
            FalasDepoisScript = GetComponent<FalasDepois>();
        }

        if (FalasDepoisScript == null)
        {
            Debug.LogWarning($"FalasDepois não encontrado em {name}. Adicione o componente ou atribua pelo inspetor.");
        }

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
            if (FalasDepoisScript != null)
            {
                FalasDepoisScript.MarcarConversa();
            }
            SceneManager.LoadScene(NomeDoProximoEvento);
            Debug.Log("ta indificado ");
        }
    }

    IEnumerator Digitar()
    {
        foreach (char c in Frases[FraseAtual])//.ToCharArray())
        {
            CaixaTexto.text += c;
            audiosouce.PlayOneShot(somdafala);
            yield return new WaitForSeconds(TempoEntreFrases);
           
        }
    }
}
