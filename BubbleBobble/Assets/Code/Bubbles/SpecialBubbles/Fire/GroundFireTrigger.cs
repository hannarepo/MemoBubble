using UnityEngine;

namespace BubbleBobble
{
	public class GroundFireTrigger : MonoBehaviour
	{

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag(Tags.Enemy))
			{
				other.gameObject.GetComponent<EnemyManagement>().LaunchAtDeath(true);
			}

		}
	}
}
