using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private ScoreCounter _scoreCounter;

    [SerializeField]
    private float _scoreIncreaseFactor = 0.5f; //increase this to make enemies spawn even faster when score increases

    [SerializeField]
    private float _minSpawnTime = 0.5f;

    [SerializeField]
    private float _maxDefaultSpawnTime = 2.5f;

    private float _timer;
    private float _timeUntilNextSpawn = 0.2f;

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeUntilNextSpawn)
        {
            _timer = 0;
            _timeUntilNextSpawn = GetRandomTime();
            ObjectPooler.Instance.SpawnFromPool("Enemy", GenerateRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        int randomY = Random.Range(7, 12); //not to spawn enemies right in front of our player
        int randomZ = Random.Range(-3, 3);
        float yToSpawn = randomY + (int)_player.transform.position.y + 0.25f; //to spawn them properly on the stair
        return new Vector3(yToSpawn - 0.15f, yToSpawn + 5f, randomZ);
    }

    private float GetRandomTime()
    {
        float randomTime = Random.Range(_minSpawnTime, _maxDefaultSpawnTime - (_scoreCounter.score / 100 * _scoreIncreaseFactor)); //enemies start to spawn faster when score increases
        return randomTime;
    }
}