$(document).ready(function () {
    $("#<%= txtName.ClientID %>").on("keyup", function () {
        var fullName = $(this).val();
        if (fullName.trim() === "") {
            $("#NameError").text("Name is required.").show();
        } else if (!/^[A-Za-z]+$/.test(fullName)) {
            $("#NameError").text("Name should contain only letters.").show();
            $(this).addClass("invalid-input");
        } else {
            $("#NameError").hide();
            $(this).removeClass("invalid-input");
        }
    });

    // Validate amount
    $("#<%= txtAmount.ClientID %>").on("input", function () {
        var amount = $(this).val();
        if (amount.trim() === "" || isNaN(amount)) {
            $("#AmountError").text("Amount is invalid.").show();
        } else {
            $("#AmountError").hide();
        }
    });

    // Other validation checks for start date, end date, etc.
    // ...

    // Validate form on button click
    $("#btnCalculate").click(function () {
        var isValid = true;

        // Perform the same validation checks as shown in the previous example
        // ...

        if (isValid) {
            $("#CalculatePayment").submit();
        }
    });
});
