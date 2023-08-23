using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GunduzDev
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        float health = 1;

        public float moveSpeed = 5f;
        public float jumpForce = 7f;
        public Transform groundCheck;
        public LayerMask groundLayer;

        private Vector2 deathKick = new Vector2(10f, 10f);
        private CapsuleCollider2D capsuleCollider;
        private Rigidbody2D rb;
        private Animator animator;
        public bool isGrounded;

        bool isAlive = true;
        bool isJumpCooldown = false;

        [SerializeField] private Slider slider;
        [SerializeField] private Image rectArea;

        private void OnEnable()
        {
            SignalManager.OnPlayerGetDamage += GetDamage;
            SignalManager.OnPlayerGetHeal += GetHeal;
        }

        private void OnDisable()
        {
            SignalManager.OnPlayerGetDamage -= GetDamage;
            SignalManager.OnPlayerGetHeal -= GetHeal;
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (!isAlive) return;            

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            
            Run();
            Jump();
            Attack();
        }

        public void GetDamage()
        {
            health -= 0.1f;
            slider.value = health;
            if (health < .3f)
            {
                rectArea.color = Color.red;
            }
            if (health <= 0)
            {
                rectArea.color = Color.white;
                StartCoroutine(Deadd());
                print("Dead");
                animator.SetTrigger("Dead");
                //GetComponent<PlayerController>().enabled = false;
                SignalManager.OnPlayerDead?.Invoke();
            }
        }

        void GetHeal()
        {
            health += 0.5f;
            slider.value = health;
            if(health >= .3f)
            {
                rectArea.color = Color.green;
            }
        }

        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("Attack");
                SignalManager.onSFXPlay(AudioTypes.Smash2);
                Vector2 raycastDirection = transform.right;
                Vector2 raycastOrigin = (Vector2)transform.position + raycastDirection * 1;
                RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, 10f);
                if (hit.collider != null)
                {
                    GameObject hitObject = hit.collider.gameObject;
                    Debug.Log("Iþýn " + hitObject.name + " isimli objeye çarptý!");
                    if(hitObject.GetComponent<EnemyController>() != null && hitObject.GetComponent<EnemyController>().enabled)
                    {
                        hitObject.GetComponent<EnemyController>().GetDamage();
                    }
                }
            }
        }

        private void Run()
        {
            float moveDirection = Input.GetAxis("Horizontal");

            if (moveDirection != 0)
            {
                animator.SetBool("Running", true);

                rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

                if (moveDirection > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (moveDirection < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                animator.SetBool("Running", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            //float controlThrow = Input.GetAxis("Horizontal");
            //Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed, rb.velocity.y);
            //rb.velocity = playerVelocity;

            //bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
            //animator.SetBool("Running", playerHasHorizontalSpeed);
        }

        private void Jump()
        {
            if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
            {
                return;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (!isJumpCooldown)
                {
                    StartCoroutine(JumpCooldown());
                    Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
                    rb.velocity += jumpVelocityToAdd;
                }
            }
        }

        private IEnumerator JumpCooldown()
        {
            isJumpCooldown = true;
            yield return new WaitForSeconds(3f);
            isJumpCooldown = false;
        }

        private void Dead()
        {
            SignalManager.onSFXPlay(AudioTypes.Switch);
            rectArea.color = Color.white;
            StartCoroutine(Deadd());
            print("Dead");
            animator.SetTrigger("Dead");
            //GetComponent<PlayerController>().enabled = false;
            SignalManager.OnPlayerDead?.Invoke();
        }

        IEnumerator Deadd()
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.AddListener();
            GameManager.Instance.panel.SetActive(true);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Obstacle"))){
                StartCoroutine(Deadd());
                GameManager.Instance.winPanel.SetActive(true);
                SignalManager.onSFXPlay(AudioTypes.Coin);
            }

            if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
            {
                Dead();
            }
        }
    }
}
