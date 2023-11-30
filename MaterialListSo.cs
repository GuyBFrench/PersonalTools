using UnityEngine;

[CreateAssetMenu(fileName = "MaterialList", menuName = "ScriptableObjects/MaterialList", order = 1)]
public class MaterialListSo : ScriptableObject
{
    public Material[] materials;

    public Material GetRandomMaterial()
    {
        if (materials != null && materials.Length > 0)
        {
            int randomIndex = Random.Range(0, materials.Length);
            return materials[randomIndex];
        }

        Debug.LogWarning("Material list is empty or null.");
        return null;
    }
}
