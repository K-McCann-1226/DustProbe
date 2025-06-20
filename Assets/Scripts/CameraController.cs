using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2f; // Speed of drag movement
    public float zoomSpeed = 5f; // Speed of zooming
    public float minZoom = 10f; // Minimum zoom limit
    public float maxZoom = 50f; // Maximum zoom limit
    public float edgeScrollSpeed = 0f; // Speed of edge scrolling
    public float edgeThreshold = 50f; // How close to the edge before scrolling starts

    private Vector3 targetPosition; // Target position for smooth movement
    private Vector3 dragOrigin; // Stores initial mouse click position
    private float targetZoom; // Target zoom level

    void Start()
    {
        targetPosition = transform.position;
        targetZoom = Camera.main.orthographicSize;
    }

    void Update()
    {
        HandleCameraDrag();
        HandleZoom();
        HandleEdgeScrolling();
        SmoothMove();
    }

    void HandleCameraDrag()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click pressed
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) // Right-click held
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(dragOrigin) - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition += difference;
            dragOrigin = Input.mousePosition;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
    }

    void HandleEdgeScrolling()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.mousePosition.x <= edgeThreshold) // Left edge
            moveDirection.x -= 1;
        if (Input.mousePosition.x >= Screen.width - edgeThreshold) // Right edge
            moveDirection.x += 1;
        if (Input.mousePosition.y <= edgeThreshold) // Bottom edge
            moveDirection.y -= 1;
        if (Input.mousePosition.y >= Screen.height - edgeThreshold) // Top edge
            moveDirection.y += 1;

        targetPosition += moveDirection.normalized * edgeScrollSpeed * Time.deltaTime;
    }

    void SmoothMove()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * dragSpeed);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}
