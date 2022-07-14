using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private const string winText = "You Win";
    private const string DeathText = "You Dead";

    private void Start()
    {
        if (GameController.GetInstance().GetValue_IsWin())
        {
            text.text = winText;
        }
        else
        {
            text.text = DeathText;
        }
    }

    public void RestartLevel()
    {
        GameController.GetInstance().SwitchAllowedRay(false);
        SceneManager.LoadScene("Level");
    }
}
