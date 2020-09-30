namespace GleyShare
{
    public class ShareManager 
    {
        private static ShareManager instance;

        public static ShareManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShareManager();
                }
                return instance;
            }
        }

        public void ShareText(string text)
        {
#if UseNativeShare
        NativeShare share = new NativeShare();
        share.SetText(text);
        share.Share();
#endif
        }

        public void SharePicture(string path)
        {
#if UseNativeShare
        NativeShare share = new NativeShare();
        share.AddFile(path);
        share.Share();
#endif
        }
    }
}
