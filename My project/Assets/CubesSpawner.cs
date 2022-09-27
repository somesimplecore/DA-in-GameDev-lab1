using TMPro;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    public Object CubePrefab;
    public TMP_InputField CubesNum;
    public void SpawnCubes()
    {
        var num = int.Parse(CubesNum.text);
        for (var i = 0; i < num; i++)
            Instantiate(CubePrefab);
    }
}
