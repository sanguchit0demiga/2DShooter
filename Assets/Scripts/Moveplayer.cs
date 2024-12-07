using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moveplayer : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maxvida;
    [SerializeField] private Healthbarch barraDeVida;

    private Rigidbody2D rigidBody2D;
    public Vector2 inputVector;
    public float speed = 2f;
    private Animator animator;
    AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {
        vida = maxvida;
        barraDeVida.InicializarBarraDeVida(vida);

        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Die();

        }
    }
    public void GanarVida(float cantidad)
    {
        vida = Mathf.Min(vida + cantidad, maxvida);
        barraDeVida.CambiarVidaActual(vida);
    }

    void Update()
    {
        if (!PauseMenu.GamePaused && Input.GetMouseButtonDown(0)) 
        {
            audioManager.PlaySFX(audioManager.shoot);
        }
        if (PauseMenu.GamePaused) return;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.shoot);

        }
        if (!PauseMenu.GamePaused && Input.GetMouseButtonDown(0)) 
        {
            audioManager.PlaySFX(audioManager.shoot);
        }
    }


    void FixedUpdate()
    {
        if (PauseMenu.GamePaused) return;
        Vector2 movement = inputVector * speed * Time.fixedDeltaTime;
       rigidBody2D.MovePosition(rigidBody2D.position + movement);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            TakeDamage(1f);
            GameController.EnemyKilled();  
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            GanarVida(1f);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            LootBag lootBag = collision.gameObject.GetComponent<LootBag>();
            if (lootBag != null)
            {
                lootBag.CollectCoin(collision.gameObject); 
            }
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");

    }
}

