using System;

namespace studyjourney.algorithms.search;


public class Percolation
{

	private readonly int size;
	private readonly int topIndex;

	private readonly int bottomIndex;
	private readonly WeightedQuickUnionUF wquf;

	private readonly bool[,] sites;

	private int openedSites;

	// creates n-by-n grid, with all sites initially blocked
	public Percolation(int n)
	{
		if (n <= 0)
		{
			throw new ArgumentException();
		}

		size = n;
		openedSites = 0;
		sites = new bool[size, size];
		wquf = new WeightedQuickUnionUF(n * n + 2); // 1 for top, 1 for bottom
		topIndex = 0;
		bottomIndex = size * size + 1;
	}

	// test client (optional)
	public static void main(String[] args)
	{
		int n = int.Parse(args[0]);

		Percolation percolation = new Percolation(n);

		for (int i = 1; i < args.Length; i += 2)
		{
			int row = int.Parse(args[i]);
			int column = int.Parse(args[i + 1]);

			percolation.Open(row, column);
		}
	}

	// opens the site (row, column) if it is not Open already
	public void Open(int row, int column)
	{
		BoundaryCheck(row, column);

		if (IsOpen(row, column))
		{
			return;
		}

		sites[row - 1, column -1] = true;
		openedSites++;

		int currentIndex = GetIndex(row, column);

		if (row == size)
		{
			wquf.Union(currentIndex, bottomIndex);
		}

		if (row == 1)
		{
			wquf.Union(currentIndex, topIndex);
		}

		// site in middle, check lower site
		if (row < size && IsOpen(row + 1, column))
		{
			wquf.Union(currentIndex, GetIndex(row + 1, column));
		}

		// site in middle, check upper site
		if (row > 1 && IsOpen(row - 1, column))
		{
			wquf.Union(currentIndex, GetIndex(row - 1, column));
		}

		// site in middle, check left site
		if (column > 1 && IsOpen(row, column - 1))
		{
			wquf.Union(currentIndex, GetIndex(row, column - 1));
		}

		// site in middle, check right site
		if (column < size && IsOpen(row, column + 1))
		{
			wquf.Union(currentIndex, GetIndex(row, column + 1));
		}
	}

	// is the site (row, column) Open?
	public bool IsOpen(int row, int column)
	{
		BoundaryCheck(row, column);
		return sites[row - 1, column - 1];
	}

	// is the site (row, column) full?
	public bool IsFull(int row, int column)
	{
		if (BoundaryCheck(row, column))
		{
			int currentIndex = GetIndex(row, column);
			return wquf.Find(currentIndex) == wquf.Find(topIndex);
		}

		return false;
	}

	// returns the number of Open sites
	public int NumberOfOpenSites()
	{
		return openedSites;
	}

	// does the system percolate?
	public bool Percolates()
	{
		return wquf.Find(topIndex) == wquf.Find(bottomIndex);
	}

	private int GetIndex(int row, int column)
	{
		return size * (row - 1) + column;
	}

	private bool BoundaryCheck(int row, int column)
	{
		if (column > size || column <= 0)
		{
			throw new ArgumentException();
		}

		if (row > size || row <= 0)
		{
			throw new ArgumentException();
		}

		return true;
	}
}