<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.Concurrent.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
</Query>

private long count = 0;
private long nhsNumber = 1000000000;
private HashSet<string> _uniquePatientsRemoved = new HashSet<string>();

private void Main()
{ 
	while(true == true)
	{
		_uniquePatientsRemoved.Add(nhsNumber.ToString());
		if(count % 1000000 == 0) Console.WriteLine(DateTime.UtcNow + ", " + count);
		count++;
		nhsNumber++;
	}
}