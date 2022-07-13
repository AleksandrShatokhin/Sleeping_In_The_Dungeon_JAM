using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
