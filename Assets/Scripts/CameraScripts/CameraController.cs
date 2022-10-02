using Settings;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] public Vector2 minPosition;
    [SerializeField] public Vector2 maxPosition;
    
    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            var position = transform.position;
            var positionPlayer = target.position;
            //позиция плеера по двум осям
            Vector3 targetPosition = new Vector3(positionPlayer.x, positionPlayer.y, position.z);
            // ограничивает передвижение по оси х и оси у для камеры внутри диапазона мин макс 
            targetPosition.x =
                Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y =
                Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            //скорость слежения
            position = Vector3.Lerp(position, targetPosition, cameraSettings.Smoothing);
            //сохранить позицию
            transform.position = position;
        }
    }
}