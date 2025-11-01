using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    public InputActionReference inputMenu;
    public static MenuGame Instance;

    public GameObject Menu;
    public GameObject gameover;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        inputMenu.action.performed += ChangeMenuInput;
    }

    private void OnDisable()
    {
        inputMenu.action.performed -= ChangeMenuInput;
    }

    private void ChangeMenuInput(InputAction.CallbackContext callbackContext)
    {
        changeMenu();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RelancerGame()
    {
        changeMenu();
    }

    private void changeMenu()
    {
        if (Menu.activeInHierarchy)
        {
            Menu.SetActive(false);
            MenusManager.instance.RemoveCanvas(Menu);
            Time.timeScale = 1f;
        }
        else
        {
            if (MenusManager.instance.OpenCanvas(Menu))
            {
                Menu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Recommencer()
    {
        SceneManager.LoadScene(0);
    }

    public void AfficherFin()
    {
        MenusManager.instance.CloseCanvasByForce();
        gameover.SetActive(true);
        MenusManager.instance.OpenCanvas(gameover);
        Time.timeScale = 0f;
        
    }

    public void ContinuerInfini()
    {
        gameover.SetActive(false);
        MenusManager.instance.RemoveCanvas(gameover) ;
        MenuStart.instance.Infinite(true);
        Time.timeScale = 1f;
    }
}
