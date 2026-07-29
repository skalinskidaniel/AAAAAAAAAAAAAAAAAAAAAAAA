using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quemPassaProevento : MonoBehaviour
{
    public GameObject masiponto;
    [SerializeField] private Transform lugar1;

    [SerializeField] private Transform lugar2;
    [SerializeField] private Transform lugar3;
    [SerializeField] private Transform lugar4;
   
    [SerializeField] public List<Transform> luares;
    [SerializeField] private List<GameObject> meusAMIGOSAMIGOS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spaw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spaw()
    {
        //Instantiate(masiponto, lugar1.position, lugar1.rotation); //sapwna os certo no lugar certo

        List<Transform> luaresR = new List<Transform>(luares);
        List<GameObject> amigosR = new List<GameObject>(meusAMIGOSAMIGOS); // Corrigido Lis<gameObject> -> List<GameObject>

        int spawmanager = Mathf.Min(3, Mathf.Min(amigosR.Count, luaresR.Count)); // Corrigido Acount -> Count e Mathf.Min duplo

        for (int i = 0; i < spawmanager; i++) // Corrigido adicionando 'i' no meio do for
        {
            int blindexAmigos = Random.Range(0, amigosR.Count); // Corrigido range -> Range e Acount -> Count
            int blindexLugar = Random.Range(0, luaresR.Count);  // Corrigido range -> Range e Acount -> Count

            Instantiate(amigosR[blindexAmigos], luaresR[blindexLugar].position, luaresR[blindexLugar].rotation);

            amigosR.RemoveAt(blindexAmigos);
            luaresR.RemoveAt(blindexLugar); //aqui é so pra tirar da lista quem der spaw pr n ter tipo 4 japa imagine q undo horrivel cheio de japa Deus é mais 
        }
    }
}