using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Movement variables
    private float movementX;
    private float movementY;
    private float speed = 5f;

    // Bank transaction variables
    // Initialize in the inspector
    public string playerName;
    public int playerPin;
    public float cashOnPlayer;
    public float cashToDeposit;
    public float cashToWithdraw;

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = new Vector3(movementX, 0f, movementY);
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
