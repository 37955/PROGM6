using UnityEngine;

public class Elf : Unit, IMovable, IDamagable
{
    private MeshRenderer objectRenderer;

    new void Start()
    {
        base.Start();

        health = 3;
        speed = 5f;
        range = 80f;
        objectRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        if (health > 0)
        {
            Move();
        }
    }
    private System.Collections.IEnumerator ToggleVisibility()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(3f);
            objectRenderer.enabled = false;
            yield return new WaitForSeconds(0.5f);
            objectRenderer.enabled = true;
        }
    }
}