using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectMinion : MonoBehaviour
{
    [SerializeField] TMP_Text minionName = default;

    private Guid minionId;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeMinion);
    }

    private void ChangeMinion()
    {
        PoolManager.Instance.ChangeMinion(minionId);
    }

    public void SetMinionName(string name)
    {
        minionName.text = name;
    }

    public void SetMinionId(Guid id)
    {
        minionId = id;
    }
}
