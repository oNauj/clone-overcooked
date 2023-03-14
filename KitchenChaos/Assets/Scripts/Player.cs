using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed = 9f;

    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        MovePosition(inputVector);
    }



    private void MovePosition(Vector2 inputVector)
    {
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        this.transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
