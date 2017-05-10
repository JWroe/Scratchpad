<Query Kind="Program" />

void Main()
{
	var toValidate = "[[()]]";
	
	ValidateString(toValidate);
}



bool ValidateString(string toCheck){
	if(toCheck == string.Empty){
		return true;
	}
		
	var firstDelimiter = toCheck.Select((c, i) => new StringItem(c,i)).SkipWhile(s => !s.IsDelimiter).FirstOrDefault();
	
	if(firstDelimiter == null){
		return true;
	}
	
	int closingTagsToFind = 1;
	for(var i = firstDelimiter.Index; i < toCheck.Length; i++){
		if(toCheck[i] == firstDelimiter.DelimiterType.ClosingTag){
			closingTagsToFind--;
			if(closingTagsToFind == 0){
				break;
			}
		}
		
		if(toCheck[i] == firstDelimiter.Character){
			closingTagsToFind++;
		}
		
		
	}
	
	return true;
}


internal class StringItem
{

	List<Delimiter> Delimiters = new List<Delimiter>{ new Delimiter{OpeningTag = '[', ClosingTag=']'},new Delimiter{OpeningTag = '(', ClosingTag=')'},};
	public char Character {get;set;}
	public int Index {get;set;}
	public bool IsDelimiter { get { return IsClosingDelimiter || IsOpeningDelimiter; }}
	public bool IsClosingDelimiter { get { return Delimiters.Any(d => d.ClosingTag == Character); }}
	public bool IsOpeningDelimiter { get { return Delimiters.Any(d => d.OpeningTag == Character); }}
	public Delimiter DelimiterType { get{ return Delimiters.FirstOrDefault(d => d.ClosingTag == Character || d.OpeningTag == Character);} }
	
	public StringItem(Char c, int i){
		Index = i;
		Character = c;
	}
}

public class Delimiter 
{
	public char OpeningTag {get;set;}
	public char ClosingTag {get;set;}
}

// Define other methods and classes here
