using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public Vector2 MoveInput{get;private set;} 
    public void OnMove (InputValue inputValue)
   {
     MoveInput = inputValue.Get<Vector2>();
   }
}
