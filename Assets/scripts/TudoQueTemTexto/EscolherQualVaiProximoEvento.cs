using System.Linq;
using UnityEngine;

public class EscolherQualVaiProximoEvento : MonoBehaviour
{
    public static string npcPontos;
    void Start()
    {
        // Informações de debug para diagnosticar porque a lista pode vir vazia
        Debug.Log($"FalasDepois instancias em cena: {FalasDepois.Instancias.Count}");
        Debug.Log($"Npcs registrados (static set): {FalasDepois.NpcsRegistrados.Count}");

        foreach (var id in FalasDepois.NpcsRegistrados)
        {
            int pontos = FalasDepois.ObterPontosPorNpcId(id);
            Debug.Log($"NPC registrado: {id} -> {pontos} pontos (lido do PlayerPrefs)");
        }

        var pontosPorNpc = FalasDepois.ObterPontosPorNpc();
        if (pontosPorNpc == null || pontosPorNpc.Count == 0)
        {
            Debug.Log("Nenhum NPC registrado ou nenhuma pontuação encontrada via instâncias. Verifique se os componentes FalasDepois estão ativos na cena.");
            return;
        }

        var npcComMaisPontos = pontosPorNpc.OrderByDescending(p => p.Value).First();
        npcPontos = npcComMaisPontos.Key;
        Debug.Log($"NPC com mais pontos: {npcComMaisPontos.Key} ({npcComMaisPontos.Value} pontos)");
    }

    void Update()
    {
    }
}
