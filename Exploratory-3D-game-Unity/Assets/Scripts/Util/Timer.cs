using System;
using UnityEngine;

namespace zm.Util
{
	public class Timer : MonoBehaviour
	{
		#region MonoBehaviour Methods

		private void Update()
		{
			if (!started) { return; }

			TimeLeft -= Time.deltaTime;
			if (TimeLeft <= 0)
			{
				// If timer reached 0, stop it and trigger onFinished
				onFinished();
				StopTicking();
			}
		}

		#endregion MonoBehaviour Methods

		#region Public Methods

		public void StartTicking(float time, Action callback)
		{
			TimeLeft = time;
			onFinished = callback;
			started = true;
		}

		public void StopTicking()
		{
			started = false;
			TimeLeft = 0;
			onFinished = null;
		}

		#endregion Public Methods

		#region Fields and Properties

		/// <summary>
		/// Time left until timer finishes it's counting.
		/// </summary>
		public float TimeLeft { get; private set; }

		/// <summary>
		/// Flag indicating if timer started.
		/// </summary>
		private bool started;

		/// <summary>
		/// Action that will be triggered if timer counts down to 0.
		/// </summary>
		private Action onFinished;

		#endregion Fields and Properties
	}
}