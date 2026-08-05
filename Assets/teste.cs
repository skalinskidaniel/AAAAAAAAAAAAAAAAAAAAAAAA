using UnityEngine;
using UnityEngine.InputSystem;

public class teste : MonoBehaviour
{
    public InputAction input;
    public Vector2 inputV;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputV = input.ReadValue<Vector2>();
        Debug.Log(inputV);
    }
}
