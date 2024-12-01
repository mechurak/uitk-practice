using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputManager : MonoBehaviour
{
    private InputAction _navigateAction;
    private InputActionMap _playerActionMap;

    void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        _navigateAction = playerInput.actions.FindAction("UI/Navigate");
        _playerActionMap = playerInput.actions.FindActionMap("Player");
        Debug.Log(playerInput.defaultActionMap);
        Debug.Log(playerInput.defaultActionMap);

        // TODO: 처음 시작할 때, navigateAction 이 disable 되어 있지 않음. wasd 누르면, TextField 에 포커싱이 감
        SetUiMode(false);
    }

    public void SetUiMode(bool enabled)
    {
        Debug.Log($"SetUiMode({enabled})");
        if (enabled)
        {
            _playerActionMap.Disable();
            _navigateAction.Enable();
        }
        else
        {
            _playerActionMap.Enable();
            _navigateAction.Disable();
        }
    }
}
