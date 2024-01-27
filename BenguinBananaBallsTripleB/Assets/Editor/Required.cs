using UnityEngine;

namespace Editor.Editor
{
    /// <summary>
    /// A custom property attribute to mark fields in the inspector as "required."
    /// This attribute can be paired with a custom property drawer to visually indicate
    /// fields in the Unity editor that must be populated.
    /// </summary>
    public class Required : PropertyAttribute { }

    /* TODO:
     * 1. Expand the attribute if there's a need for additional metadata or specifications.
     * 2. Consider integrating with other systems or tools for additional checks or behaviour.
     */
}