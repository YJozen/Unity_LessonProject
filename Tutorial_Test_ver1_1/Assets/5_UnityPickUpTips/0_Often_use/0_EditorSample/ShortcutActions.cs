#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class ShortcutActions : MonoBehaviour
{
    [MenuItem("Tools/Move to Origin")]
    private static void MoveToOrigin()
    {
        if (Selection.activeTransform != null)
        {
            Selection.activeTransform.position = Vector3.zero;
        }
    }
}
#endif