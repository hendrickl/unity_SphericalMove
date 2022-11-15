using UnityEngine;
using TMPro;

public class RockStatistics : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_leftResult;

	[SerializeField]
	private TMP_Text m_rightResult;

	public struct Statistics
	{
		public int left;
		public int right;
	}

	public void UpdateStatistics(Statistics p_stats)
	{
		m_leftResult.text = p_stats.left.ToString();
		m_rightResult.text = p_stats.right.ToString();
	}
}
