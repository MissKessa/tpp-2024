using myData;

namespace myCustomData
{
	class CustomCache : Cache //It's a child of the class Cache
	{
		public static void AccesibilityChecks()
		{
			Cache c = new Cache();
			c.Put("", "");  //OK
			//c.Clear();	//Error due to protection level as it's private
			//c.Grow();		//Error due to protection level as it's protected and cannot be accessed in Cache from outside
			c.HitRate();    //OK

			CustomCache c2 = new CustomCache();
			c2.Put("", "");	//OK
			//c2.Clear();	//Error due to protection level as it's private
			c2.Grow();      //OK as it's a children of Cache
			c2.HitRate();   //OK
		}
	}
}
