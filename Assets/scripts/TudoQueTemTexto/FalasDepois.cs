using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

public class FalasDepois : MonoBehaviour
{
    private static readonly List<FalasDepois> instancias = new List<FalasDepois>();
    private static readonly HashSet<string> idsRegistrados = new HashSet<string>();

    [Tooltip("Identificador único do NPC para salvar o estado de conversa.")]
    public string NpcId = "npc_default";

    [Tooltip("Quantidade de pontos que o jogador ganha ao conversar com este NPC.")]
    public int PontosPorConversa = 1;

    private string ChaveConversa => $"conversou_com_npc_{NpcId}";
    private string ChavePontos => $"pontos_npc_{NpcId}";

    public bool ConversouComNpc { get; private set; }
    public int PontosNpc { get; private set; }

    public static IReadOnlyList<FalasDepois> Instancias => instancias;
    public static IReadOnlyCollection<string> NpcsRegistrados => idsRegistrados;

    private void Awake()
    {
        if (string.IsNullOrWhiteSpace(NpcId))
        {
            Debug.LogWarning($"NpcId não definido em {name}. Use um ID único para cada NPC.");
            NpcId = "npc_default";
        }

        ConversouComNpc = PlayerPrefs.GetInt(ChaveConversa, 0) == 1;
        PontosNpc = PlayerPrefs.GetInt(ChavePontos, 0);

        if (!instancias.Contains(this))
            instancias.Add(this);

        idsRegistrados.Add(NpcId);
    }

    private void OnDestroy()
    {
        instancias.Remove(this);
    }

    public void MarcarConversa()
    {
        if (ConversouComNpc)
            return;

        ConversouComNpc = true;
        PlayerPrefs.SetInt(ChaveConversa, 1);
        AdicionarPontos(PontosPorConversa);
        PlayerPrefs.Save();
    }

    public void AdicionarPontos(int pontos)
    {
        if (pontos <= 0)
            return;

        PontosNpc += pontos;
        PlayerPrefs.SetInt(ChavePontos, PontosNpc);
    }

    public bool VerificarConversa()
    {
        return ConversouComNpc;
    }

    public void ResetarConversa()
    {
        ConversouComNpc = false;
        PontosNpc = 0;
        PlayerPrefs.SetInt(ChaveConversa, 0);
        PlayerPrefs.SetInt(ChavePontos, 0);
        PlayerPrefs.Save();
    }

    public static int ObterPontuacaoTotal()
    {
        int total = 0;
        foreach (var npc in instancias)
        {
            total += npc.PontosNpc;
        }
        return total;
    }

    public static Dictionary<string, int> ObterPontosPorNpc()
    {
        var resultado = new Dictionary<string, int>();
        foreach (var npc in instancias)
        {
            if (!resultado.ContainsKey(npc.NpcId))
            {
                resultado[npc.NpcId] = npc.PontosNpc;
            }
        }
        return resultado;
    }

    public static int ObterPontosPorNpcId(string npcId)
    {
        return PlayerPrefs.GetInt($"pontos_npc_{npcId}", 0);
    }
}
