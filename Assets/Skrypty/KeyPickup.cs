using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Sprite keyIcon;
    public string keyName; // Np. "zielony", "czerwony", "z³oty"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectKey(keyIcon, keyName);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("PlayerInventory not found on player!");
            }
        }
    }
}
