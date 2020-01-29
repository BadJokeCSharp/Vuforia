using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    private int _clickCount = 0;

    private void OnMouseDown()
    {
        _clickCount++;

        if (_clickCount > 9)
            Destroy(gameObject);
    }
}
