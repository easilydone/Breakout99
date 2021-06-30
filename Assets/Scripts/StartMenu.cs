using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        ScoreManager.Instance.playerName = PlayerName.text;
    }
}
