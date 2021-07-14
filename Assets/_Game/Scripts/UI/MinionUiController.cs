using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionUiController : MonoBehaviour
{
    [SerializeField] GameObject content = default;

    public GameObject Content => content;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
}
