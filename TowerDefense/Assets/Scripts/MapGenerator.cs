using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject castlePlayer;
    public GameObject castleEnemy;
    public GameObject wayPoints;
    public GameObject followPoint;
    public GameObject spawnPoint;
    public GameObject node;
    public GameObject destructNode;

    int nodeMinY = 2;
    int nodeMaxY = 12;

    int nodeMinX = 2;
    int nodeMaxX = 9;

    void Start()
    {   
        Vector3 nodPos = node.transform.position;

        int starterRandPosX = Random.Range(nodeMinX,nodeMaxX);
        int starterRandPosY = Random.Range(nodeMinY,nodeMaxY);

        Vector3 randPos = new Vector3(starterRandPosX * 20, 1, starterRandPosY * 20);

        GameObject insEnemy = Instantiate(castleEnemy, nodPos += randPos,  node.transform.rotation);
        GameObject insSpawn = Instantiate(spawnPoint, insEnemy.transform.position, insEnemy.transform.rotation);
        GameObject insWayPoints = Instantiate(wayPoints, insEnemy.transform.position, insEnemy.transform.rotation);

        int followPointAmount = Random.Range(2,3);

        if(insWayPoints != null)
        {   
            Vector3 auxVec = insSpawn.transform.position;
            int checkSideX = nodeMaxX - starterRandPosX;
            int newPosX = starterRandPosX;
            int auxRandx = 0;
            Vector3 randPosX = new Vector3(0,0,0);

            //Y

            int checkSideY = nodeMaxY - starterRandPosY;
            int newPosY = starterRandPosY;
            int auxRandY = 0;
            Vector3 randPosY = new Vector3(0,0,0);

            for (int i = 0; i < followPointAmount; i++)
            {
                if(newPosX < nodeMaxX/2)
                {
                    auxRandx = Random.Range(newPosX-1, 1);
                    randPosX = new Vector3(auxRandx * -20,0,0);
                }
                else
                {
                    auxRandx = Random.Range(1, checkSideX-1);
                    randPosX = new Vector3(auxRandx *20, 0, 0);
                }
                
                GameObject insFollowPointX = Instantiate(followPoint, auxVec += randPosX, Quaternion.identity, insWayPoints.transform);
                newPosX = nodeMaxX - newPosX;
                auxVec = insFollowPointX.transform.position;

                //Y

                if(newPosY < nodeMaxY/2)
                {
                    auxRandY = Random.Range(newPosY-1, 1);
                    randPosY = new Vector3(0,0,auxRandY * -20);
                }
                else
                {
                    auxRandY = Random.Range(1, checkSideY-1);
                    randPosY = new Vector3(0, 0, auxRandY *20);
                }
                
                GameObject insFollowPointY = Instantiate(followPoint, auxVec += randPosY, Quaternion.identity, insWayPoints.transform);
                newPosY = nodeMaxY - newPosY;
                auxVec = insFollowPointY.transform.position;
            }
            Instantiate(castlePlayer, auxVec, Quaternion.identity);
            GetComponent<WaveSpawner>().spawnPoint = insSpawn.transform;
            Instantiate(destructNode, insSpawn.transform.position, insSpawn.transform.rotation);
        }
    }
    
}
