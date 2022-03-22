using UnityEngine;

public class StairwaySpawner : MonoBehaviour
{
    private int _lastStairIndex;

    private void Start()
    {
        for (int i = -5; i < 30; i++) //spawn first stairs infront of player
        {
            ObjectPooler.Instance.SpawnFromPool("Stair", new Vector3(i, i, 0), Quaternion.identity);
        }
        _lastStairIndex = 30;
    }

    public void SpawnStairs()
    {
        ObjectPooler.Instance.SpawnFromPool("Stair", new Vector3(_lastStairIndex, _lastStairIndex, 0), Quaternion.identity);
        _lastStairIndex++;
    }
}