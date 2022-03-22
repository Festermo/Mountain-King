using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private AnimationCurve _heightCurve;

    private bool _spawnedAgain;
    private float _timer;
    private Vector3 _desiredPos;
    private Vector3 _currentPos;

    void FixedUpdate()
    {
        if (_timer >= 1)
        {
            _timer = 0;
            _desiredPos = GenerateRandomPosition();
            _currentPos = transform.position;
        }
        if (_spawnedAgain)
        {
            _timer = 0;
            _spawnedAgain = false;
            _desiredPos = GenerateRandomPosition();
            _currentPos = transform.position;
        }
        _timer += Time.deltaTime;
        Vector3 pos = Vector3.Lerp(_currentPos, _desiredPos, _timer);
        float heightDelta = _heightCurve.Evaluate(_timer) - _heightCurve.Evaluate(_timer - Time.deltaTime);
        pos.y = heightDelta + transform.position.y;
        transform.position = pos;
        transform.Rotate(new Vector3(135, 135, 135) * Time.deltaTime);
    }

    private Vector3 GenerateRandomPosition()
    {
        float desiredZPosition = 0;
        if (transform.position.z <= -3)
        {
            desiredZPosition = transform.position.z + 1;
        }
        else if (transform.position.z >= 3)
        {
            desiredZPosition = transform.position.z - 1;
        }
        else
        {
            int randomNumber = Random.Range(1, 4);
            switch (randomNumber) 
            {
                case 1:
                    desiredZPosition = transform.position.z + 1;
                    break;
                case 2:
                    desiredZPosition = transform.position.z - 1;
                    break;
                case 3:
                    desiredZPosition = transform.position.z;
                    break;
            }
        }
        return new Vector3(transform.position.x - 1, 0, desiredZPosition);
    }

    public void OnObjectSpawn()
    {
        _spawnedAgain = true;
    }
}