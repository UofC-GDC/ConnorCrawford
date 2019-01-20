using UnityEngine;

public class Bool
{
    private Bool(){}

    public static bool random()
    {
        return Random.value > 0.5f;
    }
}
