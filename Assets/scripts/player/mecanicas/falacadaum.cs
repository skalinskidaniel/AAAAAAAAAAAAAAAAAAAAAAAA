using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class falacadaum : MonoBehaviour
{
    [SerializeField] public RawImage canva;
    public GameObject fala;
    public float espera;

    Coroutine animacaoAtual;

    public void abrirDialogo()
    {
        if (canva != null)
        {
            if (animacaoAtual != null)
                StopCoroutine(animacaoAtual);

            animacaoAtual = StartCoroutine(Animacao());
        }
    }

   public void fecharDialogo()
    {
        if (animacaoAtual != null)
        {
           StopCoroutine(animacaoAtual);
         animacaoAtual = null;
        }

        canva.gameObject.SetActive(false);
        fala.SetActive(false);
    }

    void Escurecer()
    {
        canva.CrossFadeAlpha(1, 0.90f, true);
    }

    void Clarear()
    {
        canva.CrossFadeAlpha(0, 0.90f, false);
    }

    IEnumerator Animacao()
    {
        Clarear();

        canva.gameObject.SetActive(true);
        fala.SetActive(true);

        Escurecer();

        yield return new WaitForSeconds(espera);

        
    }
}