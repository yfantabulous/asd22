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

    //�÷��̾ ��� �ְ� �� ������ ����
    
    
    // Start is called before the first frame update
    void Start()
    {
        //�ε�...
        //test
        

      
    }
    private void OnEnable()
    {
        //�ε�
    }

    void SetPlayerItem()
    {
        ////�ε����� ������ �Ķ����
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
