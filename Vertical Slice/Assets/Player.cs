using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] InputActionAsset inputAsset;
    PlayerInput input;
    InputAction moveAction;
    [SerializeField] CharacterController controller;
    [SerializeField] int speed;
    Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        moveAction = inputAsset.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();

        Vector3 move = movementInput.x * transform.right + movementInput.y * transform.forward;


        controller.Move(move * speed * Time.deltaTime);
    }
}
