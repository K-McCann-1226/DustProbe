using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    public TileData data;

    void Start()
    {
        if (data != null)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = data.sprite;

            // Optional: set minimap color or walkability visuals here later
        }
    }
}

