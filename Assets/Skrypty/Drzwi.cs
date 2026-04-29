using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string requiredKeyName; // np. "klucz zielony"
    public Animator animator; // Animator drzwi
    public Transform keyIconSlot; // Slot na ikonê (jeœli chcesz np. pokazaæ klucz nad drzwiami)

    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen) return;

        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

        if (inventory != null && inventory.HasKey(requiredKeyName))
        {
            OpenDoor();
            inventory.UseKey(requiredKeyName); // Klucz znika
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            // Ewentualnie: zniszczyæ obiekt drzwi jeœli nie ma animacji
            Destroy(gameObject);
        }
    }
}
