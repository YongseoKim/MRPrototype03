using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch; // Left controller
    public GameObject canvasGameObject; // Canvas GameObject
    public GameObject xrRig; // Player base point for canvas coordinates
    public Canvas canvasComponent; // Canvas component
    public float canvasDistanceForward = 0.6f;
    public float height = 1.3f; // Canvas의 높이, 공개 변수로 설정

    private bool isCanvasVisible = false; // Canvas visibility state
    private bool wasXButtonPressed = false; // Previous state of the X button

    void Start()
    {
        canvasGameObject.SetActive(false); // Canvas를 시작할 때 비활성화
    }

    void Update()
    {
        // Check for X button toggle
        if (OVRInput.GetDown(OVRInput.Button.One, leftController)) // Check if X button is pressed
        {
            ToggleMainCanvas();
        }
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvasGameObject.SetActive(isCanvasVisible);

        // Update position and rotation only when canvas is activated
        if (isCanvasVisible && xrRig != null)
        {
            // Get the rotation of the user and apply it to the forward direction
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // Compute the new canvas position using the adjusted forward direction
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height; // Set Y axis to public height variable

            canvasGameObject.transform.position = canvasPosition;
            // Optionally set the canvas to face the player directly
            canvasGameObject.transform.rotation = rotation;
        }
    }
}
