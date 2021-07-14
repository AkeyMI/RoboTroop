using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionIdentifier : MonoBehaviour
{
    public Guid MinionID => minionId;

    private static Guid minionId;

    private void Awake()
    {
        minionId = Guid.NewGuid();

        Debug.Log("Se creo un nuevo ID " + minionId);
    }
}
