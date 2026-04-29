using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform keyIconSlot;
    public GameObject keyIconPrefab;

    private string heldKeyName; // Przechowuje nazwê klucza
    private GameObject heldKeyIcon; // Ikona klucza nad graczem

    // Zbieranie klucza
    public void CollectKey(Sprite keySprite, string keyName)
    {
        Debug.Log("Zebrano klucz: " + keyName);

        if (keyIconSlot == null)
        {
            Debug.LogError("Key Icon Slot is not assigned!");
            return;
        }

        if (keyIconPrefab == null)
        {
            Debug.LogError("Key Icon Prefab is not assigned!");
            return;
        }

        // Usuniêcie poprzedniej ikony jeœli istnia³a
        if (heldKeyIcon != null)
        {
            Destroy(heldKeyIcon);
        }

        GameObject icon = Instantiate(keyIconPrefab, keyIconSlot.position, Quaternion.identity);
        icon.transform.SetParent(keyIconSlot);
        heldKeyIcon = icon;

        SpriteRenderer sr = icon.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = keySprite;
        }
        else
        {
            Debug.LogWarning("Prefab ikonki nie ma SpriteRenderer!");
        }

        heldKeyName = keyName;
    }

    // Sprawdzanie czy gracz posiada klucz
    public bool HasKey(string keyName)
    {
        return heldKeyName == keyName;
    }

    // Zu¿ycie klucza
    public void UseKey(string keyName)
    {
        if (heldKeyName == keyName)
        {
            heldKeyName = null;

            if (heldKeyIcon != null)
            {
                Destroy(heldKeyIcon);
            }

            Debug.Log("U¿yto klucza: " + keyName);
        }
    }

    public void ResetInventory()
    {
        heldKeyName = null;

        if (heldKeyIcon != null)
        {
            Destroy(heldKeyIcon);
        }

        Debug.Log("Zresetowano ekwipunek gracza.");
    }
}
