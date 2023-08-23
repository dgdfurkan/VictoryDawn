using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GunduzDev
{
    public class EnemyController : MonoBehaviour
    {
        float health = 1;

        public float moveSpeed = 2f;
        public float patrolDistance = 5f;
        public float detectionRange = 5f;
        public float shootingCooldown = 1f;
        public Transform player;
        public Transform firePoint;

        private Animator animator;

        private bool isPlayerDetected = false;
        private Vector3 initialPosition;
        private bool isCooldownActive = false;
        private int moveDirection = 1;

        [SerializeField] private Slider slider;
        [SerializeField] private Image rectArea;

        bool isPlayerDead = false;

        private void OnEnable()
        {
            SignalManager.OnPlayerDead += () => { player = null; };
        }

        private void OnDisable()
        {
            SignalManager.OnPlayerDead -= () => { player = null; };
        }

        private void Awake()
        {
            initialPosition = transform.position;
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (player is null)
            {
                animator.SetTrigger("Reload");
                return;
            }

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                isPlayerDetected = true;
                RotateAndShoot();
            }
            else
            {
                isPlayerDetected = false;
                Patrol();
            }
        }

        public void GetDamage()
        {
            health -= 0.2f;
            slider.value = health;
            if (health < .4f)
            {
                rectArea.color = Color.red;
            }
            if (health <= 0)
            {
                rectArea.color = Color.white;
                print("Dead");
                animator.SetTrigger("Dead");
                Destroy(gameObject, 1.2f);
                GetComponent<EnemyController>().enabled = false;
                SignalManager.OnPlayerGetHeal?.Invoke();
            }
        }

        private void RotateAndShoot()
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            firePoint.rotation = targetRotation;

            if(directionToPlayer.x  < 0)
            {
                print("player solda");

                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
            }
            else
            {
                print("player saðda");

                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
            }

            if (!isCooldownActive)
            {
                Shoot();
                SignalManager.onSFXPlay(AudioTypes.Smash1);
                StartCoroutine(ShootingCooldown());
            }
        }

        private void Shoot()
        {
            animator.SetTrigger("Attack");
            SignalManager.OnPlayerGetDamage?.Invoke();
        }

        private void Patrol()
        {
            animator.SetBool("Running", true);

            float distanceToInitialPosition = Vector3.Distance(transform.position, initialPosition);

            if (distanceToInitialPosition >= patrolDistance)
            {
                moveDirection *= -1;
                Flip();
            }

            transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
        }

        private void Flip()
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private IEnumerator ShootingCooldown()
        {
            isCooldownActive = true;
            yield return new WaitForSeconds(shootingCooldown);
            isCooldownActive = false;
        }
    }
}
