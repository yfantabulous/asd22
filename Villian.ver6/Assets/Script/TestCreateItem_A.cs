using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISaveLoad
{
    void Save();
    void Load();
}
public class TestCreateItem_A : MonoBehaviour, ISaveLoad
{

    //플레이어가 들고 있게 될 아이템 종류
    
    
    // Start is called before the first frame update
    void Start()
    {
        //로딩...
        //test
        

      
    }
    private void OnEnable()
    {
        //로딩
    }

    void SetPlayerItem()
    {
        ////로딩에서 가져온 파라미터
        //int a = 5;
        //playeritems.Add(objecttype[5]);
        //objecttype[5].SetActive(true);
    }
    public void Save()
    {

    }
    public void Load()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        

    }
    
}
