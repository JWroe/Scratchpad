#$Cred = Get-Credential

# Next, allow the use of self-signed SSL certificates.

#[System.Net.ServicePointManager]::ServerCertificateValidationCallback = { $True }

# Create variables to store the values consumed by the Invoke-RestMethod command. The search variable contents are later embedded in the body variable.
$geturl = "http://uatapi.localaudit.pos.hscic.gov.uk/api/v1/AuditExchangeRequest/877ddaba-4a63-4c90-8c13-95dee65d7001"
$Url = "http://uatapi.localaudit.pos.hscic.gov.uk/api/v1/Dissemination/"
#$Url = "http://uatapi.localaudit.pos.hscic.gov.uk/api/v1/AllServiceAreas/"

# The cmdlet handles URL encoding. The body variable describes the search criteria, specifies CSV as the output mode, and specifies a time period for returned data that starts two days ago and ends one day ago. The body variable specifies values for parameters that apply to the particular REST API with which Invoke-RestMethod is communicating.

$headers = @{
    Accept ="application/json"
}

$X = Invoke-RestMethod -Method Get -Uri $geturl -Credential $Cred 

$Body = @{
	id = 1
	CreateNotification = "false"
	LocalJobId = "a767d43b-5db1-490e-ab14-6cca5a24f395"
	DisseminationId = [guid]::NewGuid()
	GlobalJobId = "877ddaba-4a63-4c90-8c13-95dee65d7001"
	DisseminationDate = "2016-10-13T00:00:00"
	FinalAssetName = "RWG_AE_APPR_A767D43B-5DB1-490E-AB14-6CCA5A24F395_COMPLETE.csv"
	Recipient = "ITDEV Test"
	DisseminatedBy = "IC\\ISleigh"
	AggregatedFormatSent = "false"
	FriendlyDisseminationName = "Data for Commissioning"
    JobRowVersion = $x.RowVersion
}

# Now, run the Invoke-RestMethod command with all variables in place, specifying a path and file name for the resulting CSV output file.

Invoke-RestMethod -Method Post -Uri $url -Credential $Cred -Body (ConvertTo-Json $body) -ContentType "application/json"
