using UnityEngine;
using System.Collections;

public class stone : MonoBehaviour {
	
	public bool m_shoot = false;
	public float m_speed = 1000;
	public float m_friction = 1;
	public Vector3 m_direction;	
	public float m_curSpeed;
	public bool m_stone_frefab = false;
	
	public float m_incTime = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	public void Shoot(Vector3 direction) {
		print ("shoot");
		m_shoot = true;
		m_stone_frefab = true;
		m_direction = direction;		
		m_curSpeed = m_speed;		
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if (m_shoot)
		{
			
			transform.position += m_direction * Time.deltaTime * m_curSpeed * 2;
			
			m_curSpeed -= m_friction * Time.deltaTime;
			
			if (m_curSpeed < 0)
			{
				m_shoot = false;	
			}
			
		}
		
		if (m_stone_frefab == true)
		{
			m_incTime += Time.deltaTime;
			
			if(m_incTime > 2)
			{
				Destroy(gameObject);
				m_stone_frefab = false;
			}
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag != "Player") &&
			(collision.gameObject.tag != "item_stone"))
		{
			m_shoot = false;
		}		
		
	}
		
	
}
