using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public static MenuStart instance;
    public GameObject choice;
    public GameObject menu;
    private bool isInfinite = false;
    public Animator animator;
    public Animator drone;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(stop());
        
    }
    private IEnumerator stop()
    {
        yield return null;
        Score.instance.gameObject.SetActive(false);
        PorteMonnaie.instance.gameObject.SetActive(false);
        Shop.instance.gameObject.SetActive(false);
        InventaireCanvas.instance.transform.parent.gameObject.SetActive(false);
        DroneInteraction.instance.enabled = false;
        DroneMovement.instance.enabled = false;
        MenuGame.Instance.enabled = false;
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

    public void Infinite(bool isInfinite)
    {
        this.isInfinite = isInfinite;
    }

    public void StartGame(bool isInfinite)
    {
        this.isInfinite = isInfinite;
        menu.SetActive(false);
        animator.SetTrigger("Start");
        drone.SetTrigger("Start");
        
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

    public void finishAnimation()
    {
        Score.instance.gameObject.SetActive(true);
        PorteMonnaie.instance.gameObject.SetActive(true);
        Shop.instance.gameObject.SetActive(true);
        InventaireCanvas.instance.transform.parent.gameObject.SetActive(true);
        DroneInteraction.instance.enabled = true;
        DroneMovement.instance.enabled = true;
        MenuGame.Instance.enabled = true;
        drone.enabled = false;
        animator.enabled = false;
        
    }
}
