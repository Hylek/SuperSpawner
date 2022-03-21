using System;
using UnityEngine;

// todo: Both this class and Tank are very similar, should be combined into base class or similar.

public class Soldier : Unit
{
    [SerializeField] private float speed;
    
    private bool _canMove;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public override void Activate()
    {
        base.Activate();
        
        Advance();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
    }
    
    public void Advance()
    {
        _canMove = true;
    }

    public void Stop()
    {
        _canMove = false;
    }

    public void Move()
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime); 
    }

    public void Shoot()
    {
        
    }
}