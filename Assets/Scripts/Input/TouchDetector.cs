using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TouchDetector : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D;

    private bool _isTouched;

    public bool IsTouched()
    {
        return _isTouched;
    }
    private void OnMouseDrag()
    {
        _isTouched = true;
    }

    private void OnMouseExit()
    {
        _isTouched = false;
    }

    private void OnMouseUp()
    {
        _isTouched = false;
    }
}
