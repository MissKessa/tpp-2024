namespace myData
{
	class DataHandler
	{
		public static void AccesibilityChecks()
		{
			Cache c = new Cache();
			c.Put("", "");  //OK
			//c.Clear();	//Error due to protection level as it's private
			//c.Grow();		//Error due to protection level as it's protected and cannot be accessed in Cache from outside
			//c.HitRate();  //Error due to protection level as internal and cannot be accessed from other project
		}
	}
}
