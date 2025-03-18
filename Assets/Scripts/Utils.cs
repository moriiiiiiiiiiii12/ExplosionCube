using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Color GenerateRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
