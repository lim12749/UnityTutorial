 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum GunState
{
    //�߻��غ��, źâ��, ������
    Ready, Empty, Reloading
}
//�� �߻��
public class Gun : MonoBehaviour
{
    // �� �� ����
    public GunState myGunState { get; private set; }

    public Transform muuzle;
    public Bullet projectile;//����ü
    public float msBetweenShots = 100f; //
    public float muzzleVelocity = 35f;

    public float nextShotTime; //�߻� ����

    public int ammoRemaining;//���� ��ü �Ѿ�
    public int magcapacity; //źâ ũ��
    public int magAmmo;//źâ�� ���� �Ѿ�

    private float reloadTime = 2.0f;

    private void OnEnable()
    {
        // ������ ���۵ǰų� �������� �ݰų��Ҷ� �ʱ�ȭ����
        ammoRemaining = 30;
        magcapacity = 10;
        //����źâ = źâ ũ��
        magAmmo = magcapacity;
        myGunState = GunState.Ready; 
        UIManager.Instance.UpdateAmmoText(magAmmo,ammoRemaining);

    }
    public void Shoot()
    {
        Debug.Log("�Ѿ� ����");
        if (myGunState == GunState.Ready)
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + msBetweenShots / 1000f;
                Bullet _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
                _projectile.SetBullet(muzzleVelocity);

                //Destroy(_projectile.gameObject, 5f);

                magAmmo--; //�Ѿ� ����
                if (magAmmo <= 0) //0���� �۰ų� ������� 
                {
                    //����������� ����
                    myGunState = GunState.Empty;
                }
            }
        }
        UIManager.Instance.UpdateAmmoText(magAmmo, ammoRemaining);
    }

    public bool Reload()
    {
        Debug.Log("������ ����");
        if (ammoRemaining <=0 || magAmmo >= magcapacity)
        {
            Debug.Log("������ �Ұ�");
            return false; 
        }
        StartCoroutine(Reloaded());
        return true;
    }
    private IEnumerator Reloaded()
    {
        myGunState = GunState.Reloading;

        //���� ���

        //������ �ð���ŭ �ð��� �̷�
        yield return new WaitForSeconds(reloadTime);

        //�ð��� �ٳ����� ���� �� ��������
        
        //źâũ�⸸ŭ ä��
        magAmmo = magcapacity;
        //źâũ�⸸ŭ �����ִ� �Ѿ��� ���ҽ�Ŵ 
        ammoRemaining -= magcapacity;
        //�ٽ� ��� �ִ� ���·� ����
        myGunState = GunState.Ready;
        //������ UI����
        UIManager.Instance.UpdateAmmoText(magAmmo, ammoRemaining);
    }
}
