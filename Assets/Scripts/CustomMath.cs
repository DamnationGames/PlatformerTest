using UnityEngine;
using System.Collections;

public enum MyDirection
{
	Up,
	Down,
	Right,
	Left,
	Forward,
	Back,
	In,
	Out
}

public enum two
{
	Up,
	Down,
	Invalid
}

public enum three
{
	Up,
	Middle,
	Down,
	Invalid
}

public static class CustomMath {
	public static int Cycle(int number, int modulus, MyDirection dir = MyDirection.Up)
	{
		int neg = 0;

		if(dir == MyDirection.Up || dir == MyDirection.Right || dir == MyDirection.Forward)
			neg = 1;
		else if(dir == MyDirection.Down || dir == MyDirection.Left || dir == MyDirection.Back)
			neg = modulus - 1;
		else
		{
			Logging.VitalLog("Attempting to cycle in an invalid direction", "Custom Math Script");
			return -1;
		}

		return Mod (number + neg, modulus);
	}

	public static int Mod(int number, int modulus)
	{
		number = number % modulus;
		return number;
	}

	public static two TwoState(MyDirection dir)
	{
		if(dir == MyDirection.Up || dir == MyDirection.Right || dir == MyDirection.Forward)
			return two.Up;
		else if(dir == MyDirection.Down || dir == MyDirection.Left || dir == MyDirection.Back)
			return two.Down;
		else 
			return two.Invalid;
	}

	public static two ReverseTwoState(two state)
	{
		if(state == two.Up)
			return two.Down;
		else if(state == two.Down)
			return two.Up;
		else
			return two.Invalid;
	}

	public static three ThreeState(three current, MyDirection dir)
	{
		if(dir == MyDirection.Up || dir == MyDirection.Right || dir == MyDirection.Forward)
		{
			if(current == three.Up || current == three.Middle)
				return three.Up;
			else
				return three.Middle;
		}
		else if(dir == MyDirection.Down || dir == MyDirection.Left || dir == MyDirection.Back)
		{
			if(current == three.Up)
				return three.Middle;
			else
				return three.Down;
		}
		else 
			return three.Invalid;
	}
}
