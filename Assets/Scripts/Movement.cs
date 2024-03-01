using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody _rigidbody;

    [SerializeField] private float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movement.x, 0, movement.y) * moveSpeed * Time.deltaTime);
    }

    void OnJump(InputValue value)
    {
        if (!enabled) return;

        _rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }
    
    void OnMove(InputValue value)
    {
        if (!enabled) return;

        movement = value.Get<Vector2>();
    }
}
