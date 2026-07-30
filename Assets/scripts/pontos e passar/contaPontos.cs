using UnityEngine;

public class contaPontos : MonoBehaviour
{
    public GameObject[]pessoas;
    public int[]pontos;
    public static int maior = 0;

    void OnMouseDown()
    {
        for (int i = 0; i< pessoas.Length; i++)
        {
            if(gameObject == pessoas[i])
            {
                pontos[i]++;
                Debug.Log(pessoas[i].name + "="+pontos[i]);
                break;

            }
        }
        for(int i =1; i < pontos.Length;i++)
        {
            if(pontos[i]>pontos[maior])
            {
                maior = i;
            }
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pontos = new int[pessoas.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
