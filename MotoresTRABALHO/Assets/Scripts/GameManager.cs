using UnityEngine;
using UnityEngine.SceneManagement; // Para controlar as cenas
using UnityEngine.InputSystem; // Para controlar o PlayerInput

// 1. O ENUM (Lista de estados)
public enum GameState { Iniciando, MenuPrincipal, Gameplay }

public class GameManager : MonoBehaviour
{
    // 2. O SINGLETON (Acesso global)
    public static GameManager Instance { get; private set; }

    [Header("Configurações de Estado")]
    public GameState currentState;

    private void Awake()
    {
        // Regra do Singleton: se já existir um "eu", me destruo. Se não, eu sou o único.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Não morre ao mudar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Começa o jogo no estado Iniciando
        UpdateState(GameState.Iniciando);
    }

    // 3. MÁQUINA DE ESTADOS SIMPLIFICADA
    public void UpdateState(GameState newState)
    {
        currentState = newState;
        
        // Exibe no Console conforme pedido no trabalho
        Debug.Log($"<color=yellow>GameManager:</color> Estado alterado para <b>{currentState}</b>");
    }

    // 4. CENTRALIZADOR DE CENAS (O único que usa SceneManager)
    public void ChangeScene(string sceneName, GameState nextState)
    {
        // Aqui o GameManager decide se autoriza a mudança
        SceneManager.LoadScene(sceneName);
        UpdateState(nextState);
    }

    // 5. ALOCAÇÃO DE INPUT (Para o PlayerInput do Input System)
    public void AssignPlayerInput(PlayerInput playerInput)
    {
        if (playerInput != null)
        {
            Debug.Log("GameManager: Alocando inputs ao jogador.");
            // Aqui você poderia ativar/desativar mapas de ação se necessário
        }
    }

    public void QuitGame()
    {
        Debug.Log("Fechando o jogo...");
        Application.Quit();
    }
}

