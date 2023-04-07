namespace studyjourney.algorithms.search;

public class WeightedQuickUnionUF
{
	private int[] parent;   // parent[i] = parent of i
	private int[] size;     // size[i] = number of elements in subtree rooted at i
	private int count;      // number of components

	public WeightedQuickUnionUF(int n)
	{
		count = n;
		parent = new int[n];
		size = new int[n];
		for (int i = 0; i < n; i++)
		{
			parent[i] = i;
			size[i] = 1;
		}
	}

	public int Count()
	{
		return count;
	}
	public int Find(int p)
	{
		validate(p);
		while (p != parent[p])
			p = parent[p];
		return p;
	}

	private void validate(int p)
	{
		int n = parent.Length;
		if (p < 0 || p >= n)
		{
			throw new ArgumentException("index " + p + " is not between 0 and " + (n - 1));
		}
	}

	public void Union(int p, int q)
	{
		int rootP = Find(p);
		int rootQ = Find(q);
		if (rootP == rootQ) return;

		// make smaller root point to larger one
		if (size[rootP] < size[rootQ])
		{
			parent[rootP] = rootQ;
			size[rootQ] += size[rootP];
		}
		else
		{
			parent[rootQ] = rootP;
			size[rootP] += size[rootQ];
		}
		count--;
	}
}
