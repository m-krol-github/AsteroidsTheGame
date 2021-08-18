﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.Events;
using Utils;
using Asteroids;

namespace Player
{
    public class PlayerShip : MonoBehaviour
    {

        [Header("Move Properities")]
        public float speed;
        public float rotationSpeed;
        public float rotationOffset;

        [SerializeField]
        private Rigidbody2D rb;

        [Header("Shooting"), SerializeField]
        private Transform shootPoint;
        public float shootSpeed;

        [SerializeField]
        private Laser laser;

        private Vector2 position = new Vector2(0f, 0f);
        private Vector3 mousePosition;
                
        private CoreManager core;
        private PlayerManager playerManager;
        private GameManager gameManager;

        private UnityAction onPlayerShoot;

        public void InitPlayers(CoreManager core, UnityAction PlayerShootCallback)
        {
            this.core = core;
            this.gameManager = core.GameManager;
            this.playerManager = core.Player;

            //gameManager.playerShip = this;

            this.onPlayerShoot = PlayerShootCallback;

            Values.GameValues.playerSpawned = true;

            Debug.Log("Pinit");
        }

        public void UpdatePlayerShip()
        {
            RigidFollow();

            if (Input.GetMouseButtonDown(0))
            {
                PlayerShooting();
                onPlayerShoot.Invoke();
            }
        }

        private void RigidFollow()
        {
            mousePosition = Input.mousePosition;            
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            position = Vector2.Lerp(transform.position, mousePosition, speed);
            //
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 shipPos = Camera.main.WorldToScreenPoint(transform.position);
            //
            mousePos.x = mousePos.x - shipPos.x;
            mousePos.y = mousePos.y - shipPos.y;
            //
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        }

        private void FixedUpdate()
        {
            rb.MovePosition(position);
        }

        private void PlayerShooting()
        {
            GameObject temp = Instantiate(laser.gameObject, shootPoint.position, shootPoint.rotation);
            temp.transform.localPosition = shootPoint.transform.position;
            temp.transform.parent = gameManager.spawnsHolder.transform;
            temp.gameObject.GetComponent<Laser>().InitLaser();
            temp.GetComponent<Rigidbody2D>().AddForce(this.transform.up * this.shootSpeed);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<IDestroyable>().DestroyMe();
        }
    }
}