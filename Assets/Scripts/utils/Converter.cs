using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Converter{

	// Use this for initialization
	public static int[] IntToIntMass10(int number)
	{
		int result=0;
		List<int> results = new List<int>();
		for(;;)
		{
			if(number<=0)
			{
				return results.ToArray();
			}
			result = number%10;
			results.Add(result);
			number-=result;
			number/=10;
		}
	}
	public static int[] IntToIntMass(int number,int multi)
	{
		int result=0;
		List<int> results = new List<int>();
		for(;;)
		{
			if(number<=0)
			{
				return results.ToArray();
			}
			result = number%multi;
			results.Add(result);
			number-=result;
			number/=multi;
		}
	}
	public static int IntMassToInt(int[] mass,int multi)
	{
		int multiplier=multi;
		int result=0;
			result=mass[0];
		for(int i=1;i<mass.Length;i++)
		{
			result+=mass[i]*multiplier;
			multiplier*=multi;
		}
		return result;
	}
	public static int IntMassToInt10(int[] mass)
	{
		int multiplier=10;
		int result=0;
			result=mass[0];
		for(int i=1;i<mass.Length;i++)
		{
			result+=mass[i]*multiplier;
			multiplier*=10;
		}
		return result;
	}
}
