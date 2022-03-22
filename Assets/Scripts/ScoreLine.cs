using UnityEngine;
using UnityEngine.UI;

public class ScoreLine : MonoBehaviour
{
    [SerializeField]
    private Text _nickname;

    public Text nickname => _nickname;

    [SerializeField]
    private Text _score;

    public Text score => _score;

    [SerializeField]
    private Text _place;

    public Text place => _place;

    public void SetNickname(string value)
    {
        _nickname.text = value;
    }

    public void SetScore(string value)
    {
        _score.text = value;
    }

    public void SetPlace(string value)
    {
        _place.text = value;
    }
}