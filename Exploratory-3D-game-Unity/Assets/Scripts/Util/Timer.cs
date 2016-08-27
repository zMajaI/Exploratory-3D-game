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

			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0)
			{
				// If timer reached 0, stop it and trigger onFinished
				StopTicking();
				onFinished();
			}
		}

		#endregion MonoBehaviour Methods

		#region Public Methods

		public void StartTicking(float time, Action callback)
		{
			timeLeft = time;
			onFinished = callback;
			started = true;
		}

		public void StopTicking()
		{
			started = false;
			timeLeft = 0;
			onFinished = null;
		}

		#endregion Public Methods

		#region Fields and Properties

		/// <summary>
		/// Time left until timer finishes it's counting.
		/// </summary>
		private float timeLeft;

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