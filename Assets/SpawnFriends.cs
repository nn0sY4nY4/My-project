using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnFriends : MonoBehaviour
{
    [SerializeField] private GameObject _friendPrefab;
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(_friendPrefab, new Vector3(Random.Range(-17f, 17f), 0f,
            Random.Range(-12f, 12f)), Quaternion.identity);
        }
    }
}