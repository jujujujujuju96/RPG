using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3.0f;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    public Transform interactionTransform;

    public virtual void Interact() {

        Debug.Log("Interact with: "+ transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
}
