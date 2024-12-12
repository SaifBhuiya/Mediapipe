using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontEnd : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartAR()
    {
        SceneManager.LoadScene("MediaPipeUnity/Samples/Scenes/Pose Landmark Detection/Pose Landmark Detection");
        //Debug.Log("Lol");
    }
    public void QuitApplication()
    {
        Debug.Log("Application is quitting..."); // Log message (useful for debugging in the editor)
        Application.Quit(); // Quit the application
    }
    public void Info()
    {
       // SceneManager.LoadScene("");
        Debug.Log("Lol");
    }
}
