using UnityEngine;

public class ColorDetection : MonoBehaviour
{
    public Texture2D texture;
    public string deka;
    // Start is called before the first frame update
    void Update()
    {
        print("TOuch COunt:" + Input.touchCount);
    }




    /*if (Input.GetMouseButton(0))
       {
           ScreenCapture.CaptureScreenshot("MyScreenShot.png");
           Debug.Log("ScreenShot Taken");
       }
       // print (Input.mousePosition);
   }

   void moonrake()
   {
       mpos = Input.mousePosition;
       var ray = Camera.main.ScreenPointToRay(mpos);
       var cube : GameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
       cube.transform.localScale = Vector3(20, 20, 1);
       cube.transform.position = Vector3(0, 0.5, 0);
       cube.transform.LookAt(camera.main.transform, Vector3.up);
       Destroy(cube.renderer.material);
       sshot();

   }

   void sshot()
   {
       var tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
       yield WaitForEndOfFrame();
       tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
       tex.Apply();

       var bla = tex.GetPixel(mpos.x, mpos.y);
       print(bla);


       //Destroy (tex);

       //return tex;
  */
}
