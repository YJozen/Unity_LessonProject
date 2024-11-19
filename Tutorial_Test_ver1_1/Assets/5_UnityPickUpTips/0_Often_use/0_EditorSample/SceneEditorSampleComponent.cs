using UnityEngine;
using UnityEditor;

public class SceneEditorSampleComponent : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Transform otherTransform = FindObjectOfType<OtherObject>()?.transform;
        if (otherTransform != null)
        {
            Vector3 direction = otherTransform.position - transform.position;
            Handles.Label(transform.position + Vector3.up * 2, $"Distance: {direction.magnitude:F2}");
            Handles.DrawLine(transform.position, otherTransform.position);
        }
    }
}
