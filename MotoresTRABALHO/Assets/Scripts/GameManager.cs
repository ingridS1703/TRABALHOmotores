using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public static GameManager Instance;

    public GameState currentState;
    public PlayerInput playerInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Iniciando);
        LoadScene("Splash");
    }

    public void ChangeState(GameState nextState)
    {
        currentState = nextState;
        Debug.Log("Estado atual: " + currentState);
    }

    public void LoadScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Splash":
                SceneManager.LoadScene(sceneName);
                break;

            case "MenuPrincipal":
                SceneManager.LoadScene(sceneName);
                ChangeState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                SceneManager.LoadScene(sceneName);
                // SceneManager.LoadScene(sceneName, LoadSceneMode.Additive); // Comentado caso use Single
                ChangeState(GameState.Gameplay);
                break;

            default:
                Debug.LogWarning("Cena não reconhecida: " + sceneName);
                break;
        }
    }

    public void LoadMenu()
    {
        LoadScene("MenuPrincipal");
    }

    public void AtivarPlayerInput(PlayerInput playerInput)
    {
        this.playerInput = playerInput;
        Debug.Log("PlayerInput ativado.");
    }

    // Adicionado para resolver o erro do QuitGame no menu
    public void QuitGame()
    {
        Debug.Log("A sair do jogo...");
        Application.Quit();
    }
}