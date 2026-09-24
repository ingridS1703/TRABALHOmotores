using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text player1CoinText;
    [SerializeField] private TMP_Text player2CoinText;

    [SerializeField] private TMP_Text player1StarText;
    [SerializeField] private TMP_Text player2StarText;

    [SerializeField] private TMP_Text winnerText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinCountChanged += UpdateCoins;
        PlayerObserverManager.OnStarCollected += UpdateStars;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinCountChanged -= UpdateCoins;
        PlayerObserverManager.OnStarCollected -= UpdateStars;
    }

    private void UpdateCoins(ThirdPersonController player, int amount)
    {
        Debug.Log("COIN UI RECEBEU: " + amount);

        if (player == null)
            return;

        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        if (playerInput == null)
            return;

        if (playerInput.defaultActionMap == "Player 1")
        {
            player1CoinText.text = "Jogador 1 - Moedas: " + amount;
        }
        else if (playerInput.defaultActionMap == "Player 2")
        {
            player2CoinText.text = "Jogador 2 - Moedas: " + amount;
        }
    }

    private void UpdateStars(ThirdPersonController player)
    {
        if (player == null)
            return;

        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        if (playerInput == null)
            return;

        if (playerInput.defaultActionMap == "Player 1")
        {
            player1StarText.text = "Jogador 1 - Estrelas: " + player.StarCount;
        }
        else if (playerInput.defaultActionMap == "Player 2")
        {
            player2StarText.text = "Jogador 2 - Estrelas: " + player.StarCount;
        }
    }
}