using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ddtetcMause : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public bool mause = false;
    public float veloR = 50f;
    private Quaternion rotacaoAlvo;

    public GameObject Cesquerdo;
    public GameObject Cdireito;
    public GameObject Cembaixo;
    public GameObject Camera;

    //private float tempR = 5f;
    //private Vector3 velo = new Vector3(0, 0, 2);
    //public Vector3 target;
    //public Transform esfera;

    // Update is called once per frame
    void Start()
    {
       // rotacaoAlvo = Camera.transform.rotation;
    }
    void Update()
    {
       // Camera.transform.rotation = Quaternion.RotateTowards(Camera.transform.rotation,rotacaoAlvo,veloR*Time.deltaTime);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        Debug.Log("us rato entro pra dantroa na panela");
        mause = true;
        viraraDireita();
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
