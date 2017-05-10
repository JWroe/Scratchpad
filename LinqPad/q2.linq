<Query Kind="Program" />

void Main()
{
	var fsWatcher = new FileSystemWatcher(@"C:\foldertowatch")
                    {
                        EnableRaisingEvents = true,
                        IncludeSubdirectories = false
                    };
    fsWatcher.Created += (o, args) => Handle(args.FullPath);
			
	while(true);
}

public void Handle(string path){
	if(Directory.Exists(path)){
		return;
	}
	
	Console.WriteLine(path);
}

// Define other methods and classes here
