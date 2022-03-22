using UnityEngine;
using UnityEngine.UI;

public class AddPlayerWindow : MonoBehaviour, IWindow
{
    [SerializeField]
    private InputField _nicknameField;

    [SerializeField]
    private Button _addButton;

    [SerializeField]
    private ScoreLineInitializer _ScoreLineInitializer;

    void Update()
    {
        if (!string.IsNullOrEmpty(_nicknameField.text)) //check if something is written in nickname field
            _addButton.interactable = true;
        else
            _addButton.interactable = false;
    }

    private void Awake()
    {
        _ScoreLineInitializer = FindObjectOfType<ScoreLineInitializer>();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _nicknameField.text = "";
    }

    public void AddScoreLine()
    {
        _ScoreLineInitializer.InitNewScoreLine(_nicknameField.text);
        Close();
    }
}