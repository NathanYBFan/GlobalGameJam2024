#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class InspectorNotes : UnityEditor.Editor
    {
        private const string NoteKeyPrefix = "ComponentNote_";
        private string currentNote = string.Empty;
        private bool showNoteField = false;
        private Vector2 scrollPos;
        private InspectorNotesData notesData;

        private void OnEnable()
        {
            // Load the ScriptableObject
            notesData = AssetDatabase.LoadAssetAtPath<InspectorNotesData>("Assets/Editor/InspectorNotesData.asset");
            if (notesData == null)
            {
                Debug.LogWarning("InspectorNotesData not found!");
                return;
            }

            string noteKey = GetNoteKey((MonoBehaviour)target);
            NoteEntry noteEntry = notesData.Notes.FirstOrDefault(n => n.GetUniqueKey() == noteKey);
            currentNote = noteEntry != null ? noteEntry.Note : string.Empty;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();

            if (notesData == null)
            {
                EditorGUILayout.HelpBox("InspectorNotesData not loaded!", MessageType.Error);
                return;
            }

            if (showNoteField)
            {
                EditorGUILayout.LabelField("Edit Note:");

                GUIStyle textAreaStyle = new(EditorStyles.textArea) { wordWrap = true }; // Ensure word wrapping
                float height = Mathf.Clamp(textAreaStyle.CalcHeight(new(currentNote), EditorGUIUtility.currentViewWidth - 30), 50, 150); // Ensure maximum height

                currentNote = EditorGUILayout.TextArea(currentNote, textAreaStyle, GUILayout.Height(height)); // Apply the height

                if (string.IsNullOrWhiteSpace(currentNote))
                {
                    EditorGUILayout.HelpBox("Note is empty!", MessageType.Warning);
                }

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Save Note"))
                {
                    string noteKey = GetNoteKey((MonoBehaviour)target);
                    NoteEntry noteEntry = notesData.Notes.FirstOrDefault(n => n.GetUniqueKey() == noteKey);
                    if (noteEntry != null)
                    {
                        noteEntry.Note = currentNote;
                    }
                    else
                    {
                        notesData.Notes.Add(new()
                        {
                            GameObjectPath = GetGameObjectPath(((MonoBehaviour)target).gameObject),
                            ComponentType = target.GetType().ToString(),
                            Note = currentNote
                        });
                    }

                    EditorUtility.SetDirty(notesData);
                    AssetDatabase.SaveAssets();
                    showNoteField = false;
                }
                if (GUILayout.Button("Cancel"))
                {
                    currentNote = "";
                    showNoteField = false;
                }
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                if (!string.IsNullOrEmpty(currentNote))
                {
                    EditorGUILayout.LabelField("Notes:");

                    GUIStyle labelStyle = new(EditorStyles.wordWrappedLabel); // Use word wrapped label style
                    float labelHeight = labelStyle.CalcHeight(new(currentNote), EditorGUIUtility.currentViewWidth - 30);

                    float limitedLabelHeight = Mathf.Min(labelHeight, 150);
                    
                    scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(limitedLabelHeight), GUILayout.ExpandHeight(false));
                    EditorGUILayout.LabelField(currentNote, EditorStyles.wordWrappedLabel, GUILayout.ExpandHeight(false));
                    EditorGUILayout.EndScrollView();

                    if (GUILayout.Button("Delete Note"))
                    {
                        string noteKey = GetNoteKey((MonoBehaviour)target);
                        NoteEntry noteEntry = notesData.Notes.FirstOrDefault(n => n.GetUniqueKey() == noteKey);
                        if (noteEntry != null)
                        {
                            notesData.Notes.Remove(noteEntry);
                            EditorUtility.SetDirty(notesData);
                            AssetDatabase.SaveAssets();
                        }

                        currentNote = "";
                    }
                }

                string btnLabel = string.IsNullOrEmpty(currentNote) ? "Add Note" : "Edit Note";
                if (GUILayout.Button(btnLabel))
                {
                    showNoteField = true;
                }
            }
        }

        private string GetNoteKey(MonoBehaviour targetComponent)
        {
            return $"{GetGameObjectPath(targetComponent.gameObject)}_{targetComponent.GetType()}";
        }

        private string GetGameObjectPath(GameObject obj)
        {
            string path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            return path;
        }
    }
}
#endif