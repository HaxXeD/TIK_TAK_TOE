using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMPro.TMP_Text gameOverTxt;

    void Start(){
        GameEvents.current.OnGameOver += GameOver;
    }

    private void GameOver(string winner)
    {
        gameOverScreen.SetActive(true);
        gameOverTxt.text = winner;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
