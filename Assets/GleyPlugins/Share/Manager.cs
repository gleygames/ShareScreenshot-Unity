namespace GleyShare
{
    public class Manager
    {
        public static void ShareRoom(string text)
        {
#if UseNativeShare
        NativeShare share = new NativeShare();
        share.SetText(text);
        share.Share();
#endif
        }

        public static void SharePicture(string path, string filename)
        {
#if UseNativeShare
        NativeShare share = new NativeShare();
        share.AddFile(path + "/" + filename);
        share.Share();
#endif
        }
    }
}
