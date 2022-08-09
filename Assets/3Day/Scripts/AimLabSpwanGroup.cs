using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��������θ� ���� Ÿ��(��ǥ���� ��ȯ)

public class AimLabSpwanGroup : MonoBehaviour
{
    //������ ��ȯ�� �Ұ���? -> ��ȯ�� ��ü�� ����
    public GameObject targetOriginalModel;
    //��� ��ȯ�Ұ���? ��ġ�� �����ϴ� TransformŸ�� �迭�� ������
    public Transform[] targetPositions;

    public bool isPlaying = false;
    public int maxCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //����
            StartCoroutine(CreateTarget());
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            //��ž
        }
    }
    IEnumerator CreateTarget()
    {
        while(!isPlaying)
        {
            //����ȭ��ӿ� �ִ� ��ü�� �ױ׸� ���� �˾Ƴ���.
            //Length�� ���� �迭 ����� ��ȯ�մϴ�.
            int targetCount = (int)GameObject.FindGameObjectsWithTag("Target").Length;
            //�����ȯ�� Ÿ�ټ� < �ִ� Ÿ�� �� 
            if(targetCount< maxCount)
            {
                yield return new WaitForSeconds(2.0f);
                //������ ���ڸ� ��ȯ�մϴ�.
                //�ּҼ��� ~ �ִ������ ������ ���� ��ȯ
                int index = UnityEngine.Random.Range(0, targetPositions.Length);

                //���� : �������� ������ Ÿ���� �ȳ����� �ٸ� ��ġ�� �����ǰ� ��.
                targetPositions[index].Find("�̸�");
                //������ �����մϴ�(������ ����, ������ ��ǰ�� ������ ��ġ)
                Instantiate(targetOriginalModel, targetPositions[index]);
                //��
                /*
                var item = Instantiate(targetOriginalModel, targetPositions[index]);
                Target itemTarget = item.GetComponent<Target>();
                itemTarget.uiContoller = GameObject.Find("Canvas").GetComponent<UIContoller>();
                */
            }
            else
            {
                yield return null;//�纸���� �ʰڴ�.
            }
        }
        

    }
}
