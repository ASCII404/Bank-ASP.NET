<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreditSimulator.aspx.vb" Inherits="Bank.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Credit simulator</title>
    <link href="/CSS/main_page.css" rel="stylesheet" type="text/css"/>
    <link href="/CSS/CreditSimulator.css" rel="stylesheet" type="text/css"/>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/JS/page_functionality.js" defer></script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav>
                <ul>
                    <li><a href="/HTML/main_page.html" class="nav-link">Home</a></li>
                    <li><a href="/HTML/about.html" class="nav-link">About</a></li>
                    <li><a href="/Webforms/CreditSimulator.aspx" class="nav-link">Loan</a></li>
                    <li><a href="/Webforms/Account.aspx" class="nav-link">Account</a></li>
                    <li><a href="/Webforms/LogIn.aspx" class="log_out" id="logOut">Log out</a></li>
                </ul>
                <div id="user_div">GUEST</div>

            </nav>
        </header>
        <div class="container">
            <div class="center">
                <label for="txtName">Your name</label>
                <input type="text" id="txtName" class="input-field" />
            </div>

            <div class="center">
                <label for="txtAmount">Amount of money in $</label>
                <input type="text" id="txtAmount" class="input-field" />
            </div>


            <label id="loan_type">Loan Type:</label>
            <div class="loans">
                <div>
                    <input type="radio" id="radio1" name="loanType" value="loan1" checked/>
                    <label for="radio1">Loan 1</label>
                </div>
                <div>
                    <input type="radio" id="radio2" name="loanType" value="loan2"/>
                    <label for="radio2">Loan 2</label>
                </div>
                <div>
                    <input type="radio" id="radio3" name="loanType" value="loan3"/>
                    <label for="radio3">Loan 3</label>
                </div>
                <div>
                    <input type="radio" id="radio4" name="loanType" value="loan4"/>
                    <label for="radio4">Loan 4</label>
                </div>
            </div>

            <div class="center">
                <label for="startDate">Start of Contract Period:</label>
                <input type="datetime-local" id="startDate" class="input-field" />
            </div>


            <div class="center">
                <label for="endDate">End of Contract Period:</label>
                <input type="datetime-local" id="endDate" class="input-field" />
            </div>

            <div class="center">
                <button type="button" id="btnCalculate" class="button">Calculate</button>
            </div>


            <label id="lblResult" class="result-label"></label>
        </div>


        <footer>
            <p>Copyright &copy; 2023</p>
        </footer>
    </form>
    <script src="/JS/LogIn_session.js"></script>
</body>
</html>
