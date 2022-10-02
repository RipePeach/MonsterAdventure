using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "Configs/CameraSettings", order = 0)]
    public class CameraSettings : ScriptableObject
    {
        [SerializeField] private float smoothing;
        [SerializeField] private Vector2 cameraChangePosition;
        public float Smoothing => smoothing;
        public Vector2 CameraChangePosition => cameraChangePosition;
    }
}