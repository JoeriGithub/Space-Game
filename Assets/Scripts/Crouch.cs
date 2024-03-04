using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crouch : MonoBehaviour
{
    [SerializeField] Movement otherScript;
    [SerializeField] CapsuleCollider standCollider;
    [SerializeField] CapsuleCollider crouchCollider;
    void OnCrouch(InputValue value)
    {
        if (crouchCollider.enabled)
        {
            crouchCollider.enabled = false;
            standCollider.enabled = true;
            otherScript.moveSpeed = 5;
        }
        else
        {
            standCollider.enabled = false;
            crouchCollider.enabled = true;
            otherScript.moveSpeed = 2;
        }
    }
}
