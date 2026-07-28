
using UnityEngine;
using UnityEngine.InputSystem;
public class MovimentacaoV2 : MonoBehaviour
{
   public float rotatevelo;
    private Rigidbody rb;
    private Animator animator;
    private Vector3 dire;

    public float velo = 5f;
    
    [SerializeField] private AudioSource passossource;
    [SerializeField] private AudioClip[] passosVariacao;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void OnMove(InputValue value)
    {
        dire = value.Get<Vector2>();//ta lendo/guardando os input
        animator.SetBool("Andando",dire !=Vector3.zero);   
    } 

    private void FixedUpdate()
    {
        Vector3 movimento =new Vector3(dire.x,0f,dire.y);//bota na variavel movimento onde ela deve ir 
        rb.MovePosition(rb.position + movimento * velo * Time.fixedDeltaTime); //faz a conta /move de vdd
        rodieiaSuave();
    }
    void rodieiaSuave()
    {
        Vector3 movimento = new Vector3(dire.x, 0f, dire.y);
        if(movimento !=Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movimento,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate,rotatevelo*Time.deltaTime);
        }
    }
    private void Passos() // pra toca os som definidos na animação algume fora eu leu minhas anotações ? eu me sinto o thanos em ultimato quando vira fazendeiro
    {
        passossource.PlayOneShot(passosVariacao[Random.Range(0,passosVariacao.Length)]);
    }
}
