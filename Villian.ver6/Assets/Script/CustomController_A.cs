using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController_A : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private InputDevice availableDevice;

    public bool renderController; // hand�� controller ���̸� ������ ����
    public GameObject handModel; // hand �� ������
    private GameObject handInstance; // �ڵ� �ν��Ͻ�

    private Animator handModelAnimator; // �ڵ� �� �ִϸ��̼� ����

    //[SerializeField]
    //private GameObject Gun; // ��Ʈ�ѷ��� ���� ������Ʈ
    //[SerializeField]
    //private GameObject Sword; // ��Ʈ�ѷ��� ���� ������Ʈ
    //[SerializeField]
    //private GameObject Grenade; // ��Ʈ�ѷ��� ���� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
       
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        // ������ ��Ʈ�ѷ��� �Է¹ޱ� ���� ����ϴ� ��
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach (var device in devices)
        {
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }
        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            GameObject currentControllerModel;
            if (availableDevice.name.Contains("Left"))
            {
                currentControllerModel = controllerModels[1];
            }
            else if (availableDevice.name.Contains("Right"))
            {
                currentControllerModel = controllerModels[2];
            }
            else
            {
                currentControllerModel = null;
            }
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                  // Debug.LogError("Didn't get suitable controller model");
                 controllerInstance = Instantiate(controllerModels[0], transform);
                controllerInstance = Instantiate(currentControllerModel, transform);
            }

            handInstance = Instantiate(handModel, transform); // �ڵ� �ν��Ͻ� �߰�
            handModelAnimator = handInstance.GetComponent<Animator>();
        }

    }
    // Update is called once per frame
     
    void Update()
    {
        if (!availableDevice.isValid)
        {
            TryInitialize();
          return;
        }
       

        if (renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation(); // �ڵ� �ִϸ��̼��� ���⼭�� ����

        }



        //if (Gun != null)           // ���� ������Ʈ ��Ʈ�ѷ��� ������ ����!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");

        //        Destroy(Gun.gameObject);

        //    }
        //}



        //if (Sword != null)           // ���� ������Ʈ ��Ʈ�ѷ��� ������ ����!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");
        //        Destroy(Sword.gameObject);

        //    }
        //}

        //if (Grenade != null)           // ���� ������Ʈ ��Ʈ�ѷ��� ������ ����!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");
        //        Destroy(Grenade.gameObject);

        //    }
        //}
    }
    void UpdateHandAnimation()
    {
        if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }
        if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
