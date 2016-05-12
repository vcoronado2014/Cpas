<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="VCFramework.SitioWeb.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="description" content="Metro, a sleek, intuitive, and powerful framework for faster and easier web development for Windows Metro Style.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, framework, metro, front-end, frontend, web development">
    <meta name="author" content="Sergey Pimenov and Metro UI CSS contributors">

    <title>Ingreso</title>

    <link href="css/metro.css" rel="stylesheet"/>
    <link href="css/metro-icons.css" rel="stylesheet"/>
    <link href="css/metro-responsive.css" rel="stylesheet"/>

    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/metro.js"></script>

    <style>
        .login-form {
            width: 25rem;
            height: 20.75rem;
            position: fixed;
            top: 50%;
            margin-top: -10.375rem;
            left: 50%;
            margin-left: -12.5rem;
            background-color: #ffffff;
            opacity: 0;
            -webkit-transform: scale(.8);
            transform: scale(.8);
        }
        .simple-list li, .numeric-list li {
            padding: 0;
        }
    </style>
        <script>

        /*
        * Do not use this is a google analytics fro Metro UI CSS
        * */
        if (window.location.hostname !== 'localhost') {

            (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
                (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
                    m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
            })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

            ga('create', 'UA-58849249-3', 'auto');
            ga('send', 'pageview');

        }


        $(function(){
            var form = $(".login-form");

            form.css({
                opacity: 1,
                "-webkit-transform": "scale(1)",
                "transform": "scale(1)",
                "-webkit-transition": ".5s",
                "transition": ".5s"
            });
        });
    </script>

</head>
<body class="bg-darkTeal">
    <div class="login-form padding20 block-shadow">
        <form id="form1" runat="server">

            <h1 class="text-light">Ingreso al Sistema</h1>
            <hr class="thin" />
            <br />
            
                <%--<label for="user_login">Nombre de Usuario:</label>--%>
                <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario:"></asp:Label>
            <div class="input-control text full-size" data-role="input">
                <asp:TextBox ID="user_login" runat="server"></asp:TextBox>
                <button class="button helper-button clear"><span class="mif-cross"></span></button>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Usuario Requerido" ControlToValidate="user_login" Display="None"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <label>Contraseña:</label>
            <div class="input-control password full-size" data-role="input">
                <asp:TextBox ID="user_password" runat="server" TextMode="Password"></asp:TextBox>
                <button class="button helper-button reveal"><span class="mif-looks"></span></button>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Requerida" ControlToValidate="user_password" Display="None"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="form-actions">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="numeric-list red-bullet fg-red no-padding no-margin" Font-Size="8pt" />
            </div>
            <div class="form-actions">
                <%--<button type="submit" class="button primary">Login to...</button>--%>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar..." CssClass="button primary" OnClick="btnIngresar_Click" />
                <%--<button type="button" class="button link">Cancelar</button>--%>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="button" NavigateUrl="~/default.aspx">Cancelar</asp:HyperLink>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="right" NavigateUrl="~/RecuperarClave/Cambiar.aspx">Recuperar mi clave</asp:HyperLink>
            </div>

        </form>
    </div>
</body>
</html>
