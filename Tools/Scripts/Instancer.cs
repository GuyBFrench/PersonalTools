using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num = 0;

    public void CreateInstance()
    {
        if (prefab != null)
        {
            Instantiate(prefab);
        }
        else
        {
            Debug.LogWarning("Prefab is null. Unable to instantiate.");
        }
    }

    public void CreateInstance(Vector3Data positionData, Quaternion rotation = default)
    {
        if (prefab != null && positionData != null)
        {
            Instantiate(prefab, positionData.value, rotation);
        }
        else
        {
            Debug.LogWarning("Prefab or position data is null. Unable to instantiate.");
        }
    }

    public void CreateInstanceFromList(Vector3DataList positions, Quaternion rotation = default)
    {
        if (prefab != null && positions != null)
        {
            foreach (var positionData in positions.vector3DList)
            {
                Instantiate(prefab, positionData.value, rotation);
            }
        }
        else
        {
            Debug.LogWarning("Prefab or position list is null. Unable to instantiate.");
        }
    }

    public void CreateInstanceFromListCounting(Vector3DataList positions, Quaternion rotation = default)
    {
        if (prefab != null && positions != null && positions.vector3DList.Count > 0)
        {
            Instantiate(prefab, positions.vector3DList[num].value, rotation);
            num++;
            if (num == positions.vector3DList.Count)
            {
                num = 0;
            }
        }
        else
        {
            Debug.LogWarning("Prefab, position list, or position list count is invalid. Unable to instantiate.");
        }
    }

    public void CreateInstanceListRandomly(Vector3DataList positions, Quaternion rotation = default)
    {
        if (prefab != null && positions != null && positions.vector3DList.Count > 0)
        {
            num = Random.Range(0, positions.vector3DList.Count);
            Instantiate(prefab, positions.vector3DList[num].value, rotation);
        }
        else
        {
            Debug.LogWarning("Prefab, position list, or position list count is invalid. Unable to instantiate randomly.");
        }
    }

    public void CreateRandomPrefabFromList(PrefabListSo prefabList, Vector3Data positionData, Quaternion rotation = default)
    {
        if (prefabList != null && prefabList.Prefabs.Length > 0 && positionData != null)
        {
            int randomIndex = Random.Range(0, prefabList.Prefabs.Length);
            GameObject randomPrefab = prefabList.Prefabs[randomIndex];
            
            if (randomPrefab != null)
            {
                Instantiate(randomPrefab, positionData.value, rotation);
            }
            else
            {
                Debug.LogWarning("Random prefab is null. Unable to instantiate.");
            }
        }
        else
        {
            Debug.LogWarning("Prefab list, prefab count, or position data is invalid. Unable to instantiate random prefab from the list.");
        }
    }
}
