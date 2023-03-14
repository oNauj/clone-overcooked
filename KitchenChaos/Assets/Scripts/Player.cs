using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private void Update()
    {
        Vector2 inputVector = GetMoveDir();

        MovePosition(inputVector);
    }

    private Vector2 GetMoveDir()
    {
        Vector2 inputVector = new Vector2(0f, 0f);
        bool isKeyDown_W = Input.GetKey(KeyCode.W);
        bool isKeyDown_S = Input.GetKey(KeyCode.S);
        bool isKeyDown_A = Input.GetKey(KeyCode.A);
        bool isKeyDown_D = Input.GetKey(KeyCode.D);

        if (isKeyDown_W)
        {
            inputVector.y += 1f;
        }
        else if (isKeyDown_S)
        {
            inputVector.y -= 1f;
        }
        if (isKeyDown_A)
        {
            inputVector.x -= 1f;
        }
        else if (isKeyDown_D)
        {
            inputVector.x += 1f;
        }

        return inputVector;
    }

    private void MovePosition(Vector2 inputVector)
    {
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        this.transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
