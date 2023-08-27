using UnityEngine;

public class CubeNode : MonoBehaviour
{
    public CubeNode nextNode;

    private void Start()
    {
        nextNode = null;
    }
}
