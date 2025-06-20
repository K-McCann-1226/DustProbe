using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // On right-click
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse position in world coordinates
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            targetPosition = mouseWorldPos;
            isMoving = true;

            Debug.DrawLine(transform.position, mouseWorldPos, Color.green, 3f);
        }

        // Move player toward target
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Stop when close enough
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                
                
            }
        }
    }
}
