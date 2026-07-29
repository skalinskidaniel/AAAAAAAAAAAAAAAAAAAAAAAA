using UnityEngine;
using UnityEngine.EventSystems;

public class detecMause : MonoBehaviour, IPointerEnterHandler
{
    public enum Direcao
    {
        Esquerda,
        Direita,
        Baixo
    }

    public Direcao direcao;

    public GameObject Camera;

    public Transform alvoEsquerda;
    public Transform alvoDireita;
    public Transform alvoBaixo;

    private static Quaternion alvo;
    public float velocidadeRotacao = 2f;

    void Start()
    {
        alvo = Camera.transform.rotation;
    }

    void Update()
    {
        Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation,alvo,velocidadeRotacao * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (direcao)
        {
            case Direcao.Esquerda:
                alvo = Quaternion.LookRotation(alvoEsquerda.position - Camera.transform.position);
                break;

            case Direcao.Direita:
                alvo = Quaternion.LookRotation(alvoDireita.position - Camera.transform.position);
                break;

            case Direcao.Baixo:
                alvo = Quaternion.LookRotation(alvoBaixo.position - Camera.transform.position);
                break;
        }
    }
}