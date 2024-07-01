using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    SimplyLinkedList<NodeController> allAdjacentesNodes;
    float positionx,positionz;
    public int nodeTag;
    void Awake(){
        allAdjacentesNodes = new SimplyLinkedList<NodeController>();
    }
    public void SetInitialValues(float positionX, float positionY, int nodeTag){
        this.positionx = positionX;
        this.positionz = positionY;
        transform.position = new Vector3(positionx,0.2f,positionz);
        this.nodeTag=nodeTag;
    }
    public void AddNodeAdjacent(NodeController nodo){
        allAdjacentesNodes.AddNodeAtStart(nodo);
    }

    public NodeController SelectNextNode(){
        int nodeSelect = Random.Range(0,allAdjacentesNodes.Count);
        return allAdjacentesNodes.GetNodeAtPosition(nodeSelect);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy" ){
            other.GetComponent<HerenciaEnemy>().ChangeMovePosition(SelectNextNode().gameObject.transform.position);
        }
    }
}
