using UnityEngine;

public class ControleMenu : MonoBehaviour
{
    public void ClicouIniciar()
    {

        GameManager.Instance.LoadScene("GetStarted_Scene");
    }

    public void ClicouSair()
    {
        GameManager.Instance.QuitGame();
    }
}
//*