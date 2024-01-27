using System.Collections.Generic;
using UnityEngine;

namespace Editor.Editor
{
    [CreateAssetMenu(menuName = "Inspector Notes Data")]
    public class InspectorNotesData : ScriptableObject
    {
        public List<NoteEntry> Notes = new();
    }
}