namespace GleyShare
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

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

        public void SharePicture(string path, string filename)
        {
#if UseNativeShare
        NativeShare share = new NativeShare();
        share.AddFile(path + "/" + filename);
        share.Share();
#endif
        }
    }
}
