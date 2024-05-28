using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Utils
{
	public class Slower : MonoBehaviour
	{
		[SerializeField] private int _size = 10000;

		private float _pauseTime;

		private CancellationTokenSource _tokenSource;

		private void Start()
		{
			_tokenSource = new CancellationTokenSource();
		}

		private async void Update()
		{
			if (Input.GetKeyDown(KeyCode.H))
			{
				var number = await Slow();
				Debug.Log($"Number is {number}");
			}
		}

		private void OnDisable()
		{
			_tokenSource.Cancel();
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			Debug.Log($"Focus :{hasFocus}");
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			Debug.Log($"Pause :{pauseStatus}");
			if (pauseStatus)
			{
				_pauseTime = Time.realtimeSinceStartup;
			}
			else
			{
				Debug.Log(Time.realtimeSinceStartup - _pauseTime);
			}
		}

		private async Task<float> Slow()
		{
			var number = -1.0f;
			var watch = new Stopwatch();
			watch.Start();

			await Task.Run(() =>
			{
				var values = new float[_size, _size];
				for (var i = 0; i < _size; i++)
				{
					for (var j = 0; j < _size; j++)
					{
						values[i, j] = Mathf.PerlinNoise(i * 0.01f, j * 0.01f);
					}
				}

				number = values[10000, 10000];
			}, _tokenSource.Token);

			if (_tokenSource.IsCancellationRequested)
			{
				Debug.Log($"Number is {number}");
				return number;
			}

			watch.Stop();
			Debug.Log(watch.Elapsed);
			return number;
		}
	}
}