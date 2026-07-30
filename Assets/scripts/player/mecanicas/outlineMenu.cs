using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class outlineMenu : MonoBehaviour
{
    private Transform highlight;
    private Transform selecao;
    private RaycastHit raycastHit;

    void Awake()

    {
        
        
    }

    void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("interajir") && highlight != selecao)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }
    public void OnClique()
    {
        if(highlight!=null)
        {
            opcoes abrir = highlight.GetComponent<opcoes>();
            if(abrir!=null)
            {
                abrir.abrirDialogos();
            }
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            Debug.Log("n é o play");
        }
        if(highlight!=null)
        {
            creditos abrirs = highlight.GetComponent<creditos>();
            if(abrirs!=null)
            {
                abrirs.abrirDialogos();
            }
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
           Debug.Log("ta dboas");
        }
        if(highlight!=null)
        {
            falacadaum abrirs = highlight.GetComponent<falacadaum>();
            if(abrirs!=null)
            {
                abrirs.abrirDialogo();
            }
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {

        }
    }
}
