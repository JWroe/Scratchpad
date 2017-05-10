<Query Kind="Program" />

private void Main()
        {	
			int objectionsFound = 0;
			int objectionsNotFound = 0;
			
			int num = rand.Next(0, 9999);
			var jobId = Guid.NewGuid().ToString();
			var auditFileName = $"{num}huge_AUDT_{jobId}.csv";
			using (var auditFile = new StreamWriter($"D:\\perf testing\\{auditFileName}")) {
      			auditFile.Write("NHSNumber,EventType,GlobalSystemId,LocalJobId,ObjectionId\n");

				for(var i = 0; i <= 100000000; i++)
				{
					if(rand.Next(2) == 1){
						objectionsNotFound++;
						auditFile.WriteLine($"{RandomNhsNumber()},ObjectionNotFoundEvent,LPOS,{jobId},");
					} else {
						objectionsFound++;
						auditFile.WriteLine($"{RandomNhsNumber()},ObjectionFoundEvent,LPOS,{jobId},{rand.Next(1,10000)}");
					}
  				}
			}
			
			using (var rectFile = new StreamWriter($"D:\\perf testing\\{num}huge_RECT_{jobId}_COMPLETE.csv")) {
      			rectFile.WriteLine("\"NIC Number\",\"Line Item\",\"Local Job Id\",\"File Path\",\"Header Included\",\"Identifier Column\",\"Exempt\",\"Exempt Reason\",\"Repository Date\",\"Repository Version Number\",\"Name of Submitter\",\"Submission Start\",\"Cleaning End\",\"Initial Number of Rows\",\"Number of Rows Removed\",\"Number of Rows Remaining\",\"Number of Exemptions Found\",\"Number of Unique Patients Removed\",\"Status\",\"System ID\",\"Service Area\",\"Local washing machine version used to run the job\",\"Remove NHS Number Column\",\"Cleaned file name\",\"Audit data file name\",\"Error Type\",\"Error Message\",\"Error Time\",\"Failure Type\",\"Failure Message\",\"Failure Time\",\"Failure Row Number\"");
				rectFile.WriteLine($"\"\",\"\",\"{jobId}\",\"D:\\path.csv\",\"Yes\",\"1\",\"No\",\"\",\"06/09/2016 16:31:20\",\"1\",\"IC\\s-jawr1\",\"22/09/2016 19:39:13\",\"22/09/2016 19:45:13\",\"{objectionsFound + objectionsNotFound}\",\"{objectionsFound}\",\"{objectionsNotFound}\",\"0\",\"{objectionsFound}\",\"Complete\",\"LPOS\",\"QA Test\",\"Hscic.Pos.WashingMachine.Local 0.2.4687.100\",\"False\",\"pg-v2-TE_APPR_f5495547-4341-42ad-9e39-b28782e8c65d_COMPLETE.csv\",\"{auditFileName}\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"");
			}
//"","","f5495547-4341-42ad-9e39-b28782e8c65d","P:\LPOS\LPOS_Test_Data\pg-v2-TEST_LTHT_ActivityCCGReportM02.csv","Yes","2","No","","06/09/2016 16:31:20","1","NPFIT\DETH2","16/09/2016 19:39:13","16/09/2016 19:47:15","473342","51205","422137","0","51205","Complete","LPOS","PLEASE_UPDATE_ME","Hscic.Pos.WashingMachine.Local 0.2.4687.100","False","pg-v2-TE_APPR_f5495547-4341-42ad-9e39-b28782e8c65d_COMPLETE.csv","pg-v2-TE_AUDT_f5495547-4341-42ad-9e39-b28782e8c65d.csv","","","","","","",""
		}

        private static string RandomNhsNumber()
        {
            var str = "";
			
			for(var i = 0; i < 10; i++)
			{
				str += RandomDigit();
			}
			return str;
        }
		
		private static Random rand = new Random();
		private static char RandomDigit()
		{
			return (char)rand.Next(48, 57);
		}
		