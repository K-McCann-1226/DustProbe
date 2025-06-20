using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour
{
    public bool isSelected = false;
    public GameObject selectionIndicator; // e.g., a glowing ring under the unit

    void Start()
    {
        Deselect();
    }

    public void Select()
    {
        isSelected = true;
        if (selectionIndicator != null) selectionIndicator.SetActive(true);
    }

    public void Deselect()
    {
        isSelected = false;
        if (selectionIndicator != null) selectionIndicator.SetActive(false);
    }
}
