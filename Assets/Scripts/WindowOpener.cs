using UnityEngine;

public class WindowOpener : MonoBehaviour
{ 
    public void OpenLeaderboard() //we need this because Add Player and Leaderboard is not destroying on load
    {
        Leaderboard.Instance.Open();
    }
}