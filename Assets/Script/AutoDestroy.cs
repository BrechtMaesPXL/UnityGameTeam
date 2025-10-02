using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 1f;
    private Coroutine destroyRoutine;

    void OnEnable()
    {
        destroyRoutine = StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        float timer = 0f;
        while (timer < lifetime)
        {
            if (GameManager.Instance.CurrentState is not PausedState)
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }
        Destroy(gameObject);
    }

    public void CancelAutoDestroy()
    {
        if (destroyRoutine != null)
        {
            StopCoroutine(destroyRoutine);
            destroyRoutine = null;
        }
    }
}
