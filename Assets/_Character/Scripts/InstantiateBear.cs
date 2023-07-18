using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBear : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject followCam;
    [SerializeField] GameObject bearFactory;
    public int enemyPoolSize = 10;
    public List<GameObject> enemyObjPool = new List<GameObject>();
    Vector3 respawnPosCenter;
    Vector3 respawnPos;
    Quaternion respawnRot;

    float timeCount;
    [SerializeField] float respawnTime;

    private void Start()
    {
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject bear = Instantiate(bearFactory);
            enemyObjPool.Add(bear);
            bear.SetActive(false);
        }
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > respawnTime)
        {
            if (enemyObjPool.Count > 0)
            {
                GameObject bear = enemyObjPool[0];         
                bear.SetActive(true);
                // 다시 원상태로 돌려야함


                // 생성위치 중심점을 구하고
                respawnPosCenter = new Vector3
                    (player.transform.position.x + Camera.main.transform.forward.x * 40f,
                    0,
                    player.transform.position.z + Camera.main.transform.forward.z * 40f );
                // 중심점 기준 xz 평면의 가로세로 30f정도 정사각형 범위에 랜덤생성
                respawnPos.x = Random.Range(respawnPosCenter.x - 15f, respawnPosCenter.x + 15f);
                respawnPos.z = Random.Range(respawnPosCenter.z - 15f, respawnPosCenter.z + 15f);
                respawnPos = new Vector3(respawnPos.x, 0, respawnPos.z);
                bear.transform.position = respawnPos;
                //플레이어를 향하도록 수정 필요 
/*                respawnRot = Quaternion.Euler(followCam.transform.rotation.x,
                                            followCam.transform.rotation.y + 180f,
                                            followCam.transform.rotation.z);*/
                enemyObjPool.RemoveAt(0);
            }
            timeCount = 0;
        }
    }
}
