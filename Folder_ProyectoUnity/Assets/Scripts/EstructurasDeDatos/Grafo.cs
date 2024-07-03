using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo : MonoBehaviour
{
    public SimplyLinkedList<NodeController> allNode;
    public GameObject nodePrefab;
    GameObject currentNode;
    public NodeController currentNodeControl;
    [SerializeField] Transform parentRefences;

    void Awake(){
        allNode =  new SimplyLinkedList<NodeController>();
        GenerateCamino();
    }
    void Start(){
        Graph();
    }
    void AddNode(float positionx, float positiony, int nodeTag) //O(1) de tiempo asintotico
    {
        currentNode = Instantiate(nodePrefab, transform.position, transform.rotation,parentRefences);
        currentNode.transform.SetParent(transform);
        currentNode.GetComponent<NodeController>().SetInitialValues(positionx, positiony, nodeTag);
        allNode.AddNodeAtStart(currentNode.GetComponent<NodeController>());
    }

    void AddNodeAdjacent(int nodeTag, int[] allAdjacentTags)
    {
        NodeController selectedNode = SearchNode(nodeTag);

        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddNodeAdjacent(SearchNode(allAdjacentTags[i]));
        }
    }
    NodeController SearchNode(int nodeTag)
    {
        int position = 0;
        for (int i = 0; i < allNode.Count; i++)
        {
            if (allNode.GetNodeAtPosition(i).nodeTag == nodeTag)
            {
                position = i;
                break;
            }
        }
        return allNode.GetNodeAtPosition(position);
    }
    public void Graph()
    {
        AddNodeAdjacent(0, new int[] { 1, 6, 7 });
        AddNodeAdjacent(1, new int[] { 2, 3 });
        AddNodeAdjacent(2, new int[] { 4 });
        AddNodeAdjacent(3, new int[] { 4 });
        AddNodeAdjacent(4, new int[] { 5 });
        AddNodeAdjacent(6, new int[] { 4 });
        AddNodeAdjacent(7, new int[] { 4 });
    }
    public void SelectionPath(GameObject enemy) //O(1) de tiempo asintotico
    {
        currentNodeControl = allNode.GetNodeAtPosition(7);
        if (enemy.GetComponent<HerenciaEnemy>())
        {
            enemy.GetComponent<HerenciaEnemy>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
        }else if (enemy.GetComponent<Enemy2>())
        {
            enemy.GetComponent<Enemy2>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
        } else if (enemy.GetComponent<Enemy2>())
        {
            enemy.GetComponent<Enemy3>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
        }

    }
    void GenerateCamino()
    {
        //Camino 
        AddNode(61.44f, -6.29f, 0);
        AddNode(38.87f, -6.29f, 1);
        AddNode(31.1f, -14.8f, 2);
        AddNode(31.1f, 2.84f, 3);
        AddNode(20.7f, -4.57f, 4);
        AddNode(1.67f, -4.36f, 5);
        AddNode(41.24f, -23.26f, 6);
        AddNode(41.24f, 9.48f, 7);
    }
}
