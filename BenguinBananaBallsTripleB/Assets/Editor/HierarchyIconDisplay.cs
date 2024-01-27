#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor.Editor
{
    [InitializeOnLoad]
    public static class HierarchyIconDisplay
    {
        private static bool hierarchyHasFocus = false;
        private static EditorWindow hierarchyEditorWindow;
        
        static HierarchyIconDisplay()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
            EditorApplication.update += OnEditorUpdate;
        }
        
        private static void OnEditorUpdate()
        {
            if (hierarchyEditorWindow == null)
                hierarchyEditorWindow = EditorWindow.GetWindow(Type.GetType("UnityEditor.SceneHierarchyWindow,UnityEditor"));

            hierarchyHasFocus = EditorWindow.focusedWindow != null &&
                                EditorWindow.focusedWindow == hierarchyEditorWindow;
        }

        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (obj == null) return;
            
            Component[] components = obj.GetComponents<Component>();
            if (components == null || components.Length == 0) return;
            
            Component component = components.Length > 1 ? components[1] : components[0];

            Type type = component.GetType();

            GUIContent content = EditorGUIUtility.ObjectContent(component, type);
            content.text = null;
            content.tooltip = type.Name;
            
            if (content.image == null) return;

            bool isSelected = Selection.instanceIDs.Contains(instanceID);
            bool isHovered = selectionRect.Contains(Event.current.mousePosition);

            Color colour = UnityEditorBackgroundColour.Get(isSelected, isHovered, hierarchyHasFocus);
            Rect backgroundRect = selectionRect;
            backgroundRect.width = 18.2f;
            EditorGUI.DrawRect(backgroundRect, colour);
            
            EditorGUI.LabelField(selectionRect, content);
        }
    }
}
#endif