using UnityEngine;
using UnityEngine.SceneManagement;

public class Butão : MonoBehaviour
{
    public string nomeDaCena;

    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
