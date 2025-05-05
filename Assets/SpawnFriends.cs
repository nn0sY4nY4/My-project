using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnFriends : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject _friendPrefab;
    void Start()
    {
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < 50; i++)
        {
            Instantiate(_friendPrefab, new Vector3(Random.Range(-40, 40), 0f, Random.Range(-30, 30)), Quaternion.identity);
        }
    }
}