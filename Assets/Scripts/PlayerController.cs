using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    const string RUN_ANIMATOR_TRIGGER = "Run";
    const string SHOOT_ANIMATOR_TRIGGER = "Shoot";
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(SHOOT_ANIMATOR_TRIGGER);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger(RUN_ANIMATOR_TRIGGER);
        }
    }


    private void OnValidate()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }
}
