using UnityEngine;
using System.Collections.Generic;

public class LinkedListDemo : MonoBehaviour
{
    public GameObject cubePrefab;
    public LineRenderer lineRenderer;
    public Material lineMaterial;
    public float distanceBetweenCubes = 2.0f;

    private CubeNode firstNode;
    private Vector3 lineRendererOffset;
    private const float startOffset = 0.5f;

    [SerializeField] private List<GameObject> instantiatedObjects = new List<GameObject>(); // Inicialize a lista

    private void Start()
    {
        firstNode = null;
        lineRenderer.positionCount = 0;
        lineRenderer.material = lineMaterial;
        lineRendererOffset = new Vector3(startOffset * distanceBetweenCubes, 0, 0);
    }

    private void CreateCubeNode(bool insertAtStart)
    {
        GameObject cube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        CubeNode newNode = cube.GetComponent<CubeNode>();

        if (insertAtStart)
        {
            newNode.nextNode = firstNode;
            firstNode = newNode;
        }
        else
        {
            if (firstNode == null)
            {
                firstNode = newNode;
            }
            else
            {
                CubeNode currentNode = firstNode;
                while (currentNode.nextNode != null)
                {
                    currentNode = currentNode.nextNode;
                }
                currentNode.nextNode = newNode;
            }
        }

        UpdateCubePositions();

        // Adicione o cubo à lista de objetos instanciados
        instantiatedObjects.Add(cube);
    }

    private void UpdateCubePositions()
    {
        CubeNode currentNode = firstNode;
        int nodeCount = 0;

        while (currentNode != null)
        {
            currentNode.transform.position = transform.position + nodeCount * distanceBetweenCubes * Vector3.right;
            nodeCount++;
            currentNode = currentNode.nextNode;
        }

        UpdateLineRenderer(nodeCount);
    }

    private void UpdateLineRenderer(int nodeCount)
    {
        Vector3[] linePositions = new Vector3[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            linePositions[i] = transform.position + i * distanceBetweenCubes * Vector3.right + lineRendererOffset;
        }

        lineRenderer.positionCount = nodeCount;
        lineRenderer.SetPositions(linePositions);
    }



    //private void RemoveFromStart()
    //{
    //    if (firstNode != null)
    //    {
    //        // Obtenha o primeiro objeto instanciado
    //        GameObject firstInstantiatedObject = instantiatedObjects[0];


    //        // Destrua o primeiro objeto
    //        Destroy(firstInstantiatedObject);
    //        if (firstInstantiatedObject != null)
    //        {
    //            Debug.Log("first object is not null");
    //            firstInstantiatedObject = instantiatedObjects[0];
    //            Destroy(firstInstantiatedObject.gameObject);

    //            // instantiatedObjects.RemoveAt(0);
    //        }

    //        firstNode = firstNode.nextNode;
    //        UpdateCubePositions();
    //        // Remova o primeiro objeto da lista
    //        instantiatedObjects.RemoveAt(0);
    //        // Chame CheckList para atualizar a lista
    //        CheckList();
    //    }
    //}
    private void RemoveFromStart()
    {

        Destroy(instantiatedObjects[0].gameObject);
        instantiatedObjects.RemoveAt(0);
        UpdateCubePositions();

        // Chame CheckList para atualizar a lista
        CheckList();

    }
    private void CheckList()
    {
        // Obtenha todos os objetos da cena com o componente CubeNode
        CubeNode[] sceneObjects = FindObjectsOfType<CubeNode>();

        // Atualize o tamanho da lista para corresponder ao número de objetos na cena
        instantiatedObjects.Capacity = sceneObjects.Length;
    }


    private void RemoveFromEnd()
    {
        if (firstNode != null)
        {
            if (firstNode.nextNode == null)
            {
                // Obtenha o último objeto instanciado
                GameObject lastInstantiatedObject = instantiatedObjects[instantiatedObjects.Count - 1];

                // Remova o último objeto da lista
                instantiatedObjects.RemoveAt(instantiatedObjects.Count - 1);
                // Destrua o último objeto
                Destroy(lastInstantiatedObject);

                firstNode = null;
            }
            else
            {
                CubeNode currentNode = firstNode;
                while (currentNode.nextNode.nextNode != null)
                {
                    currentNode = currentNode.nextNode;
                }
                // Obtenha o último objeto instanciado
                GameObject lastInstantiatedObject = instantiatedObjects[instantiatedObjects.Count - 1];
                // Remova o último objeto da lista
                instantiatedObjects.RemoveAt(instantiatedObjects.Count - 1);
                // Destrua o último objeto
                Destroy(lastInstantiatedObject);

                currentNode.nextNode = null;
            }
            UpdateCubePositions();

            // Chame CheckList para atualizar a lista
            CheckList();
        }
    }

    public void OnAddStartButtonClicked()
    {
        CreateCubeNode(true);
    }

    public void OnAddEndButtonClicked()
    {
        CreateCubeNode(false);
    }

    public void OnRemoveStartButtonClicked()
    {
        RemoveFromStart();
    }

    public void OnRemoveEndButtonClicked()
    {
        RemoveFromEnd();
    }
}
