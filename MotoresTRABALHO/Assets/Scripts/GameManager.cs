using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 


public enum GameState { Iniciando, MenuPrincipal, Gameplay }

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get; private set; }

    [Header("Configurações de Estado")]
    public GameState currentState;

    private void Awake()
    {
        
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
   
        ChangeScene("Splash");
    }
    
    
    public void UpdateState(GameState newState)
    {
        currentState = newState;
        
       
        Debug.Log($"<color=yellow>GameManager:</color> Estado alterado para <b>{currentState}</b>");
    }

    
    public void ChangeScene(string sceneName)
    {
        // GameManager decide se autoriza a mudança
        SceneManager.LoadScene(sceneName);
        if (sceneName == "MenuPrincipal")
        {
            UpdateState(GameState.MenuPrincipal);
        }
        else if (sceneName == "GetStarted_Scene")
        {
            
            UpdateState(GameState.Gameplay);
        }
        else if (sceneName == "Splash")
        {
            UpdateState(GameState.Iniciando);

        }

    }
    
    
    public void AssignPlayerInput(PlayerInput playerInput)
    {
        if (playerInput != null)
        {
            Debug.Log("GameManager: Alocando inputs ao jogador.");
           
        }
    }

    public void QuitGame()
    {
        Debug.Log("Fechando o jogo...");
        Application.Quit();
    }
}

