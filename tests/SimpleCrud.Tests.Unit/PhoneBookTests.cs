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
        const string phoneNumber = "000000000";
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
        const string phoneNumber = "000000000";

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void GivenIncorrectPhoneNumber_WhenCreatingPhoneBook_ThenThrowError(string phoneNumber)
    {
        //arrange
        const string name = "ExampleName";

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Test]
    [TestCase("12345678910111213")]
    public void GivenLongerPhoneNumber_WhenCreatingPhoneBook_ThenThrowError(string phoneNumber)
    {
        //arrange
        const string name = "ExampleName";

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("*cannot be more than 15*");
    }

    [Test]
    public void GivenLongerName_WhenCreatingPhoneBook_ThenThrowError()
    {
        //arrange
        const string phoneNumber = "000000000";
        var name = new string('*', 200);

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("*cannot be more than 100*");
    }
    
    [Test]
    public void GivenWrongPhoneNumber_WhenCreatingPhoneBook_ThenThrowError()
    {
        //arrange
        const string phoneNumber = "aa000000";
        var name = new string('*', 200);

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("*phone number format*");
    }
    
    [Test]
    public void GivenWrongName_WhenCreatingPhoneBook_ThenThrowError()
    {
        //arrange
        const string phoneNumber = "000000000";
        var name = new string('1', 50);

        //act
        Action act = () => new PhoneBook(phoneNumber, name);

        //assert
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("*only contain letters and spaces*");
    }
}