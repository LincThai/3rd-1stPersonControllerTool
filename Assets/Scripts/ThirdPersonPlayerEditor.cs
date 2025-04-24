using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(PlayerController))]
public class ThirdPersonPlayerEditor : Editor
{
    // set variables
    SerializedProperty crouchSpeed, walkSpeed, runSpeed;
    SerializedProperty jumpHeight, acceleration, gravity;


    private void OnEnable()
    {
        // connecting properties
        crouchSpeed = serializedObject.FindProperty("crouchSpeed");
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        runSpeed = serializedObject.FindProperty("runSpeed");
        jumpHeight = serializedObject.FindProperty("jumpHeight");
        gravity = serializedObject.FindProperty("gravity");
        acceleration = serializedObject.FindProperty("acceleration");

    }

    public override void OnInspectorGUI()
    {

    }
}
