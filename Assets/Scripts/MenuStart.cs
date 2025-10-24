using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public static MenuStart instance;
    public GameObject choice;
    private bool isInfinite = false;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        choice.SetActive(false);
        Time.timeScale = 1f;
    }

    public bool IsInfinite()
    {
        return isInfinite;
    }

    public void StartGame(bool isInfinite)
    {
        this.isInfinite = isInfinite;
        DontDestroyOnLoad(this.gameObject);
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void AfficherChoix()
    {
        choice.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
