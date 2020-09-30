using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Image pictureHolder;

    void Start()
    {
        ShowPictureHolder(false);
    }

    void ShowPictureHolder(bool visible)
    {
        pictureHolder.gameObject.SetActive(visible);
    }

    public void TakeScreenshot()
    {
        Debug.Log("Screenshot");
        GleyShare.Manager.CaptureScreenshot(ScreenshotCaptured);
    }

    private void ScreenshotCaptured(Sprite sprite)
    {
        if(sprite!=null)
        {
            pictureHolder.sprite = sprite;
            ShowPictureHolder(true);
        }
    }

    public void Cancel()
    {
        ShowPictureHolder(false);
    }

    public void Share()
    {
        GleyShare.Manager.SharePicture();
    }
}
