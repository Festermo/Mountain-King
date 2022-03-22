using System.Collections.Generic;

public class ScoreLineSortMethod : IComparer<ScoreLine> //to be able to quicksort list
{
    public int Compare(ScoreLine x, ScoreLine y)
    {
        int.TryParse(x.score.text, out int first);
        int.TryParse(y.score.text, out int second);
        if (first > second)
            return -1;
        else if (first < second)
            return 1;
        else
            return 0;
    }
}