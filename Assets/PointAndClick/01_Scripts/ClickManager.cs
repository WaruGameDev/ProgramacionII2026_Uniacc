using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    void OnClick();
}

public class ClickManager : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayer; // Assign in Inspector to limit detection

    void Update()
    {
        // Detect mouse click or touch
        if (Input.GetMouseButtonDown(0))
        {
            DetectClick(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            DetectClick(Input.touches[0].position);
        }
    }

    /// <summary>
    /// Converts screen position to world position and checks for a Collider2D hit.
    /// </summary>
    private void DetectClick(Vector2 screenPosition)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPosition);

        // Raycast at the clicked position
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 0f, clickableLayer);

        if (hit.collider != null)
        {
            Debug.Log("Clicked on: " + hit.collider.name);
            // Check if the hit object has a component that implements IClickable

            List<IClickable> clickables = new List<IClickable>(hit.collider.GetComponents<IClickable>());

            foreach (var clickable in clickables)
            {
                clickable.OnClick();
            }

            // Example: Destroy the clicked object
            // Destroy(hit.collider.gameObject);
        }
    }
}
