using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using TMPro;

public class limites : MonoBehaviour
{
    public TextMeshProUGUI CaixaTexto;
    public string Aviso;
    public float Tempo = 0.5f;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (CaixaTexto.text == Aviso)
            {
                StopAllCoroutines();
                CaixaTexto.text = Aviso;
            }
        }
    }

    void AvisoComeca()
    {
        StartCoroutine(EscreveFrase());
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limite"))
        {
            AvisoComeca();

        }
    }
    IEnumerator EscreveFrase()
    {
        CaixaTexto.text = string.Empty;
        foreach (char c in Aviso)
        {
            CaixaTexto.text += c;
            yield return new WaitForSeconds(Tempo);
            CaixaTexto.text = string.Empty;
        }
    }
}
