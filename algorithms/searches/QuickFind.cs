namespace studyjourney.algorithms.search;

/// <summary>
/// quadratic algorithm
/// </summary>
public class QuickFind
{
    private readonly int[] id;

    /// <summary>
    /// integer array id[] of length n
    /// </summary>
    /// <param name="n"></param>
	public QuickFind(int n)
    {
        id = new int[n];

        for (int i = 0; i < n; i++) 
        {
            id[i] = i;
        }
    }

    /// <summary>
    /// p and q are connected iff(if and only if) they have the same id
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    public bool Connected(int p, int q)
    {
        return id[p] == id[q];
    }

    /// <summary>
    /// to merge components containing p and q, change all entries 
    /// whose id equals id[p] to id[q]
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    public void Union(int p, int q)
    {
        int pid = id[p];
        int qid = id[q];
        for (int i = 0;i < id.Length;i++)
        {
            if (id[i] == pid)
            {
                id[i] = qid;
            }
        }
    }
}