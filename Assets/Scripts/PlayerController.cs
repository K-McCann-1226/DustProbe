using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
        //HandleMovementCommand();
        }
    }
    
    void HandleMovementCommand()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Move command issued to: " + hit.point);
            // We'll later send this to a selected unit
        }
    }
}
