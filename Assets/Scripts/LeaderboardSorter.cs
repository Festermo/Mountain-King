using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSorter : MonoBehaviour
{
    private List<ScoreLine> _scoreLines;

    private ScoreLineInitializer _scoreLineInitializer;

    private void Awake()
    {
        _scoreLineInitializer = FindObjectOfType<ScoreLineInitializer>(); //because of dontdestroyonload
    }

    public void SortScores()
    {
        _scoreLines = _scoreLineInitializer.scoreLines; //to get whole scorelines list
        ScoreLineSortMethod sortMethod = new ScoreLineSortMethod(); //getting sort method
        _scoreLines.Sort(sortMethod);
        for (int i = 0; i < _scoreLines.Count; i++)
        {
            _scoreLines[i].gameObject.transform.SetSiblingIndex(i); //to put it in scrollrect correctly
            _scoreLines[i].place.text = (i + 1).ToString(); //places start from 1, not 0
        }
    }
}