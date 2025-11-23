using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float xMove = Input.GetKey(KeyCode.S) ? speed : Input.GetKey(KeyCode.W) ? -speed : 0f;
        float zMove = Input.GetKey(KeyCode.D) ? speed : Input.GetKey(KeyCode.A) ? -speed : 0f;

        Vector3 direction = new Vector3(xMove, 0, zMove).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
