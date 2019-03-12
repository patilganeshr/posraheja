<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="POS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
	<title>Login</title>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />

	<link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" />

	<link rel="stylesheet" type="text/css" href="Content/css/vendor/font-awesome/font-awesome.min.css" />
	<link rel="stylesheet" type="text/css" href="Content/css/vendor/bootstrap/bootstrap.min.css" />
	<link rel="stylesheet" type="text/css" href="Content/css/vendor/sweetalert/sweetalert.css" />
	<link rel="stylesheet" type="text/css" href="Content/css/app/login.css" />

</head>
<body>
	<form id="form1" runat="server">

		

		<div class="container-fluid">
			<div class="overlay">
				<div class="left-side">
				</div>

				<div class="right-side">
					<div class="login-details col-lg-9">

						<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
							<div class="form-group form-group-md">
								<label>Username</label>
								<input type="text" id="username" class="form-control" placeholder="Username" required ="required" runat="server" />                    
							</div>
						</div>
						<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
							<div class="form-group form-group-md">
								<label>Password</label> 
								<input type="password" id="password" class="form-control" placeholder="Password" required="required" runat="server" />
							</div>
						</div>

						<div class="pull-right">
						<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
							<div class="form-group">
								<asp:Button ID="LogIn" runat="server" CssClass="btn btn-success btn-md" Text="Log in" OnClick="LogIn_Click" />
							</div>
						</div>
						</div>

					</div>
				</div>
			</div>
		</div>
	</form>

	<script src="Content/scripts/vendor/jquery/jquery-3.1.1.min.js"></script>
	<script src="Content/scripts/vendor/sweetalert/sweetalert.min.js"></script>

	<asp:Literal ID="alertMessage" runat="server"></asp:Literal>

</body>
</html>
