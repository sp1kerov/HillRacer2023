using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private PanelController _panelController;

    private bool _isFinished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFinished == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                _isFinished = true;
                _panelController.WinGame();
            }
        }
    }
}
