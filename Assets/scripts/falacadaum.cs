using UnityEngine;

public class falacadaum : MonoBehaviour
{
    public GameObject canva;
    public void abrirDialogo()
    {
        if (canva != null)
        {
            canva.SetActive(true);
        }
    }
}
