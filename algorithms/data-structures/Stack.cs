namespace studyjourney.algorithms.datastructure;

public class Stack
{
	private Node first = null;
	private int N = 0;

	public void Push(string item)
	{
		Node oldFirst = first;
		first.item = item;
		first.next = oldFirst;

		N++;
	}

	public string Pop()
	{
		string item = first.item;
		first = first.next;

		N--;

		return item;
	}

	public bool IsEmpty() { return first == null; }

	public int Size() { return  N; }
}
