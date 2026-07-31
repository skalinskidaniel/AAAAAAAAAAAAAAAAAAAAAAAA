using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sai : MonoBehaviour
{
    public string nome;
    public void Mongus()
    {
        SceneManager.LoadScene(nome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
