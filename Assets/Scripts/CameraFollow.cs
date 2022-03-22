using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float smoothSpeed = 0.125f;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private Transform _target;
    
    private void FixedUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}