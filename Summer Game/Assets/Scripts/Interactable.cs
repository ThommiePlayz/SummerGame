using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey)) 
            {
                interactAction.Invoke();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("There is collision");
        if(collision.gameObject.CompareTag("Player")) 
        {
            // Debug.Log("You can interact with the book");
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("Collision is no more");
        if(collision.gameObject.CompareTag("Player")) 
        {
            // Debug.Log("You cannot interact with the book");
            isInRange = false;
        }
        
    }
}
