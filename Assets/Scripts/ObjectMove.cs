using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float moveSpeed;

    private void FixedUpdate()
    {
        moveSpeed = GameManager.objectMoveSpeed;
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.fixedDeltaTime, transform.position.y, 0);    
    }
}
