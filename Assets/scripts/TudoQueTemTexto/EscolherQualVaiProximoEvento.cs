using System.Linq;
using UnityEngine;

public class EscolherQualVaiProximoEvento : MonoBehaviour
{
    public static string QualNpc { get; private set; }

    void Start()
    {
        var pontosPorNpc = FalasDepois.ObterPontosPorNpc();
        if (pontosPorNpc == null || pontosPorNpc.Count == 0)
        {
            QualNpc = string.Empty;
            Debug.Log("Nenhum NPC registrado ou nenhuma pontuação encontrada.");
            return;
        }
        
        var npcComMaisPontos = pontosPorNpc.OrderByDescending(p => p.Value).First();
        QualNpc = npcComMaisPontos.Key;
        Debug.Log($"NPC com mais pontos: {npcComMaisPontos.Key} ({npcComMaisPontos.Value} pontos)");
        Debug.Log($"NPC selecionado para o próximo evento: {QualNpc}");   
    }

    void Update()
    {
    }
}
