﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;
using System.Collections.Generic;
namespace UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("OwnerID", 1);
            parameter.Add("PetName", "Søren");
            parameter.Add("PetType", "Dog");
            parameter.Add("PetBreed", "Corgi");
            parameter.Add("PetDOB", "14.05.2016");
            parameter.Add("PetWeight", 14.1d);
            ConsentDatabaseController.ExecuteNonQuery("InsertPet", parameter);
            
		}
	}
}
