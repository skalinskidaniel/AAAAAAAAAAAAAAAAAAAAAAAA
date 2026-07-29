using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class falacadaum : MonoBehaviour
{
 [SerializeField] public RawImage canva;
 public GameObject Falas;

    public void abrirDialogo() //aqui é pra fazer o fundo e os teus texto roda
    {
        if (canva != null)
        {
            StartCoroutine(Animacao());
            
        }
        
    }

    void Escurecer()
    {
        canva.CrossFadeAlpha(1, 0.90f, true);
    }
//aqui os nome é meio auto explicativo eles mexe o no ruugners da raw image pra dar la o efeito q c quer
    void Clarear()
    {
        canva.CrossFadeAlpha(0, 0.90f, false);
    }

    IEnumerator Animacao()// aqui é a sequencia dos fatos primeiro clareia a raw dps ela aparece por algum motivo se tirar o escurecer para de funcionana Deus ou carlao ou alguma outra entidade tipo o felipe ou bersa quer assim n vamo contra eles n
    {
       
        Clarear();
        canva.gameObject.SetActive(true); // Usa .gameObject.SetActive
        yield return new WaitForSeconds(0.90f); // Adicionado o yield obrigatório
        Falas.SetActive(true);
        Escurecer();
        
        
    }
}
