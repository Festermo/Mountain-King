using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRestarter : MonoBehaviour
{
    [SerializeField]
    private Animator _restartAnimator;

    [SerializeField]
    private Text _currentScore;

    [SerializeField]
    private Text _maxScore;

    [SerializeField]
    private ScoreCounter _scoreCounter;

    [SerializeField]
    private float _transitionTime = 1; 

    public void Restart() //to start on click event
    {
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartPanelAppear()
    {
        _restartAnimator.SetTrigger("Appear");
        ChangeTexts();
    }

    private void ChangeTexts()
    {
        _currentScore.text = _scoreCounter.score.ToString();
        _maxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }
}