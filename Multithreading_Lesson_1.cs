void Download()
{
	for (int i = 0; i < 5; i++)
	{
        Console.WriteLine("Downloading file...");
	}
}
void Checking_Downloaded_Data() 
{ 
	for (int i = 0; i < 5; i++) 
	{ 
		Console.WriteLine("Checking Downloaded Data...");
	} 
}

Thread thread_download = new Thread(Download);
Thread thread_checking_downloaded_data = new Thread(Checking_Downloaded_Data);

thread_download.Start();
thread_checking_downloaded_data.Start();

thread_download.Join();
thread_checking_downloaded_data.Join();


//This would make it sequential

//Thread thread_download = new Thread(Download);
//Thread thread_checking_downloaded_data = new Thread(Checking_Downloaded_Data);

//thread_download.Start();

//thread_download.Join();
//thread_checking_downloaded_data.Start();

//thread_checking_downloaded_data.Join();


Console.WriteLine("All operations completed.");
