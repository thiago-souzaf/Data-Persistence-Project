using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score: {DataManager.Instance.bestSocoreName} : {DataManager.Instance.bestScore}";
    }
    public void StartGame()
    {
        DataManager.Instance.SetUserName(inputName.text);
        SceneManager.LoadScene(1);
        
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
