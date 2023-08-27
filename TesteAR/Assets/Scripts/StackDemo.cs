using UnityEngine;
using System.Collections.Generic;
using System;

public class StackDemo : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab do cubo
    public Transform spawnPoint; // Ponto de origem dos cubos
    public float stackOffset = 0.1f; // Espa�amento entre os cubos
    public float cubeMass = 1f; // Massa dos cubos

    private Stack<GameObject> cubeStack = new Stack<GameObject>(); // Pilha de cubos

    public void PushCube()
    {
        GameObject cube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);

        // Configura��o do Rigidbody
        Rigidbody rb = cube.GetComponent<Rigidbody>();
        rb.mass = cubeMass;

        // Ajusta a posi��o vertical para empilhar os cubos
        float yOffset = cubeStack.Count * stackOffset;
        cube.transform.position += new Vector3(0f, yOffset, 0f);

        cubeStack.Push(cube); // Adiciona o cubo � pilha
    }

    public void PopCube()
    {
        if (cubeStack.Count > 0)
        {
            GameObject cube = cubeStack.Pop(); // Remove o cubo do topo da pilha
            Destroy(cube); // Destroi o cubo
        }
        else
        {
            Debug.Log("There are no cubes to pop! :(");
        }
    }
}
