using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP2 : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            transform.position += transform.right * (Time.deltaTime * 32);
        }

    }
}
