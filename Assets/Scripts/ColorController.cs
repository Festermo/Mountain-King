using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private Color[] _colors;

    private void Awake()
    {
        Color randomColor = _colors[Random.Range(0, _colors.Length)];
        GetComponent<Light>().color = randomColor;
        Camera.main.backgroundColor = randomColor;
    }
}