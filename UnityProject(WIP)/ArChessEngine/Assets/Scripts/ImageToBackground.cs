using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
public class ImageToBackground : MonoBehaviour
{

   public OpenCvSharp.CameraScenePassthrough passthrough;

   [SerializeField]
   public ARCameraBackground cameraBackground;

   public RawImage debug;

   private void Update() 
   {
    debug.texture = passthrough.camOutput;
    cameraBackground.material.SetTexture("CameraOutput", passthrough.camOutput);
   }
}
