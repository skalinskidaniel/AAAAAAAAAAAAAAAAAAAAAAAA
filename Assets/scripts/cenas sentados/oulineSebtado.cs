using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class outlineSebtado : MonoBehaviour
{
    private Transform highlight;
    private Transform ultimoObjeto;
    private RaycastHit raycastHit;

    void Update()
    {
        // Desliga outline antigo
        if (highlight != null)
        {
            Outline oldOutline = highlight.GetComponent<Outline>();

            if (oldOutline != null)
                oldOutline.enabled = false;

            highlight = null;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;

            if (highlight.CompareTag("interajir"))
            {
                Outline outline = highlight.GetComponent<Outline>();

                if (outline == null)
                {
                    outline = highlight.gameObject.AddComponent<Outline>();
                    outline.OutlineColor = Color.white;
                    outline.OutlineWidth = 7.0f;
                }

                outline.enabled = true;


                // Entrou no personagem
                if (highlight != ultimoObjeto)
                {
                    // se estava em outro personagem, fecha ele
                    if (ultimoObjeto != null)
                    {
                        falacadaum antigo = ultimoObjeto.GetComponent<falacadaum>();

                        if (antigo != null)
                        {
                            antigo.fecharDialogo();
                        }
                    }

                    ultimoObjeto = highlight;

                    falacadaum dialogo = highlight.GetComponent<falacadaum>();

                    if (dialogo != null)
                    {
                        dialogo.abrirDialogo();
                    }
                }
            }
        }
        else
        {
            // Saiu do personagem
            if (ultimoObjeto != null)
            {
                falacadaum dialogo = ultimoObjeto.GetComponent<falacadaum>();

                if (dialogo != null)
                {
                    dialogo.fecharDialogo();
                }

                ultimoObjeto = null;
                highlight = null;
            }
        }
    }
}