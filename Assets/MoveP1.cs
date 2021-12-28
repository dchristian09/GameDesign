using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP1 : MonoBehaviour
{ 
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.right * (Time.deltaTime * 32);
        }
    }
}
