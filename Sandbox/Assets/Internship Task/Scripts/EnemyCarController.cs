using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    public float force;
    public float rotationValue;
    private Rigidbody rg;
    public bool isMoving;
    public bool isMovingReverse;

    void OnEnable()
    {
        CarController.onNormalEnemyMovement += OnNormalMovementEventReceived;
        CarController.onReverseEnemyMovement += OnReverseMovementEventReceived;

    }

    void OnDisable()
    {
        CarController.onNormalEnemyMovement -= OnNormalMovementEventReceived;
        CarController.onReverseEnemyMovement -= OnReverseMovementEventReceived;

    }

    void OnDestroy()
    {
        CarController.onNormalEnemyMovement -= OnNormalMovementEventReceived;
        CarController.onReverseEnemyMovement -= OnReverseMovementEventReceived;
    }

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rg.AddForce(transform.forward * force * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0f, -rotationValue * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rg.AddForce(-transform.forward * force * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0f, rotationValue * Time.deltaTime, 0f);
            }
        }

        if (isMovingReverse)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rg.AddForce(-transform.forward * force * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                // rg.AddForce(Vector3.left * force * Time.deltaTime, ForceMode.Impulse);
                transform.Rotate(0f, rotationValue * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rg.AddForce(transform.forward * force * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                // rg.AddForce(Vector3.right * force * Time.deltaTime, ForceMode.Impulse);
                transform.Rotate(0f, -rotationValue * Time.deltaTime, 0f);
            }
        }
    }

    void OnNormalMovementEventReceived()
    {
        isMoving = true;
        isMovingReverse = false;
    }

    void OnReverseMovementEventReceived()
    {
        isMovingReverse = true;
        isMoving = false;
    }
}
