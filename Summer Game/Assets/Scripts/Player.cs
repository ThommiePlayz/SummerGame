using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveTime = 10f;
    private bool AllowedMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    if (AllowedMovement == true){    
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            int xDir = 0;
            int yDir = 1;
            StartCoroutine(Movement(xDir, yDir));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            int xDir = 0;
            int yDir = -1;
            StartCoroutine(Movement(xDir, yDir));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            int xDir = -1;
            int yDir = 0;
            StartCoroutine(Movement(xDir, yDir));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            int xDir = 1;
            int yDir = 0;
            StartCoroutine(Movement(xDir, yDir));
        }
    }
    }

    IEnumerator Movement (int xDir, int yDir)
    {
        AllowedMovement = false;
        
        Vector2 currentPosition = transform.position;
        Vector3 end = currentPosition + new Vector2(xDir, yDir);

        float RemainingDistance = (transform.position - end).sqrMagnitude;
        while(RemainingDistance > float.Epsilon)
        {
            rigidBody.MovePosition (Vector3.MoveTowards(rigidBody.position, end, moveTime * Time.deltaTime));
            RemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        
        AllowedMovement = true;
    }
}