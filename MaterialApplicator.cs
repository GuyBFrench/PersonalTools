using UnityEngine;

public class MaterialApplicator : MonoBehaviour
{
    public MaterialListSo materialList;
    public Renderer objectRenderer; // Reference to the Renderer component of the object you want to apply the material to

    void Start()
    {
        ApplyRandomMaterial();
    }

    void ApplyRandomMaterial()
    {
        if (materialList != null && objectRenderer != null)
        {
            Material randomMaterial = materialList.GetRandomMaterial();

            if (randomMaterial != null)
            {
                objectRenderer.material = randomMaterial;
            }
            else
            {
                Debug.LogWarning("Failed to get a random material from the list.");
            }
        }
        else
        {
            Debug.LogWarning("Material list or object renderer is not assigned.");
        }
    }
}