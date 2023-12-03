using System.Collections;
using UnityEngine;

public class HitFeedback : MonoBehaviour
{
    public Material flashMaterial;
    public float flashDuration = 0.2f;
    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = originalMaterial;
    }
}
