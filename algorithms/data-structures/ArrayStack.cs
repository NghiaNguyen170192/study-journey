namespace studyjourney.algorithms.datastructure;

public class ArrayStack
{
	private string[] s;
	private int N = 0;
	public ArrayStack(int n)
	{
		s = new string[n]; 
	}

	public bool IsEmpty()
	{
		return N == 0;
	}

	public void Push(string item)
	{
		s[N++] = item;
	}

	//Loitering: holding a reference to an object when it is no longer needed
	//public string Pop()
	//{
	//	return s[--N];
	//}

	//avoid loitering
	public string Pop()
	{
		string currentItem = s[--N];
		s[N] = null;
		return currentItem;
	}
}
