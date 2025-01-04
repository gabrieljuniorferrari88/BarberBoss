using BarberBoss.Application.UseCases.Invoices;
using BarberBoss.Communication.Enums;
using BarberBoss.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Invoices.Register;

public class RegisterInvoiceValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new InvoiceValidator();
        var request = RequestRegisterInvoiceJsonBuilder.Build();
       
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("          ")]
    [InlineData(null)]
    public void Error_Title_Empty(string? title)
    {
        //Arrange
        var validator = new InvoiceValidator();
        var request = RequestRegisterInvoiceJsonBuilder.Build();
        request.Title = title!;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(_ => _.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new InvoiceValidator();
        var request = RequestRegisterInvoiceJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(_ => _.ErrorMessage.Equals(ResourceErrorMessages.INVOICES_CANNOT_FOR_THE_FUTURE));
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new InvoiceValidator();
        var request = RequestRegisterInvoiceJsonBuilder.Build();
        request.ReceiptType = (ReceiptType)777;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(_ => _.ErrorMessage.Equals(ResourceErrorMessages.RECEIPT_TYPE_INVALID));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new InvoiceValidator();
        var request = RequestRegisterInvoiceJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(_ => _.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
}