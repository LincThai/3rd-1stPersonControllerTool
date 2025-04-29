using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class ThirdPersonPlayerEditor : Editor
{
    // set variables
    SerializedProperty crouchSpeed, walkSpeed, sprintSpeed;
    SerializedProperty jumpHeight, crouchHeight, standHeight;
    SerializedProperty acceleration, gravity;


    private void OnEnable()
    {
        // connecting properties
        crouchSpeed = serializedObject.FindProperty("crouchSpeed");
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        sprintSpeed = serializedObject.FindProperty("sprintSpeed");
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
        EditorGUILayout.FloatField("Sprint Speed", sprintSpeed.floatValue);
        EditorGUILayout.FloatField("Jump Height", jumpHeight.floatValue);
        EditorGUILayout.FloatField("Crouch Height", crouchHeight.floatValue);
        EditorGUILayout.FloatField("Stand Height", standHeight.floatValue);
        EditorGUILayout.FloatField("Gravity", gravity.floatValue);
        EditorGUILayout.FloatField("Acceleration", acceleration.floatValue);

        serializedObject.ApplyModifiedProperties();
    }
}
