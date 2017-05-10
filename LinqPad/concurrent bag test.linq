<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.Concurrent.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Diagnostics.Debug.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private static List<string> strings = new List<string>();
//private static ConcurrentBag<string> strings = new ConcurrentBag<string>();

private void Main()
        {	
//					var t2 = Task.Run(delegate {while (true)
//                                           {
//										   		try{
//													strings.Any();
//												
//												} catch(InvalidOperationException e){
//													Console.WriteLine("Exception Occured!! - " + e.Message);
//													return;
//												}
//                                           }});
			
		
			var sw = System.Diagnostics.Stopwatch.StartNew();
		
			for(var i = 0; i < 100000000; i++){	
				strings.Any();
			}
			
			Console.WriteLine(sw);	   
			
			sw.Restart();
			
			Action action = delegate { for(var i = 0; i < 100000000; i++){	
				strings.Any();
			}};
			
			var t1 = Task.Run(action);
			var t2 = Task.Run(action);
			var t3 = Task.Run(action);
			var t4 = Task.Run(action);
			var t5 = Task.Run(action);
			var t6 = Task.Run(action);
			
			Task.WaitAll(t1,t2,t3,t4,t5,t6);
			Console.WriteLine(sw);				   

		}