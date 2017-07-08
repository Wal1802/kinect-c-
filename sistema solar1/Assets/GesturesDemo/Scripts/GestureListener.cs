using UnityEngine;
using System.Collections;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;

	private bool swipeLeft = false;
	private bool swipeRight = false;
	private bool zoomIn = false;
	private bool zoomOut = false;
	private bool pushIt = false;
	private bool jumpIn = false;
	private bool pull = false;

	private bool openHand = false;



	public bool IsSwipeLeft()
	{
		if (swipeLeft)
		{
			swipeLeft = false;
			return true;
		}

		return false;
	}

	public bool IsSwipeRight()
	{
		if (swipeRight)
		{
			swipeRight = false;
			return true;
		}

		return false;
	}

	public bool IsZoomIn()
	{
		if (zoomIn)
		{
			zoomIn = false;
			return true;
		}
		return false;
	}

	public bool IsZoomOut()
	{
		if (zoomOut)
		{
			zoomOut = false;
			return true;
		}
		return false;
	}

	public bool IsPush()
	{
		if (pushIt)
		{
			pushIt = false;
			return true;
		}
		return false;
	}

	public bool IsJump()
	{
		if (jumpIn)
		{
			jumpIn = false;
			return true;
		}
		return false;
	}

	public bool IsOpenHand()
	{
		if (openHand)
		{
			openHand = false;
			return true;
		}
		return false;
	}

	public bool IsPull()
	{
		if (pull)
		{
			pull = false;
			return true;
		}
		return false;
	}

	public void UserDetected(uint userId, int userIndex)
	{
		// detect these user specific gestures
		KinectManager manager = KinectManager.Instance;
		
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.ZoomIn);
		manager.DetectGesture(userId, KinectGestures.Gestures.ZoomOut);
		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);

		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);


		if (GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "Swipe left or right to change the slides.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		// don't do anything here
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = sGestureText;
		}

		if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
		else if (gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
		else if (gesture == KinectGestures.Gestures.ZoomIn)
			zoomIn = true;
		else if (gesture == KinectGestures.Gestures.ZoomOut)
			zoomOut = true;
		else if (gesture == KinectGestures.Gestures.Push)
			pushIt = true;
		else if (gesture == KinectGestures.Gestures.Jump)
			jumpIn = true;
		else if (gesture == KinectGestures.Gestures.Pull)
			pull = true;

		//KinectGestures.Gestures.SwipeUp


		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}
	
}
