using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu, StructureChoice, MenuStack, MenuQueue, MenuLinkedList;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        StructureChoice.SetActive(false);
        MenuStack.SetActive(false);
        MenuQueue.SetActive(false);
        MenuLinkedList.SetActive(false);
    }

    public void ApplicationQuit()
    {
        Debug.Log("Leaving, please wait...");
        Application.Quit();
    }
}
