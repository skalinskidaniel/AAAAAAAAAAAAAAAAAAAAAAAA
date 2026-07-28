using UnityEngine;
using UnityEngine.EventSystems;

public class detecMauseL : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mause = false;
    public GameObject Camera;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("us rato entro pra dança no microondas");
        mause = true;
        viraraEsquerda();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("o rato saiu do micoondas");
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
