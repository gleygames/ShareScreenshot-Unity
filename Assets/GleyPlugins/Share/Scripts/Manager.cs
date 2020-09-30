namespace GleyShare
{
    using UnityEngine;
    using UnityEngine.Events;
    public class Manager
    {
        public static void ShareText(string text)
        {
            ShareManager.Instance.ShareText(text);
        }

        public static void SharePicture()
        {
            ShareManager.Instance.SharePicture(ScreenshotManager.Instance.GetFullPath());
        }

        public static void CaptureScreenshot(UnityAction<Sprite> SpriteLoaded)
        {
            ScreenshotManager.Instance.CaptureScreenshot();
            ScreenshotManager.Instance.GetScreenshotAsSprite(SpriteLoaded);
        }
    }
}
