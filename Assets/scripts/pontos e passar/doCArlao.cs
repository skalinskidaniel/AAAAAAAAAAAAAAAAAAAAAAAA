using UnityEngine;

public class doCArlao : MonoBehaviour
{
    public GameObject[] pessoas;
    public int pessoaClicada;
    public Transform[] posicoes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        pessoaClicada = contaPontos.maior;
        Debug.Log("quem devia ta aqui : " + pessoaClicada);

    }
    void Start()
    {
        Debug.Log("começou");

        pessoas[pessoaClicada].transform.position = posicoes[0].position;

        int p = 1;

        for (int i = 0; i < pessoas.Length; i++)
        {
            if (i != pessoaClicada)
            {
                pessoas[i].transform.position = posicoes[p].position;
                p++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
