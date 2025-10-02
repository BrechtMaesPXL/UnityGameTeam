using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nozzle : MonoBehaviour
{
    public InputActionReference shootActionReference;
    public InputActionReference relodeActionReference;

    public Bullet bulletPrefab;
    public float smoothness = 2f;
    public float recoil = .2f;

    [Header("Ammo")]
    public GameObject ammunitionBar;
    public int maxAmmunition = 5;
    private int ammunition;
    private Vector3 initialAmmoScale;

    [Header("Audio/Visual")]
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public AudioClip relodeClip;
    private SpriteRenderer spriteRenderer;
    private Vector3 desiredPosition;
    private Color desiredColor;
    public Color flashColor;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ammunition = maxAmmunition;
        desiredPosition = transform.localPosition;
        desiredColor = spriteRenderer.color;

        // Store the original scale of the ammo bar
        if (ammunitionBar != null)
            initialAmmoScale = ammunitionBar.transform.localScale;

        UpdateAmmoUI();
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState is PausedState) return;

        if (shootActionReference.action.WasPressedThisFrame())
        {
            EnemySpawner spawn = FindFirstObjectByType<EnemySpawner>();
            if (spawn.paused)
            {
                spawn.paused = false;
                GameManager.Instance.StartGame();
            }
            else
            {
                Shoot();
            }
        }

        if (relodeActionReference.action.WasPressedThisFrame())
        {
            RelodeAnimation();
            ResetAmmo();
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothness * Time.deltaTime);
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, desiredColor, smoothness * Time.deltaTime);
    }

    private void Shoot()
    {
        if (!AmmunitionCheck()) return;

        var bullet = Instantiate(bulletPrefab);

        transform.localPosition = desiredPosition - Vector3.up * recoil;
        spriteRenderer.color = flashColor;

        bullet.transform.position = transform.position;
        bullet.transform.up = transform.up;

        audioSource.PlayOneShot(audioClips[0]);
    }

    private bool AmmunitionCheck()
    {
        if (ammunition <= 0)
            return false;

        ammunition -= 1;
        UpdateAmmoUI();
        return true;
    }

    private void UpdateAmmoUI()
    {
        if (ammunitionBar == null) return;

        float ratio = (float)ammunition / maxAmmunition;

        // Scale X based on ammo
        Vector3 scale = initialAmmoScale;
        scale.x = initialAmmoScale.x * ratio;
        ammunitionBar.transform.localScale = scale;
    }

    private void ResetAmmo()
    {
        ammunition = maxAmmunition;
        UpdateAmmoUI();
    }
    private void RelodeAnimation()
    {
        audioSource.PlayOneShot(relodeClip);
        StopAllCoroutines();
        StartCoroutine(ReloadJitter());
    }

    private IEnumerator ReloadJitter()
    {
        float duration = 0.3f;
        float elapsed = 0f;
        float angleAmount = 15f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            float angle = Mathf.Sin(t * Mathf.PI * 6f) * angleAmount * (1f - t);
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            yield return null;
        }

        transform.localRotation = Quaternion.identity;
    }
}
