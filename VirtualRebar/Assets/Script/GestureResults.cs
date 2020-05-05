using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureResults : MonoBehaviour
{
    public GameObject m_prefabObject;
    public float m_shootForce;
    
    public void Shoot()
    {
        GameObject projectile = Instantiate(m_prefabObject, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * m_shootForce);
        Destroy(projectile, 5);
    }
}
