using UnityEngine;

public class doCArlao : MonoBehaviour
{
    public GameObject[] pessoas;
    public int pessoaClicada;
    public Transform[] posicoes;
    public static int PessoaLugarFixo;

    private void Awake()
    {
        PessoaLugarFixo = pessoaClicada;
        pessoaClicada = contaPontos.maior;
        Debug.Log("quem devia ta aqui : " + pessoaClicada);
    }

    void Start()
    {
        Debug.Log("começou");

        pessoas[pessoaClicada].transform.SetPositionAndRotation(posicoes[0].position,posicoes[0].rotation);

        int p = 1;

        for (int i = 0; i < pessoas.Length; i++)
        {
            if (i != pessoaClicada)
            {
                pessoas[i].transform.SetPositionAndRotation(posicoes[p].position,posicoes[p].rotation);
                p++;
            }
        }
    }

    void Update()
    {

    }
}