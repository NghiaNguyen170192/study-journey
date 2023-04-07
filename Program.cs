Console.WriteLine("Input file name: ");

var fileName = Console.ReadLine();

var inputs = GetInputs(fileName);
foreach (var input in inputs)
{
	Console.WriteLine(input);
}

static int[] GetInputs(string fileName)
{
	var inputs = new List<int>();
	var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs", fileName);

	using var streamReader = new StreamReader(File.OpenRead(input));
	while (!streamReader.EndOfStream)
	{
		var line = streamReader.ReadLine();
		var number = 0;
		if(int.TryParse(line, out number))
		{
			inputs.Add(number);
		}
	}

	return inputs.ToArray();
}