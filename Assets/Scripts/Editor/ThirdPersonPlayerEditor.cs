using Unity.Cinemachine;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class ThirdPersonPlayerEditor : Editor
{
    // set variables
    SerializedProperty controller, playerCam;
    SerializedProperty crouchSpeed, walkSpeed, sprintSpeed;
    SerializedProperty jumpHeight, crouchHeight, standHeight;
    SerializedProperty acceleration, gravity;
    SerializedProperty groundMask;
    SerializedProperty camera, cameraRot;

    private void OnEnable()
    {
        // connecting properties
        controller = serializedObject.FindProperty("controller");
        playerCam = serializedObject.FindProperty("cam");
        crouchSpeed = serializedObject.FindProperty("crouchSpeed");
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        sprintSpeed = serializedObject.FindProperty("sprintSpeed");
        jumpHeight = serializedObject.FindProperty("jumpHeight");
        crouchHeight = serializedObject.FindProperty("crouchHeight");
        standHeight = serializedObject.FindProperty("standHeight");
        gravity = serializedObject.FindProperty("gravity");
        acceleration = serializedObject.FindProperty("acceleration");
        groundMask = serializedObject.FindProperty("groundMask");
        camera = serializedObject.FindProperty("cameraRig");
        cameraRot = serializedObject.FindProperty("camRotation");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // references for player functionality
        EditorGUILayout.PropertyField(controller);
        EditorGUILayout.PropertyField(playerCam);
        // make editor gui for floats of the player character
        EditorGUILayout.FloatField("Crouch Speed", crouchSpeed.floatValue);
        EditorGUILayout.FloatField("Walk Speed", walkSpeed.floatValue);
        EditorGUILayout.FloatField("Sprint Speed", sprintSpeed.floatValue);
        EditorGUILayout.FloatField("Jump Height", jumpHeight.floatValue);
        EditorGUILayout.FloatField("Crouch Height", crouchHeight.floatValue);
        EditorGUILayout.FloatField("Stand Height", standHeight.floatValue);
        EditorGUILayout.FloatField("Gravity", gravity.floatValue);
        EditorGUILayout.FloatField("Acceleration", acceleration.floatValue);
        // layer mask for jump
        groundMask.intValue = EditorGUILayout.LayerField("Ground Mask", groundMask.intValue);
        // make Editor GUI for Camera
        EditorGUILayout.PropertyField(camera);
        CinemachineOrbitalFollow cam = camera.objectReferenceValue as CinemachineOrbitalFollow;
        EditorGUILayout.LabelField("Top");
        cam.Orbits.Top.Height = EditorGUILayout.FloatField("Height", cam.Orbits.Top.Height);
        cam.Orbits.Top.Radius = EditorGUILayout.FloatField("Radius", cam.Orbits.Top.Radius);
        EditorGUILayout.LabelField("Center");
        cam.Orbits.Center.Height = EditorGUILayout.FloatField("Height", cam.Orbits.Center.Height);
        cam.Orbits.Center.Radius = EditorGUILayout.FloatField("Radius", cam.Orbits.Center.Radius);
        EditorGUILayout.LabelField("Bottom");
        cam.Orbits.Bottom.Height = EditorGUILayout.FloatField("Height", cam.Orbits.Bottom.Height);
        cam.Orbits.Bottom.Radius = EditorGUILayout.FloatField("Radius", cam.Orbits.Bottom.Radius);
        cam.Orbits.SplineCurvature = EditorGUILayout.Slider(cam.Orbits.SplineCurvature, 0, 1);
        EditorGUILayout.PropertyField(cameraRot);
        CinemachineRotationComposer camView = cameraRot.objectReferenceValue as CinemachineRotationComposer;
        camView.Composition.ScreenPosition = EditorGUILayout.Vector2Field("Screen Position", camView.Composition.ScreenPosition);
        camera.objectReferenceValue = cam;

        serializedObject.ApplyModifiedProperties();
    }
}
