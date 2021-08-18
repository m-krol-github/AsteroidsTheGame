using System.Collections;
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
        public bool shootConst;
        public float timeOfShootConst = 10;

        [SerializeField]
        private Laser laser;

        [Header("PowerUps"), SerializeField]
        private GameObject shield;
        

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

            shootConst = false;

            Values.GameValues.playerSpawned = true;
        }

        public void AssignEvents()
        {

        }


        public void UpdatePlayerShip()
        {
            RigidFollow();

            if (!shootConst)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlayerShooting();
                    onPlayerShoot.Invoke();
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    PlayerShooting();
                    onPlayerShoot.Invoke();
                }
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

        public void GotHeathPowerUp()
        {
            playerManager.playerHP++;    
        }
        public void GotShootPowerUp()
        {
            StartCoroutine(ShootConstant(timeOfShootConst));
        }

        private IEnumerator ShootConstant(float t)
        {
            shootConst = true;
            yield return new WaitForSeconds(t);
            shootConst = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "PowerUP")
                other.gameObject.GetComponent<IDestroyable>().DestroyMe();

            if(other.gameObject.tag == "PowerUP")
            {
                var type = other.gameObject.GetComponent<PowerUp>().powerUpType;
                if(type == 1)
                {
                    core.Events.MainEvents.HealthPickUP();
                    GotHeathPowerUp();
                }
                if(type == 2)
                {
                    core.Events.MainEvents.ShootPickUp();
                    GotShootPowerUp();
                }
                Destroy(other.gameObject);
            }
        }
    }
}