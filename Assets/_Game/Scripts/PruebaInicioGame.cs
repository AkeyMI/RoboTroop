using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaInicioGame : MonoBehaviour
{
    [SerializeField] MinionData startMinionData = default;
    [SerializeField] GameObject uiMinionChange = default;

    public GameObject UiMinionChange => uiMinionChange;

    private void Start()
    {
        PoolManager.Instance.CreateMinion(startMinionData.minionPrefab, startMinionData.buttonPrefab, startMinionData.minionName);
    }
}
