using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bradley_catherine_test;";
    }
    public void Dispose()
    {
      Stylist.Truncate();
    }

    [TestMethod]
    public void GetAll_ReturnStylistsInList_True()
    {
      Stylist newStylist = new Stylist("Barb");
      newStylist.Save();

      int result = Stylist.GetAll().Count;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Delete_OneStylistInList_True()
    {
      Stylist firstStylist = new Stylist("Barb");
      Stylist secondStylist = new Stylist("Narb");
      firstStylist.Save();
      secondStylist.Save();

      Console.WriteLine(firstStylist.Id);

      Stylist.Delete(firstStylist.Id);
      int result = Stylist.GetAll().Count;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Edit_NameOfStylist_True()
    {
      Stylist firstName = new Stylist("Barb");
      firstName.Save();
      Console.WriteLine(firstName.Id);

      string secondName = "Narb";

      firstName.Edit(secondName);

      string result = Stylist.Find(firstName.Id).Name;

      Assert.AreEqual("Narb", result);
    }
  }
}
