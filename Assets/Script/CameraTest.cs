using UnityEngine;
using UnityEngine.UI;

public class CameraTest : MonoBehaviour
{
    public RawImage rawImage; // Assign the UI RawImage in the Unity Editor
    private WebCamTexture webCamTexture;

    void Start()
    {
        // Check if the device has a camera
        if (WebCamTexture.devices.Length > 0)
        {
            // Get the default camera
            webCamTexture = new WebCamTexture();
            rawImage.texture = webCamTexture;
            rawImage.material.mainTexture = webCamTexture;

            // Start the camera
            webCamTexture.Play();
            // Adjust the rotation based on the camera orientation
            rawImage.rectTransform.localEulerAngles = new Vector3(0, 0, -90); // Rotate -90 degrees

        }
        else
        {
            Debug.LogError("No camera found on the device!");
        }
    }

    void OnDestroy()
    {
        // Stop the camera when the object is destroyed
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
