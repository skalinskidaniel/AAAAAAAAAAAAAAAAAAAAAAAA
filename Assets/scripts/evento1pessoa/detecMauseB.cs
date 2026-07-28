using UnityEngine;
using UnityEngine.EventSystems;

public class detecMauseB : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mause = false;
    public GameObject Camera;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("us rato entro pra dança na panela de presão");
        mause = true;
        virarembaixo();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("o rato saiu da panela");
    }


    public void viraraEsquerda()
    {
        Camera.transform.rotation = Quaternion.Euler(0, -50, 0);
    }
    public void viraraDireita()
    {
        Camera.transform.rotation = Quaternion.Euler(0, 50, 0);
    }
    public void virarembaixo()
    {

        //Camera.transform.rotation = Vector3.SmoothDamp(transform.position,target,ref velo,tempR);
        //Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation,Quaternion.Euler(100,0,0),7f*Time.deltaTime);
        Camera.transform.rotation = Quaternion.Euler(50, 0, 0);
    }
}
