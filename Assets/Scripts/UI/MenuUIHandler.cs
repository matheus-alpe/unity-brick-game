using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text bestScoreText;

    private void Awake()
    {
        var data = GameManager.Instance.currentData;
        inputField.text = data.name;
        bestScoreText.text = $"{data.bestScoreName} : {data.bestScore}";
    }

    public void StartGame() => SceneManager.LoadScene(1);

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnInputNameChange(string newName)
    {
        Debug.Log($"OnChangeInputName: {newName}");
        GameManager.Instance.currentData.name = newName;
    }
}