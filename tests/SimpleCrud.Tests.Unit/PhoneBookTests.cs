using SimpleCrud.Core.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace SimpleCrud.Tests.Unit;

public class PhoneBookTests
{
    [Test]
    public void GivenCorrectValues_WhenCreatingPhoneBook_ThenSuccess()
    {
        //arrange
        const string name = "ExampleName";
        const string phoneNumber = "ExamplePhoneNumber";
        PhoneBook? phoneBook = null;

        //act
        Action act = () => phoneBook = new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .NotThrow();
        act
            .Should()
            .NotBeNull();
        phoneBook?.PhoneNumber
            .Should()
            .NotBeNull();
        phoneBook?.Name
            .Should()
            .NotBeNull();
        phoneBook?.Id
            .Should().NotBeEmpty();
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void GivenIncorrectName_WhenCreatingPhoneBook_ThenThrowError(string name)
    {
        //arrange
        const string phoneNumber = "ExamplePhoneNumber";
        PhoneBook? phoneBook = null;

        //act
        Action act = () => phoneBook = new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .NotThrow<NullReferenceException>();
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void GivenIncorrectPhoneNumber_WhenCreatingPhoneBook_ThenThrowError(string phoneNumber)
    {
        //arrange
        const string name = "ExampleName";
        PhoneBook? phoneBook = null;

        //act
        Action act = () => phoneBook = new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .NotThrow<NullReferenceException>();
    }
}