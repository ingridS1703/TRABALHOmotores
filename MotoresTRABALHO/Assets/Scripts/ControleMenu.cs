using UnityEngine;

public class ConroleMenu : MonoBehaviour
{
    public void ClicouIniciar()
    {
       
        GameManager.Instance.ChangeScene("GetStarted_Scene", GameState.Gameplay);
    }

    public void ClicouSair()
    {
        GameManager.Instance.QuitGame();
    }
}
//*