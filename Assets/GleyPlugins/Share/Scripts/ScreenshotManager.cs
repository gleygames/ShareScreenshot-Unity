namespace GleyShare
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Networking;

    public class ScreenshotManager : MonoBehaviour
    {
        private const string filename = "Screenshot.png";
        private static ScreenshotManager instance;

        public static ScreenshotManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("ScreenshotManager");
                    instance = go.AddComponent<ScreenshotManager>();
                }
                return instance;
            }
        }

        public void CaptureScreenshot()
        {
            ScreenCapture.CaptureScreenshot(filename);
        }

        public void GetScreenshotAsSprite(UnityAction<Sprite> SpriteLoaded)
        {
            StartCoroutine(LoadScreenshot(SpriteLoaded, null));
        }

        public void GetScreenshotAsTexture(UnityAction<Texture2D> TextureLoaded)
        {
            StartCoroutine(LoadScreenshot(null, TextureLoaded));
        }

        public string GetFullPath()
        {
#if UNITY_EDITOR
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 7);
#else
            string path = Application.persistentDataPath;
#endif
            path = path + "/" + filename;
            return path;
        }


        IEnumerator LoadScreenshot(UnityAction<Sprite> SpriteLoaded, UnityAction<Texture2D> TextureLoaded)
        {
            string path = GetFullPath();
            yield return new WaitForSeconds(1);
            UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + path);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error loading screenshot " + www.error);
                if (SpriteLoaded != null)
                {
                    SpriteLoaded.Invoke(null);
                }
                if (TextureLoaded != null)
                {
                    TextureLoaded.Invoke(null);
                }
            }
            else
            {
                Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
                if (TextureLoaded != null)
                {
                    TextureLoaded.Invoke(tex);
                }
                Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
                if (SpriteLoaded != null)
                {
                    SpriteLoaded.Invoke(sprite);
                }
            }
        }
    }
}
