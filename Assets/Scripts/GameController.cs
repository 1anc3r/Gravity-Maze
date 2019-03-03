using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject maze;
    private float angleX;
    private float angleY;

    void Start()
    {

    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.D))
#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.acceleration.x > 0.10f)
#endif
        {
            if (angleX > -10f)
            {
                RotateObject(maze, Vector3.forward, -1);
                angleX += -1;
            }
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
#elif UNITY_IPHONE || UNITY_ANDROID
        else if (Input.acceleration.x < -0.10f)
#endif
        {
            if (angleX < 10f)
            {
                RotateObject(maze, Vector3.forward, 1);
                angleX += 1;
            }
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.acceleration.y > 0.10f)
#endif
        {
            if (angleY < 10f)
            {
                RotateObject(maze, Vector3.right, 1);
                angleY += 1;
            }
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.S))
#elif UNITY_IPHONE || UNITY_ANDROID
        else if (Input.acceleration.y < -0.10f)
#endif
        {
            if (angleY > -10f)
            {
                RotateObject(maze, Vector3.right, -1);
                angleY += -1;
            }
        }
    }

    private bool RotateObject(GameObject _gameObject, Vector3 axis, float angle)
    {
        if (_gameObject != null)
        {
            _gameObject.transform.Rotate(axis, angle, Space.World);
            return true;
        }
        else
        {
            return false;
        }
    }
}
