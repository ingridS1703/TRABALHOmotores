using TMPro;
using UnityEngine;
using StarterAssets;

public class WinnerManager : MonoBehaviour
{
    public static WinnerManager Instance;

    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        PlayerObserverManager.OnAllStarsCollected += ShowWinner;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnAllStarsCollected -= ShowWinner;
    }

    public void ShowWinner()
    {
        ThirdPersonController[] players =
            FindObjectsByType<ThirdPersonController>(FindObjectsSortMode.None);

        int player1 = 0;
        int player2 = 0;

        foreach (ThirdPersonController player in players)
        {
            if (player.transform.parent.name == "PlayerRobot (1)")
            {
                player1 = player.StarCount;
            }
            else if (player.transform.parent.name == "PlayerRobot (2)")
            {
                player2 = player.StarCount;
            }
        }

        winnerPanel.SetActive(true);

        if (player1 > player2)
        {
            winnerText.text = "PLAYER 1 VENCEDOR!";
        }
        else if (player2 > player1)
        {
            winnerText.text = "PLAYER 2 VENCEDOR!";
        }
        else
        {
            winnerText.text = "EMPATE!";
        }

        Time.timeScale = 0f;
    }
}