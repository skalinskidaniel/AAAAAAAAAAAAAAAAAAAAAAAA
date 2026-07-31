using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuemPassa : MonoBehaviour
{
    public GameObject masiponto;

    [SerializeField] private Transform lugar1;
    [SerializeField] private List<Transform> luares;
    [SerializeField] private List<GameObject> meusAMIGOSAMIGOS;

    void Start()
    {
        string npcIdMaisPontos = EscolherQualVaiProximoEvento.QualNpc;

        if (!string.IsNullOrEmpty(npcIdMaisPontos))
        {
            masiponto = meusAMIGOSAMIGOS.FirstOrDefault(amigo =>
            {
                var falasDepois = amigo.GetComponent<FalasDepois>();
                return falasDepois != null && falasDepois.NpcId == npcIdMaisPontos;
            });

            if (masiponto == null)
            {
                masiponto = meusAMIGOSAMIGOS.FirstOrDefault(amigo => amigo.name == npcIdMaisPontos);
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