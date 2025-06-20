using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handels the player building mode. Allowing them to place buildings on the map.

public class BuildingManager : MonoBehaviour
{
    public bool BuildModeBool = false;

    public GameObject previewPrefab; // Drag in the building prefab to preview
    public Color previewColor = new Color(0f, 1f, 0f, 0.5f); // Green with transparency

    private GameObject previewObject;

    // Update is called once per frame
    void Update()
    {
        //moves the character in and out of build mode.
        if (Input.GetKeyUp(KeyCode.B))
        {
            if (BuildModeBool == false)
            {
                BuildModeBool = true;
                Debug.Log("In build mode");
                previewObject = Instantiate(previewPrefab);
                SetPreviewVisuals(previewObject);
            }
            else
            {
                CancelBuildMode();
            }
        }
        // While in build mode, move the preview object with the mouse
        // Right click, cancel build mode, Left click, try to place building.
        if (BuildModeBool == true && previewObject != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 snappedPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            previewObject.transform.position = snappedPos;

            //left mouse button, try to build building.
            if (Input.GetMouseButtonDown(0))
            {
                //check for enough money
                GameObject placedBuilding = Instantiate(previewPrefab, snappedPos, Quaternion.identity);
                placedBuilding.GetComponent<SpriteRenderer>().color = Color.white;

                Debug.Log("Building placed at: " + snappedPos);
                CancelBuildMode();

                //check for leagal placement (add later)
            }

            // Right-click to cancel
            if (Input.GetMouseButtonDown(1))
            {
                CancelBuildMode();
            }
        }

    }

    // Cancel build mode and destroy preview
    void CancelBuildMode()
    {
        BuildModeBool = false;
        Debug.Log("Out of build mode");

        if (previewObject != null)
        {
            Destroy(previewObject);
            previewObject = null;
        }
    }



    //set the preview appearance
    void SetPreviewVisuals(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = previewColor;
        }
    }
}
