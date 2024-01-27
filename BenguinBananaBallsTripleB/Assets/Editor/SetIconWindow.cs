#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor.Editor
{
    public class SetIconWindow : EditorWindow
    {
        private const string menuPath = "Assets/Create/Set Icon..";

        private List<Texture2D> icons = null;
        private int selectedIcon = 0;

        [MenuItem(menuPath, priority = 0)]
        public static void ShowMenuItem()
        {
            SetIconWindow window = (SetIconWindow)GetWindow(typeof(SetIconWindow));
            window.titleContent = new("Set Icon");
            window.Show();
        }

        [MenuItem(menuPath, validate = true)]
        public static bool ShowMenuItemValidation()
        {
            return Selection.objects.All(asset => asset.GetType() == typeof(MonoScript));
        }

        private void OnGUI()
        {
            if (icons == null)
            {
                icons = new();
                string[] assetGuids = AssetDatabase.FindAssets("t:texture2d", new[] {"Assets/Gizmos"});

                foreach (string assetGuid in assetGuids)
                {
                    string path = AssetDatabase.GUIDToAssetPath(assetGuid);
                    icons.Add(AssetDatabase.LoadAssetAtPath<Texture2D>(path));
                }
            }

            if (icons == null)
            {
                GUILayout.Label("No icons to display");

                if (GUILayout.Button("Close", GUILayout.Width(100))) Close();
            }
            else
            {
                selectedIcon = GUILayout.SelectionGrid(selectedIcon, icons.ToArray(), 5);

                if (Event.current != null)
                {
                    if (Event.current.isKey)
                    {
                        switch (Event.current.keyCode)
                        {
                            case KeyCode.KeypadEnter:
                            case KeyCode.Return:
                                ApplyIcon(icons[selectedIcon]);
                                Close();
                                break;
                            case KeyCode.Escape:
                                Close();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (Event.current.button == 0 && Event.current.clickCount == 2)
                    {
                        ApplyIcon(icons[selectedIcon]);
                        Close();
                    }
                }

                if (!GUILayout.Button("Apply", GUILayout.Width(100))) return;
                
                ApplyIcon(icons[selectedIcon]);
                Close();
            }
        }

        private void ApplyIcon(Texture2D icon)
        {
            AssetDatabase.StartAssetEditing();
            
            foreach (Object asset in Selection.objects)
            {
                string path = AssetDatabase.GetAssetPath(asset);
                
                MonoImporter importer = AssetImporter.GetAtPath(path) as MonoImporter;

                importer.SetIcon(icon);
                
                AssetDatabase.ImportAsset(path);
            }
            
            AssetDatabase.StopAssetEditing();
            
            AssetDatabase.Refresh();
        }
    }
}
#endif