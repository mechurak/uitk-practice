using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public MyInputManager myInputManager;

    private TextField _textField;
    
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _textField = root.Q<TextField>("pos-textfield");
        _textField.RegisterCallback<FocusInEvent>(OnFocusIn);
        _textField.RegisterCallback<FocusOutEvent>(OnFocusOut);
    }

    private void OnFocusIn(FocusInEvent evt) {
        Debug.Log("OnFocusIn");
        myInputManager.SetUiMode(true);
    }

    private void OnFocusOut(FocusOutEvent evt) {
        Debug.Log("OnFocusOut");
        myInputManager.SetUiMode(false);
    }
}
