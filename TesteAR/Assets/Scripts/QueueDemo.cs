using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueueDemo : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab do cubo
    public Transform spawnPoint; // Ponto de origem para instanciar cubos
    public float spacing = 1.0f; // Espaçamento entre cubos

    private Queue<GameObject> cubeQueue = new Queue<GameObject>(); // Fila de cubos

    // Função chamada pelo botão "Push" da interface
    public void PushCube()
    {
        GameObject newCube = Instantiate(cubePrefab, spawnPoint.position + Vector3.right * spacing * cubeQueue.Count, Quaternion.identity);
        cubeQueue.Enqueue(newCube);
    }

    // Função chamada pelo botão "Pop" da interface
    public void PopCube()
    {
        if (cubeQueue.Count > 0)
        {
            GameObject poppedCube = cubeQueue.Dequeue();
            Destroy(poppedCube);
        }
    }
}
