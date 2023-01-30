using UnityEngine;

public class PanelPause : Panel 
{
    private void Start()
    {
        Time.timeScale = 0;
    }
}
