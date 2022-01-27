using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAspect : MonoBehaviour
{
    [SerializeField] float aspectWidth;
    [SerializeField] float aspectHeight;

    [SerializeField] Canvas canvas;

    float targetAspect;

    // Start is called before the first frame update
    void Start()
    {
        // set the desired aspect ratio
        targetAspect = aspectWidth / aspectHeight;

        // determine the game window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleHeight = windowAspect / targetAspect;

        // obtain camera component to modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleHeight < 1.0f)
        {
            canvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0f;

            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else // add pillarbox
        {
            canvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1f;

            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
