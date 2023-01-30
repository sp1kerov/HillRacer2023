using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    [SerializeField] private float _transitionTime = 0.1f;
    [SerializeField] private Animation _transition;
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private PanelGame _panelGame;
    [SerializeField] private PanelPause _panelPause;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelGameOver _panelGameOver;

    private void Start()
    {
        OffPanels();
        _panelMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGame()
    {
        Time.timeScale = 1;
        StartCoroutine(PanelActivator(_panelGame));
    }

    public void OnPause()
    {
        StartCoroutine(PanelActivator(_panelPause));
    }

    public void WinGame()
    {
        StartCoroutine(PanelActivator(_panelWin));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // рестарт игры
    }

    public void OnGameOver()
    {
        StartCoroutine(PanelActivator(_panelGameOver));        
    }

    private void OffPanels()
    {
        _panelMenu.gameObject.SetActive(false);
        _panelGame.gameObject.SetActive(false);
        _panelPause.gameObject.SetActive(false);
        _panelWin.gameObject.SetActive(false);
        _panelGameOver.gameObject.SetActive(false);
    }

    private IEnumerator PanelActivator(Panel panel)
    {
        _transition.gameObject.SetActive(true);
        yield return new WaitForSeconds(_transitionTime);
        _transition.gameObject.SetActive(false);
        OffPanels();
        panel.gameObject.SetActive(true);
    }
}
