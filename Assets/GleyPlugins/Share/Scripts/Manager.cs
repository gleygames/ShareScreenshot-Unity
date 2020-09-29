namespace GleyShare
{
    public class Manager
    {
        public static void ShareText(string text)
        {
            ShareManager.Instance.ShareText(text);
        }

        public static void SharePicture(string path, string filename)
        {
            ShareManager.Instance.SharePicture(path, filename);
        }
    }
}
