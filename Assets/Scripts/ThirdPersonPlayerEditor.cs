using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(PlayerController))]
public class ThirdPersonPlayerEditor : Editor
{
    // set variables
    SerializedProperty crouchSpeed, walkSpeed, runSpeed;
    SerializedProperty jumpHeight, crouchHeight, standHeight;
    SerializedProperty acceleration, gravity;


    private void OnEnable()
    {
        // connecting properties
        crouchSpeed = serializedObject.FindProperty("crouchSpeed");
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        runSpeed = serializedObject.FindProperty("runSpeed");
        jumpHeight = serializedObject.FindProperty("jumpHeight");
        crouchHeight = serializedObject.FindProperty("crouchHeight");
        standHeight = serializedObject.FindProperty("standHeight");
        gravity = serializedObject.FindProperty("gravity");
        acceleration = serializedObject.FindProperty("acceleration");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // make editor gui for floats of the player character
        EditorGUILayout.FloatField("Crouch Speed", crouchSpeed.floatValue);
        EditorGUILayout.FloatField("Walk Speed", walkSpeed.floatValue);
        EditorGUILayout.FloatField("Run Speed", runSpeed.floatValue);
        EditorGUILayout.FloatField("Jump Height", jumpHeight.floatValue);
        EditorGUILayout.FloatField("Crouch Height", crouchHeight.floatValue);
        EditorGUILayout.FloatField("Stand Height", standHeight.floatValue);
        EditorGUILayout.FloatField("Gravity", gravity.floatValue);
        EditorGUILayout.FloatField("Acceleration", acceleration.floatValue);

        serializedObject.ApplyModifiedProperties();
    }
}
