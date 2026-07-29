using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quemPassaProevento : MonoBehaviour
{
    public GameObject masiponto;

    [SerializeField] private Transform lugar1;
    [SerializeField] private List<Transform> luares;
    [SerializeField] private List<GameObject> meusAMIGOSAMIGOS;

    void Start()
    {
        // Procura o prefab que ganhou mais pontos
        foreach (GameObject amigo in meusAMIGOSAMIGOS)
        {
            if (amigo.name == EscolherQualVaiProximoEvento.npcPontos)
            {
                masiponto = amigo;
                break;
            }
        }

        Spaw();
    }

    public void Spaw()
    {
        List<Transform> luaresR = new List<Transform>(luares);
        List<GameObject> amigosR = new List<GameObject>(meusAMIGOSAMIGOS);

        // Spawn do NPC com mais pontos
        if (masiponto != null)
        {
            Instantiate(masiponto, lugar1.position, lugar1.rotation);

            amigosR.Remove(masiponto);
            luaresR.Remove(lugar1);
        }

        int spawmanager = Mathf.Min(amigosR.Count, luaresR.Count);

        for (int i = 0; i < spawmanager; i++)
        {
            int indiceAmigo = Random.Range(0, amigosR.Count);
            int indiceLugar = Random.Range(0, luaresR.Count);

            Instantiate(amigosR[indiceAmigo],luaresR[indiceLugar].position,luaresR[indiceLugar].rotation);

            amigosR.RemoveAt(indiceAmigo);
            luaresR.RemoveAt(indiceLugar);
        }
    }
}