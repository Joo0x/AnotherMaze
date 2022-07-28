
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerActionsInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    private InputActions _input;

    public bool InvertedY { get; private set; } = true;

    public bool isMovingactive = false;
    
    private void OnEnable()
    {
        _input = new InputActions();
        _input.playerActions.Enable();

        _input.playerActions.Move.performed += SetMove;
        _input.playerActions.Move.canceled += SetMove;
        
        _input.playerActions.Look.performed += SetLook;
        _input.playerActions.Look.canceled += SetLook;



    }

    private void OnDisable()
    {
        _input.playerActions.Move.performed -= SetMove;
        _input.playerActions.Move.canceled -= SetMove;
        
        _input.playerActions.Look.performed -= SetLook;
        _input.playerActions.Look.canceled -= SetLook;
        
        _input.Disable();
        
    }

    void SetMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();

        isMovingactive = !(MoveInput == Vector2.zero);
    }
    
    void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput =ctx.ReadValue<Vector2>();
    }
}
