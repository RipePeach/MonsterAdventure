using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using Settings;

public class RoomMove : MonoBehaviour
{
    [SerializeField] private Vector3 characterChange;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private RoomMove anotherSideOfTheDoor;
    public List<GameObject> objectsToDestroy = new List<GameObject>();
    public GameObject[] objectsToCreate;
    public Vector3[] positionsToCreate;

    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private CameraController _cameraController;

    private void Awake()
    {
        if (Camera.main != null) _cameraController = Camera.main.GetComponent<CameraController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterScript>())
        {
            _cameraController.minPosition += cameraSettings.CameraChangePosition;
            _cameraController.maxPosition += cameraSettings.CameraChangePosition;
            other.transform.position += characterChange;
            DestroyObjects(anotherSideOfTheDoor.instantiatedObjects);
            DestroyObjects(objectsToDestroy);
            CreateObjects();
        }
    }

    private void DestroyObjects(List<GameObject> list)
    {
        foreach (var obj in list)
        {
            if (obj == null)
            {
                continue;
            }

            LeanPool.Despawn(obj);
        }
    }

    private void CreateObjects()
    {
        for (int i = 0; i < objectsToCreate.Length; i++)
        {
            GameObject obj = LeanPool.Spawn(objectsToCreate[i], positionsToCreate[i], transform.rotation);
            instantiatedObjects.Add(obj);
        }
    }
}