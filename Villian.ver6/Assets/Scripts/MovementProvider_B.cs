using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider_B : MonoBehaviour
{
    public float speed = 5.0f; // �̵��ӵ�
    public float gravityMultiplier = 1.0f; // �߷¿� ������ �޴� ��츦 ó��
    public List<XRController> controllers = null;
    private CharacterController characterController = null; // VRRig�� ĳ���� ��Ʈ�ѷ�
    private GameObject head = null; //ī�޶��� ��� ��ġ

    

    

    private void Awake()
    {
        //ĳ���� ��Ʈ�ѷ� �Ҵ� �� ī�޶� ��ġ ����
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        //�ʱ� ������ ó��
        PositionController();
    }

    // Update is called once per frame
    void Update()
    {
        PositionController(); // ���� ��ġ�� �°� ��ġ�� ����
        CheckForInput();
        ApplyGravity();
    }
    void PositionController()
    {
        //�ε巯�� �̵��� ���ؼ� 1(�ּ�) 2(�ִ�)���� head��  y���� �����ǵ��� ��
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //���ο� ���� ��ġ�� ����
        Vector3 newCenter = Vector3.zero;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        characterController.center = newCenter;
    }
    void CheckForInput()
    {
        //������ ��Ʈ�Ѥ��� �߿��� ��ǲ �Է��� �ִٸ� �̵�ó���� ��
        foreach(XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }
    void CheckForMovement(InputDevice device)
    {
        //������ primary2DAxis ������ �о���� �� ����
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            StartMove(position);
    }
    void StartMove(Vector2 position)
    {
        //�̵��� ���� ������ ����
        Vector3 direction = new Vector3(position.x, 0, position.y);//y���� ���� ���� ����
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);// �Ӹ��� ȸ�� ������ ����
        direction = Quaternion.Euler(headRotation) * direction;
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);//
    }
    void ApplyGravity()
    {
        //������ �������� ��� �߷��� ����
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);
    }
}
