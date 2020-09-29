namespace GleyShare
{
    using System;
    using UnityEditor;
    using UnityEngine;
    using GleyEditor;

    public class SettingsWindow : EditorWindow
    {
        const string directive = "UseNativeShare";

        [MenuItem("Window/Gley/Share", false, 100)]
        private static void Init()
        {
            SettingsWindow window = (SettingsWindow)GetWindow(typeof(SettingsWindow));
            window.titleContent = new GUIContent(" Share Settigs ");
            window.minSize = new Vector2(220, 220);
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();

#if UseNativeShare
            if (GUILayout.Button("Disable Share"))
            {
                SetPreprocessorDirective(false);
            }
#else
            if (GUILayout.Button("Enable Share"))
            {
                SetPreprocessorDirective(true);
            }
#endif

            EditorGUILayout.Space();
            if (GUILayout.Button("Download Native Share Plugin"))
            {
                Application.OpenURL("https://assetstore.unity.com/packages/tools/integration/native-share-for-android-ios-112731");
            }
            EditorGUILayout.LabelField("*Native Share is property of Süleyman Yasir Kula, all rights belong to him");

            EditorGUILayout.Space();
            if (GUILayout.Button("Check other Gley plugins"))
            {
                Application.OpenURL("https://assetstore.unity.com/publishers/19336");
            }
        }

        private void SetPreprocessorDirective(bool enable)
        {
            PreprocessorDirective.Set(directive, !enable, BuildTargetGroup.Android);
            PreprocessorDirective.Set(directive, !enable, BuildTargetGroup.iOS);
        }
    }
}
