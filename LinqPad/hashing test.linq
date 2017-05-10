<Query Kind="Program" />

void Main()
{
	var watch = new System.Diagnostics.Stopwatch();
	
	watch.Start();
	
	var number = 1000000;
	Console.Write($"Generating {number} strings in...");
	var strings = GenerateStrings(number);
	Console.WriteLine(watch.Elapsed);
	
	watch.Restart();
	Console.Write("Hashing all strings in...");
	strings.Select(str => str.GetHashCode()).ToList();
	Console.WriteLine(watch.Elapsed);
	
	watch.Restart();
    var mySHA256 = System.Security.Cryptography.SHA256.Create();

	Console.WriteLine("SHA256 hashing all strings in...");
	strings.Select(str => mySHA256.ComputeHash(GetBytes(str))).ToList();
	Console.WriteLine(watch.Elapsed);
	
}

static byte[] GetBytes(string str)
{
    byte[] bytes = new byte[str.Length * sizeof(char)];
    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
    return bytes;
}

public IEnumerable<string> GenerateStrings(int number){
	
	var strings = new List<string>();
	for(var i = 0; i < number; i++){
		strings.Add(Guid.NewGuid().ToString());
		//strings.Add("0000000000");
	}
	return strings;
}

// Define other methods and classes here