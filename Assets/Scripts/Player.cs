using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CubeModelSO cubeModel;

    private Vector3 _prevPos;
    private Vector3 _prevRot;

    private Vector2 _moveAmount;


    void Start()
    {
        transform.localPosition = cubeModel.position;
        transform.localEulerAngles = cubeModel.rotation;
        _prevPos = transform.localPosition;
        _prevRot = transform.localEulerAngles;
    }

    void Update()
    {
        Move(_moveAmount);

        if (transform.localPosition != _prevPos || transform.localEulerAngles != _prevRot)
        {
            cubeModel.position = transform.localPosition;
            cubeModel.rotation = transform.localEulerAngles;

            _prevPos = transform.localPosition;
            _prevRot = transform.localEulerAngles;
        }
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        float scaledMoveSpeed = cubeModel.moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        _moveAmount = context.ReadValue<Vector2>();
    }
}
