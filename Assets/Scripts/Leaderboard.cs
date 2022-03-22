using UnityEngine;

public class Leaderboard : MonoBehaviour, IWindow
{
    #region Singleton

    public static Leaderboard Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject.transform.root);
        }
        else
        {
            Destroy(gameObject.transform.root.gameObject);
        }
        gameObject.SetActive(false);
    }

    #endregion

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}