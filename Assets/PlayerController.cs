using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] TextMeshProUGUI forceText;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed,
        _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
    public int health = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            int healthEnemy = enemy._health_enemy;
            enemy.Hit(health);
            health -= healthEnemy;
            forceText.text = health.ToString();
            if (enemy.isAlive() == false)
            {
                Destroy(collision.gameObject);
                forceText.text = health.ToString();
                Time.timeScale = 0;
                WinPanel.SetActive(true);
            }
            else
            {
                forceText.text = health.ToString();
                Time.timeScale = 0;
                LosePanel.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "Friend")
        {
            Friend friend = collision.gameObject.GetComponent<Friend>();
            int healthFriend = friend._health;
            health += healthFriend;
            forceText.text = health.ToString();
            Destroy(collision.gameObject);
        }
    }
}
