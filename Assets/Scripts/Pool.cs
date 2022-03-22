using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField]
    private string _tag;

    public string tag => _tag;

    [SerializeField]
    private GameObject _prefab;

    public GameObject prefab => _prefab;

    [SerializeField]
    private int _size;

    public int size => _size;
}