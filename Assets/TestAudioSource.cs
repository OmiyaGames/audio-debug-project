using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestAudioSource : MonoBehaviour
{
	[SerializeField]
	AudioSource audioSource;
	[SerializeField]
	float waitSeconds = 0.5f;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(waitSeconds);
		audioSource.Stop();
		Debug.Log("Called audioSource.Stop()");
		Debug.Log($"audioSource.isPlaying: {audioSource.isPlaying}");
		Debug.Log($"audioSource.time: {audioSource.time}");
		yield return new WaitForSeconds(waitSeconds);
		audioSource.Play();
		Debug.Log("Called audioSource.Play()");
		Debug.Log($"audioSource.isPlaying: {audioSource.isPlaying}");
		Debug.Log($"audioSource.time: {audioSource.time}");
		yield return new WaitForSeconds(waitSeconds);
		audioSource.Pause();
		Debug.Log("Called audioSource.Pause()");
		Debug.Log($"audioSource.isPlaying: {audioSource.isPlaying}");
		Debug.Log($"audioSource.time: {audioSource.time}");
		yield return new WaitForSeconds(waitSeconds);
		audioSource.UnPause();
		Debug.Log("Called audioSource.UnPause()");
		Debug.Log($"audioSource.isPlaying: {audioSource.isPlaying}");
		Debug.Log($"audioSource.time: {audioSource.time}");
	}

	void Reset()
	{
		audioSource = GetComponent<AudioSource>();
	}
}
