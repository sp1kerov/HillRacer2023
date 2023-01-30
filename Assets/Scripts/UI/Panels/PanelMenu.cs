using UnityEngine;

public class PanelMenu : Panel
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}