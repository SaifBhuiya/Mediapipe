using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mptcc = Mediapipe.Tasks.Components.Containers;

public class ArmorMovement : MonoBehaviour
{
    public GameObject Main_Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // print(Main_Canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0));   
        //print(mptcc.NormalizedLandmark);
    }
    //public List<int> Points(mptcc.NormalizedLandmarks poseLandmarks)
    //{
    //    //accessing landmarks
       
    //        //print(poseLandmarks.landmarks);
   
    //}
}
