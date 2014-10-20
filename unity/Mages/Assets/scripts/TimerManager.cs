using System;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	private static Timer __instance;
	
	public IEnumerator TimerStart(float time, Action act)
	{
		yield return new WaitForSeconds(time);
		if (act != null) act();
	}
	
	public static Timer Instance
	{
		get
		{
			if (__instance == null)
			{
				GameObject t = GameObject.Find("Timer") ?? new GameObject("Timer");
				__instance = t.GetComponent<Timer>();
				if (__instance == null) __instance = t.AddComponent<Timer>();
			}
			return __instance;
		}
	}
}