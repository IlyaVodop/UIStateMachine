using System;
using UnityEngine;

public class UIStateMachine : MonoBehaviour
{
    public static UIStateMachine Instance;
    [SerializeField] private StateAndObjects[] _states;

    #region Singleton

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instance = null;
    }

    #endregion

    public void SetState(string stateName)
    {
        foreach (var state in _states)
        {
            if (state.StateName.Equals(stateName))
            {
                foreach (var gObject in state.ObjectsForThisState)
                {
                    gObject.SetActive(true);
                }
            }
            else
            {
                foreach (var gObject in state.ObjectsForThisState)
                {
                    gObject.SetActive(false);
                }
            }
        }
    }
}

[Serializable]
public class StateAndObjects
{
    public string StateName;
    public GameObject[] ObjectsForThisState;
}