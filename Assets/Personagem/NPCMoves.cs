
using UnityEngine;

public class NPCMoves : MonoBehaviour
{
    public Animator aim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aim = GetComponent<Animator>();
    }
}

