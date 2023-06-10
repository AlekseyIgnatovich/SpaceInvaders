using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlComponent : MonoBehaviour
{
    public event Action OnShot;
    
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            OnShot?.Invoke();
        }
    }
}
