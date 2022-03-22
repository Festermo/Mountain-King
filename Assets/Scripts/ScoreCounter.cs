using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    private int _score;
    public int score => _score;

    private int _maxScore;
    
    private void Awake()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore");
    }

    private void FixedUpdate()
    {
        if (_score > _maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", _score);
            _maxScore = _score;
        }
        _scoreText.text = _score.ToString();
    }

    public void IncreaseScore()
    {
        _score++;
    }
}