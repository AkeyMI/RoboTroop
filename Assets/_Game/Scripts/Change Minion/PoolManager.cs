using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Type distanceType = default;
    [SerializeField] Type meleeType = default;

    private Dictionary<Guid, GameObject> minions;
    private Dictionary<Guid, GameObject> minionButton;

    public static PoolManager Instance { get; private set; }

    public Guid CurrentMinion => currentMinion;

    private Guid currentMinion = Guid.NewGuid();

    private MinionUiController minionUi;

    private bool isTheFirstMinion = true;

    private bool minionIsDead = false;

    private int currentMinionsCount = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        minions = new Dictionary<Guid, GameObject>();
        minionButton = new Dictionary<Guid, GameObject>();

        minionUi = FindObjectOfType<MinionUiController>();
    }

    public void ChangeMinion(Guid minionToChange)
    {
        if (minions.ContainsKey(minionToChange))
        {
            if (minionIsDead)
            {
                ChangeMinionForDead(minionToChange);
            }
            else
            {
                minions[currentMinion].SetActive(false);
                minionButton[currentMinion].GetComponent<Button>().interactable = true;
                SetNewMinionInCurrentMinionPlace(minions[minionToChange]);
                minionButton[minionToChange].GetComponent<Button>().interactable = false;

                currentMinion = minionToChange;

                if (minions[currentMinion] != null)
                {
                    Prueba.SetParent(minions[currentMinion].transform);
                }
            }
        }
    }

    public void AddMinionToDictionary(Guid id, GameObject minion)
    {
        if (!minions.ContainsKey(id))
        {
            minions.Add(id, minion);
            Debug.Log("Se creo un nuevo apartado del diccionario");
        }

        if(currentMinion == id)
        {
            Debug.Log("Son iguales" + currentMinion + id);
        }

        if(isTheFirstMinion)
        {
            currentMinion = id;
            Debug.Log("Es el primero " + currentMinion);
        }
    }

    public void AddMinionButtonToDiccionary(Guid id, GameObject button)
    {
        if(!minionButton.ContainsKey(id))
        {
            minionButton.Add(id, button);
        }

        if(id == currentMinion)
        {
            button.GetComponent<Button>().interactable = false;
            Debug.Log("Se desactivo un boton");
        }
        else
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    public void RemoveMinion(Guid id)
    {
        if(minions.ContainsKey(id))
        {
            minions.Remove(id);
        }
    }

    public void RemoveButton(Guid id)
    {
        if(minionButton.ContainsKey(id))
        {
            minionButton.Remove(id);
        }
    }

    public void CreateMinion(GameObject minionPrefab, GameObject buttonPrefab, string name)
    {
        GameObject minion = Instantiate(minionPrefab, FindObjectOfType<PruebaInicioGame>().gameObject.transform.position, Quaternion.identity);

        if (!isTheFirstMinion)
        {
            minion.SetActive(false);
        }
        else
        {
            if (minion != null)
            {
                Prueba.SetParent(minion.transform);
            }
        }

        AddMinionToDictionary(minion.GetComponent<MinionIdentifier>().MinionID, minion);

        isTheFirstMinion = false;

        GameObject buttonParent = minionUi.Content;
        GameObject button = Instantiate(buttonPrefab, buttonParent.transform);

        AddMinionButtonToDiccionary(minion.GetComponent<MinionIdentifier>().MinionID, button);

        button.GetComponent<SelectMinion>().SetMinionName(name);
        button.GetComponent<SelectMinion>().SetMinionId(minion.GetComponent<MinionIdentifier>().MinionID);

        currentMinionsCount++;

        Debug.Log(currentMinionsCount);
    }

    private void SetNewMinionInCurrentMinionPlace(GameObject minionChange)
    {
        minionChange.transform.SetPositionAndRotation(minions[currentMinion].transform.position, Quaternion.identity);
        minionChange.SetActive(true);
        Prueba.SetParent(minionChange.transform);
    }

    public void MinionDead()
    {
        minionIsDead = true;

        //int count = minions.Count - 1;

        currentMinionsCount--;

        Debug.Log(currentMinionsCount);

        if(currentMinionsCount <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        }
    }

    private void ChangeMinionForDead(Guid minionToChange)
    {
        SetNewMinionInCurrentMinionPlace(minions[minionToChange]);
        Destroy(minionButton[currentMinion].gameObject);
        Destroy(minions[currentMinion].gameObject);
        minionButton[minionToChange].GetComponent<Button>().interactable = false;

        currentMinion = minionToChange;

        minionIsDead = false;
    }

    public void ChangeItem(Item item)
    {
        Type minionType = minions[currentMinion].GetComponent<CharacterController>().Data.type;

        if (minionType.Equals(item.Type))
        {
            if(minionType.Equals(distanceType))
            {
                minions[currentMinion].GetComponent<MinionShootAttack>().ChangeItem(item);
            }
            else if(minionType.Equals(meleeType))
            {

            }
        }
    }
}
