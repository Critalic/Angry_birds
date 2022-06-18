using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlProgressor : MonoBehaviour
{
    [SerializeField] private string _nextLvlName;
    
    private Monster[] _monsters;
    
    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllKnockedOut())
        { 
            GoToNextLvl();
        }
    }

    private void GoToNextLvl()
    {
        Debug.Log("Go to next level " + _nextLvlName);
        SceneManager.LoadScene(_nextLvlName);
    }

    private bool AllKnockedOut()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf) return false;
        }

        return true;
    }
}
