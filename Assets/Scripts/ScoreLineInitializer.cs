using System.Collections.Generic;
using UnityEngine;

public class ScoreLineInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreLinePrefab;

    [SerializeField]
    private GameObject _scrollRect;

    [SerializeField]
    private LeaderboardSorter leaderboardSorter;

    private List<ScoreLine> _scoreLines;

    public List<ScoreLine> scoreLines => _scoreLines;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Initializer");
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        _scoreLines = new List<ScoreLine>();
    }

    private void OnLevelWasLoaded(int level)
    {
        leaderboardSorter = FindObjectOfType<LeaderboardSorter>(); //because of dontdestroyonload
    }

    public void InitNewScoreLine(string nickname)
    {
        GameObject newScoreLine = Instantiate(_scoreLinePrefab);
        _scoreLines.Add(newScoreLine.GetComponent<ScoreLine>());
        ScoreLine scoreLineContent = newScoreLine.GetComponent<ScoreLine>();
        Transform scrollRectContent = _scrollRect.transform.GetChild(0).transform;
        newScoreLine.transform.SetParent(scrollRectContent, false); //to add it to scrollrect
        scoreLineContent.SetNickname(nickname);
        scoreLineContent.SetScore(PlayerPrefs.GetInt("MaxScore").ToString());
        leaderboardSorter.SortScores();
    }
}