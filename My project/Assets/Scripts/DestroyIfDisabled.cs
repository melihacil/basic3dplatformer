using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDisabled : MonoBehaviour
{
    public bool SelfDestructEnabled { get; set; } = false;

    private void OnDisable()
    {
        if (SelfDestructEnabled)
            Destroy(gameObject);
    }
}