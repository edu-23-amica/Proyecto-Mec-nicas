using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    [Header("Config TP")]
    public Transform[] teleportPoints;
    public float teleportCooldown = 5f;
    private float teleportTimer;

    [Header("Config general ataque(disparo)")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    [Header("Config Raycast")]
    public Transform rayOrigin;
    public float rayDistance = 20f;
    public float raycastAttackCooldown = 4f;
    private float raycastTimer = 0f;

    [Header("Config disparo")]
    public float randomShotIntervalMin = 2f;
    public float randomShotIntervalMax = 5f;
    private float randomShotTimer;

    [Header("Animator")]
    public Animator animator;

    private Transform player;
    private Vector2 storedShootDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        teleportTimer = teleportCooldown;
        ResetRandomShotTimer();
    }

    void Update()
    {
        teleportTimer -= Time.deltaTime;
        raycastTimer -= Time.deltaTime;
        if (teleportTimer <= 0f)
        {
            animator.SetTrigger("teleport");
            teleportTimer = teleportCooldown;
        }

        if (player != null)
        {
            Vector2 direction = (player.position - rayOrigin.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, direction, rayDistance);

            if (hit.collider != null && hit.collider.CompareTag("Player") && raycastTimer <= 0f)
            {
                storedShootDirection = direction;
                animator.SetTrigger("attack");
                raycastTimer = raycastAttackCooldown;
            }
        }

        randomShotTimer -= Time.deltaTime;
        if (randomShotTimer <= 0f)
        {
            storedShootDirection = firePoint.right;
            animator.SetTrigger("attack");
            ResetRandomShotTimer();
        }

    }

    public void DoTeleport()
    {
        if (teleportPoints.Length == 0) return;
        int randomIndex = Random.Range(0, teleportPoints.Length);
        transform.position = teleportPoints[randomIndex].position;
        transform.rotation = teleportPoints[randomIndex].rotation;
    }

    public void DoShoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = storedShootDirection.normalized * projectileSpeed;
            }
        }
    }

    void ResetRandomShotTimer()
    {
        randomShotTimer = Random.Range(randomShotIntervalMin, randomShotIntervalMax);
    }

}

