using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeAttack_A : MonoBehaviour
{
    [SerializeField] float setTime = 60.0f;
    [SerializeField] Text countdewnText;

     //private GameObject Gun;
     //private GameObject Sword;
     //private GameObject Grenade;

    public GameObject ControllerUI;

    public List<GameObject> Weapons = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        
        {
            countdewnText.text = setTime.ToString();
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerUI.activeSelf == false) //// ��Ʈ�� UI�� ������ �ð� ī��Ʈ ����
        {
            setTime -= Time.deltaTime;
            countdewnText.text = Mathf.Round(setTime).ToString();
        }
            
            

        Debug.Log(Weapons.Count);

        if (setTime <= 0) // �ð��� 0�̸� ���Ŵ��� �Լ� ����
        {
            setTime = 0;
           SceneManager_A();
        }
    }

    void SceneManager_A()
    {
        Debug.Log(Weapons.Count);

        
        if (Weapons[0] == null || Weapons[1] == null || Weapons[2] == null)
        {
            Debug.Log("A");
            SceneManager.LoadScene("Test");
        }
        else
        {
            SceneManager.LoadScene("Office");
        }

        // �ð��� 0���̰ų� ���⸦ 1�� �̻� ã���� ��� �Ѿ
        //if(setTime == 0 && Weapons.Count <= 2)
        //{
        //    Debug.Log("A");
        //    SceneManager.LoadScene("Test");
        //}

        //if (setTime == 0 && Weapons.Count == 3 ) //1
        //{
        //    Debug.Log("B");
        //    SceneManager.LoadScene("Office");
        //}




        //if (setTime <= 0 && gameObject.GetComponent<BoxCollider>().enabled == false)
        //{
        //    {
        //        SceneManager.LoadScene("Office");
        //    }
        //}

        //else
        //{
        //    SceneManager.LoadScene("Office");
        //}

        //if (setTime <= 0 && gameObject.activeSelf == true)
        //{
        //    SceneManager.LoadScene("Test");
        //}

        //else if (setTime <= 0)
        //{
        //    SceneManager.LoadScene("Office");
        //}
    }


}


