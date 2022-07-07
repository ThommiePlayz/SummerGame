using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask WhatStopsMovement;
    private Vector3 end;


    // Start is called before the first frame update
    void Start()
    {
        end = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        walk();
        
    }

    void walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, end, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, end) <= 0.0f) 
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f, WhatStopsMovement)) 
            {
                end += new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !Physics2D.OverlapCircle(transform.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f, WhatStopsMovement)) 
            {
                end += new Vector3(0.0f, Input.GetAxisRaw("Vertical"), 0.0f);
            }
        }
    }
    
}