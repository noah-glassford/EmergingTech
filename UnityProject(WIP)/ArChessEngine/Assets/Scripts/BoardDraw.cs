using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace OpenCvSharp
{
public class BoardDraw : MonoBehaviour
{
    public Texture2D input;
    public RawImage output;

    // Start is called before the first frame update
    void Start()
    {
        bool wasFound = false;
        Point2f[] points;
        Size size = new Size(7,7);

        Mat workingMat = Unity.TextureToMat(input);

        wasFound = Cv2.FindChessboardCorners(workingMat, size, out points, ChessboardFlags.AdaptiveThresh);
        Debug.Log(wasFound);

        Cv2.DrawChessboardCorners(workingMat, size, points,wasFound);

       // Cv2.Circle(workingMat, (int)points[0].X, (int)points[0].Y, 1, Scalar.Aqua, 1 );

        output.texture = Unity.MatToTexture(workingMat);


    }


}
}