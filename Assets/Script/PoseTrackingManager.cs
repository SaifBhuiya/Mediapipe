//// Script 1: PoseTrackingManager.cs - Attach to an empty GameObject
//using UnityEngine;
//using Mediapipe.Unity;
//using UnityEngine.UI;

//public class PoseTrackingManager : MonoBehaviour
//{
//    public PoseTrackingSolution poseTrackingSolution;
//    public RawImage webCamScreen;
//    private WebCamTexture webCamTexture;

//    void Start()
//    {
//        // Set up webcam
//        webCamTexture = new WebCamTexture();
//        webCamScreen.texture = webCamTexture;
//        webCamTexture.Play();

//        // Set up pose tracking
//        poseTrackingSolution.OnPoseDetectionOutput.AddListener(OnPoseDetected);
//        poseTrackingSolution.Play();
//    }

//    void OnPoseDetected(OutputEventArgs<PoseLandmarkList> eventArgs)
//    {
//        var poseLandmarks = eventArgs.value;
//        if (poseLandmarks != null)
//        {
//            // Example: Get nose position (landmark 0)
//            var nose = poseLandmarks.Landmark[0];
//            Vector3 nosePosition = new Vector3(
//                nose.X * Screen.width,
//                (1 - nose.Y) * Screen.height,
//                nose.Z
//            );
//            Debug.Log($"Nose position: {nosePosition}");

//            // Example: Get hands positions
//            var leftHand = poseLandmarks.Landmark[19];
//            var rightHand = poseLandmarks.Landmark[20];
//            Debug.Log($"Left Hand: {leftHand.X}, {leftHand.Y}, {leftHand.Z}");
//            Debug.Log($"Right Hand: {rightHand.X}, {rightHand.Y}, {rightHand.Z}");
//        }
//    }

//    void OnDestroy()
//    {
//        if (webCamTexture != null)
//        {
//            webCamTexture.Stop();
//        }
//    }
//}