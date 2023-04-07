namespace studyjourney.algorithms.datastructures;

public class Queue
{
	private Node first, last;
	private int N;
	public bool IsEmpty()
	{
		return first == null;
	}

	public void Enqueue(string item)
	{
		Node oldLast = last;
		last = new Node();
		last.item = item;
		last.next = null;

		//check empty queue
		if (IsEmpty())
		{
			first = last;
		}
		else
		{
			oldLast.next = last;
		}

		N++;
	}

	public string Dequeue()
	{
		string item = first.item;
		first = first.next;

		// check empty queue
		if (IsEmpty())
		{
			last = null;
		}

		N--;
		return item;
	}

	public int Size()
	{
		return N;
	}
}
