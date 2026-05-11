using UnityEngine;

public class ControleMenu : MonoBehaviour
{
    public void ClicouIniciar()
    {

        GameManager.Instance.ChangeScene("GetStarted_Scene");
    }

    public void ClicouSair()
    {
        GameManager.Instance.QuitGame();
    }
}
//*