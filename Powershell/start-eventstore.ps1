$myWindowsID=[System.Security.Principal.WindowsIdentity]::GetCurrent()
$myWindowsPrincipal=new-object System.Security.Principal.WindowsPrincipal($myWindowsID)
$adminRole=[System.Security.Principal.WindowsBuiltInRole]::Administrator
if (!$myWindowsPrincipal.IsInRole($adminRole))
   {
   $newProcess = new-object System.Diagnostics.ProcessStartInfo "PowerShell";
   $newProcess.Arguments = $myInvocation.MyCommand.Definition;
   $newProcess.Verb = "runas";
   [System.Diagnostics.Process]::Start($newProcess);   
   exit
}
cd 'C:\Event Store\EventStore-OSS-Win-v3.4.0\'
#.\EventStore.ClusterNode.exe --db ./db --log ./logs --ext-ip 172.20.16.135
.\EventStore.ClusterNode.exe --db ./db --log ./logs --ext-ip 172.20.16.136
.\EventStore.ClusterNode.exe --db ./db --log ./logs --ext-ip 172.20.16.137

#.\EventStore.ClusterNode.exe --mem-db --log c:\dbs\cluster\log1 --int-ip 192.168.0.1 --ext-ip 172.20.16.135 --int-tcp-port=1111 --ext-tcp-port=1112 --int-http-port=2113 --ext-http-port=2114 #--cluster-size=3 --discover-via-dns=false --gossip-seed=172.20.16.136:2113,172.20.16.137:2113
#.\EventStore.ClusterNode.exe --mem-db --log c:\dbs\cluster\log2 --int-ip 192.168.0.2 --ext-ip 172.20.16.136 --int-tcp-port=1111 --ext-tcp-port=1112 --int-http-port=2113 --ext-http-port=2114 --cluster-size=3 --discover-via-dns=false --gossip-seed=172.20.16.135:2113,172.20.16.137:2113
#.\EventStore.ClusterNode.exe --mem-db --log c:\dbs\cluster\log3 --int-ip 192.168.0.3 --ext-ip 172.20.16.137 --int-tcp-port=1111 --ext-tcp-port=1112 --int-http-port=2113 --ext-http-port=2114 --cluster-size=3 --discover-via-dns=false --gossip-seed=172.20.16.135:2113,172.20.16.136:2113

Write-Host "Press any key to close..."

$host.UI.RawUI.ReadKey()