using UnityEngine;

namespace BubbleBobble
{
	public class Shop : MonoBehaviour
	{
		// Points serialized for testing
		[SerializeField] private int _points = 0;
		[SerializeField] private PowerUp[] _powerUps;
		[SerializeField] private ItemData[] _shells;
		[SerializeField] private PlayerControl _playerControl;
		[SerializeField] private Health _health;

		private void Update()
		{
			CheckPoints();
		}

		/// <summary>
		/// Check whether player has enough points for each power up.
		/// If not, price text of power up is set to red.
		/// </summary>
		private void CheckPoints()
		{
			foreach (PowerUp powerUp in _powerUps)
			{
					if (powerUp.PowerUpData.Price > _points)
				{
					powerUp.SetPriceColor(Color.red);
				}
				else
				{
					powerUp.SetPriceColor(Color.black);
				}
			}
		}

		/// <summary>
		/// Check whether all shells are in player's inventory.
		/// </summary>
		/// <returns> True if all shells are found in inventory, false if not. </returns>
		private bool CheckInventory()
		{
			if (_playerControl.CheckInventoryContent(_shells[0]) &&
				_playerControl.CheckInventoryContent(_shells[1]) &&
				_playerControl.CheckInventoryContent(_shells[2]) &&
				_playerControl.CheckInventoryContent(_shells[3]))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// Tied to shop buttons for each power up and extra life.
		/// If player has enough points, they can buy a power up.
		/// If player has all shells and doesn't have max lives, player can buy an extra life.
		/// Shells are removed from player inventory upon purchase.
		/// </summary>
		/// <param name="index"> Set in each button to pick correct power up. </param>
		public void Buy(int index)
		{
			if (index >= 0 && index  <= 3)
			{
				if (_powerUps[index].PowerUpData.Price <= _points)
				{
					_powerUps[index].ActivatePowerUp();
				}
			}
			else if (index == 4)
			{
				if (CheckInventory() && _health != null && _health.CurrentLives < _health.MaxLives)
				{
					_health.SetExtraLife(true);
					_playerControl.RemoveFromInventory(_shells[0]);
					_playerControl.RemoveFromInventory(_shells[1]);
					_playerControl.RemoveFromInventory(_shells[2]);
					_playerControl.RemoveFromInventory(_shells[3]);
				}
			}
		}
	}
}
