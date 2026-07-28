using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem; // Importante para o novo Input System

public class outline : MonoBehaviour
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
        Debug.Log ("chamo a função");
        if(highlight!=null)
        {
            Debug.Log("entro no if");
            falacadaum diaslogo = highlight.GetComponent<falacadaum>();
            if(diaslogo!=null)
            {
                diaslogo.abrirDialogo();
            }
            Cursor.lockState = CursorLockMode.None;
        }
    }
}