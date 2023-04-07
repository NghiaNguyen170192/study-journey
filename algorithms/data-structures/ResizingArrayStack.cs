namespace studyjourney.algorithms.datastructure;

public class ResizingArrayStack
{
	private string[] s;
	private int N = 0;
	public ResizingArrayStack()
	{
		s = new string[1];
	}

	public void Push(string item)
	{
		if(N == s.Length) 
		{
			Resize(2* s.Length);
		}
		s[N++] = item;
	}

	public string Pop()
	{
		string item = s[--N];
		s[N] = null;
		if(N > 0 &&  N == s.Length/2) 
		{ 
			Resize(s.Length/2);
		}

		return item;
	}

	private void Resize(int capacity)
	{
		string[] copy = new string[capacity];
		for(int i = 0; i < s.Length; i++) 
		{
			copy[i] = s[i];
		}

		s = copy;
	}
}
