using UnityEngine;
using UnityEngine.InputSystem;

public class andarbonitinho : MonoBehaviour
{
   private playerInput _playerInput; 
    public float velo = 8f;               
    public float velocidadeGiro = 15f;   
    private Animator anim;
    private Rigidbody rb;

    void Awake()
    {
        _playerInput = GetComponent<playerInput>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (_playerInput == null) return;

        // rotação
        float giro = _playerInput.MoveInput.x * velocidadeGiro * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, giro, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

        Vector3 moveDirection = transform.forward * _playerInput.MoveInput.y;//anda pr aaonde ele ta olhando
        Vector3 velocity = moveDirection * velo;
        velocity.y = rb.linearVelocity.y; //gravidade nele
        anim.SetFloat("velocidade",_playerInput.MoveInput.y);

        rb.linearVelocity = velocity; //aplica a velocidade no rb
    }
    //agora se vc ta me perguntando pq o script q pega as entrada ta separado  é pq eu taa com sono c viu o jeito q eu tava podre e eu n vo junta eles agr pra n perde tempo so seguui o tutorial da moça la e boa
}
