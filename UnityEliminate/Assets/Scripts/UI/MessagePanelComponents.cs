/****************************************************************************
 * 2018.7 PC-20180322LBTL
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;
	using QFramework;

	public partial class MessagePanel	{
		public const string NAME = "MessagePanel";
		[SerializeField] public Button BtnBack;
		[SerializeField] public Button BtnOk;

		protected override void ClearUIComponents()
		{
			BtnBack = null;
			BtnOk = null;
		}
	}
}
