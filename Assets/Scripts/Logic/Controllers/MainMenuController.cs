using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void GuestLogIn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
