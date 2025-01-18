// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using UnityEngine;
using UnityEngine.UI;

using mptcc = Mediapipe.Tasks.Components.Containers;

namespace Mediapipe.Unity
{
#pragma warning disable IDE0065
  using Color = UnityEngine.Color;
    
#pragma warning restore IDE0065

    public sealed class PoseLandmarkListWithMaskAnnotation : HierarchicalAnnotation
  {
    [SerializeField] private PoseLandmarkListAnnotation _poseLandmarkListAnnotation;
    [SerializeField] private MaskOverlayAnnotation _maskOverlayAnnotation;
    [SerializeField] private GameObject Armor;
        private bool rotate;
        private bool scale;
        private GameObject obj;
        private RawImage scalecol;

        public override bool isMirrored
    {
      set
      {
        _poseLandmarkListAnnotation.isMirrored = value;
        _maskOverlayAnnotation.isMirrored = value;
        base.isMirrored = value;
      }
    }

    public override RotationAngle rotationAngle
    {
      set
      {
        _poseLandmarkListAnnotation.rotationAngle = value;
        _maskOverlayAnnotation.rotationAngle = value;
        base.rotationAngle = value;
      }
    }

    public void InitMask(RawImage screen, int width, int height) => _maskOverlayAnnotation.Init(screen, width, height);

    public void SetLeftLandmarkColor(Color leftLandmarkColor) => _poseLandmarkListAnnotation.SetLeftLandmarkColor(leftLandmarkColor);

    public void SetRightLandmarkColor(Color rightLandmarkColor) => _poseLandmarkListAnnotation.SetRightLandmarkColor(rightLandmarkColor);

    public void SetLandmarkRadius(float landmarkRadius) => _poseLandmarkListAnnotation.SetLandmarkRadius(landmarkRadius);

    public void SetConnectionColor(Color connectionColor) => _poseLandmarkListAnnotation.SetConnectionColor(connectionColor);

    public void SetConnectionWidth(float connectionWidth) => _poseLandmarkListAnnotation.SetConnectionWidth(connectionWidth);

    public void SetMaskTexture(Texture2D maskTexture, Color color) => _maskOverlayAnnotation.SetMaskTexture(maskTexture, color);

    public void SetMaskThreshold(float threshold) => _maskOverlayAnnotation.SetThreshold(threshold);

    public void ReadMask(Image segmentationMask, bool isMirrored = false) => _maskOverlayAnnotation.Read(segmentationMask, isMirrored);

    public void Draw(mptcc.NormalizedLandmarks poseLandmarks, bool visualizeZ = false)
    {
      if (ActivateFor(poseLandmarks.landmarks))
      {

                //Armor contains the Armor GameObject
                // GameObject obj = GameObject.Find("BasicBodyArmorM_Skinned");


                
                if (obj == null) {
                    obj = GameObject.Find("PoloShirt");
                    Armor = obj;
                }
               // print(this.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.Find("Canvas").transform.Find("Scale Button").transform.Find("Scale"));
                if (scalecol == null)
                {
                    scalecol = this.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.Find("Canvas").transform.Find("Scale Button").transform.Find("Scale").transform.GetComponent<RawImage>();
                }
                    //#SCALE
                //float scale = (float)(410.21 *(poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x) - 33.35)*10;
                //float scale = (float)(400 * (poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x))*10;
                if (Input.GetButtonDown("Scale"))
                {
                    print("propagada");

                    if (scale == true)
                    {
                        scale = false;
                    }
                    else
                    {
                        scale = true;
                    }
                    
                    

                }
                if (scale)
                {
                    float scale_val = (float)(467.283 * (poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x) - 97.08);
                    Armor.transform.localScale = new Vector3(scale_val, scale_val, scale_val);
                    scalecol.color = Color.green;
                    if (scale_val<= 20)
                    {
                        scale_val = 20;
                        Armor.transform.localScale = new Vector3(scale_val, scale_val, scale_val);
                    }
                    if (scale_val >= 42)
                    {
                        scale_val = 42;
                        Armor.transform.localScale = new Vector3(scale_val, scale_val, scale_val);
                    }
                }
                else
                {
                    scalecol.color = Color.red;
                    Armor.transform.localScale = new Vector3(28,28,28);
                }

                //#POSITION
                //float position_x = (float)((poseLandmarks.landmarks[11].x + poseLandmarks.landmarks[12].x + poseLandmarks.landmarks[23].x + poseLandmarks.landmarks[24].x) / 4.0);
                float position_x1 = (float)((poseLandmarks.landmarks[11].x + poseLandmarks.landmarks[12].x) / 2.0);
                //float position_y = (float)((poseLandmarks.landmarks[11].y + poseLandmarks.landmarks[12].y + poseLandmarks.landmarks[23].y + poseLandmarks.landmarks[24].y) / 4.0);
                float position_y1 = (float)((poseLandmarks.landmarks[11].y + poseLandmarks.landmarks[12].y) / 2.0);

                Armor.transform.localPosition = new Vector3((int)((position_x1*200)-100)*10,(int)(-(position_y1*100)-30)*10,60);

               //print(position_x1);
                //print(position_y1);
                //print(poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x);
                // Armor.transform.localPosition = new Vector3((int)((position_x1*200) - 100)*10 ,     (int)(-(position_y1 * 100) - 110)*10 ,    -85);
                //Armor.transform.localPosition = new Vector3((int)((position_x1 * 200) - 100) * 10, -3000, -85);

                //Vector3 currentPosition =   Armor.transform.localPosition;
                //currentPosition.x = (int)((position_x1 * 200) - 100) * 10; 

                // currentPosition.y = (int)((-1.78 * scale) - 139);
                // Armor.transform.localPosition = currentPosition;
                // print(poseLandmarks.landmarks[11].y);
                // print(obj.transform.position);
                // print("hihi" + poseLandmarks.landmarks[12].y);
                //print(poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x);

                //print(Armor);
                float shoulder_width = EuclideanDistance(poseLandmarks.landmarks[12].x, poseLandmarks.landmarks[12].y, poseLandmarks.landmarks[11].x, poseLandmarks.landmarks[11].y);
                float hip_width = EuclideanDistance(poseLandmarks.landmarks[24].x, poseLandmarks.landmarks[24].y, poseLandmarks.landmarks[23].x, poseLandmarks.landmarks[23].y);
                float chest_size = Mathf.PI * (shoulder_width + hip_width);
                if (Input.GetButtonDown("CaptureSize"))
                {
                    //Debug.Log(chest_size);
                    print("Chest Size: " + chest_size * 30.6 + " inch");
                    Debug.Log("poseLandmarks.landmarks[23].z");
                    Debug.Log(poseLandmarks.landmarks[11].z - poseLandmarks.landmarks[12].z);
                }                //38-35-37 chest/belly/hip
               
                float opp = poseLandmarks.landmarks[11].z - poseLandmarks.landmarks[12].z;
                float adj = poseLandmarks.landmarks[11].x - poseLandmarks.landmarks[12].x;
                // print("opp = " + opp);
                // print("adj = " + adj);



                //Armor.transform.rotation = Quaternion.Euler(-90, 180 , - Mathf.Atan2(opp, adj) * (180 / Mathf.PI) + 30f * Time.deltaTime);

                float threshold = .01f; // Minimum value to trigger rotation
                float smoothSpeed = 20f; // Speed of rotation smoothing

                // Check if input values are significant enough
                if (Mathf.Abs(opp) > threshold || Mathf.Abs(adj) > threshold)
                {
                    // Calculate the angle from opp and adj
                    float angle = Mathf.Atan2(opp, adj) * Mathf.Rad2Deg;

                    // Define the target rotation
                    Quaternion targetRotation = Quaternion.Euler(-90, 180, -angle);

                    // Smoothly rotate towards the target
                    Armor.transform.rotation = Quaternion.Lerp(
                        Armor.transform.rotation,
                        targetRotation,
                        Time.deltaTime * smoothSpeed
                    );
                }





                //Debug.Log(Mathf.Atan2(opp, adj) * (180/Mathf.PI));


                //if (Input.GetButtonDown("Rotate"))
                //{
                //    if (rotate == true)
                //    {
                //        rotate = false;
                //    }
                //    else
                //    {
                //        rotate = true;
                //    }
                //    if (rotate)
                //    {

                //    }

                //}



                _poseLandmarkListAnnotation.Draw(poseLandmarks, visualizeZ);
                _maskOverlayAnnotation.Draw();
      }
    }

        private float EuclideanDistance(float x1, float y1, float x2, float y2)
        {
            if (x1 == null || y1 == null || x2 == null || y2 == null)
            {
                return 0;
            }
            else
            {
                return
                  Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));
            }
        }

        }

        
}
