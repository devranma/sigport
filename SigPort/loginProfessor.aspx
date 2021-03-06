﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login - professor.aspx.cs" Inherits="SigPort.login___professor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGPORT</title>
	<link rel="stylesheet" type="text/css" href="css/estilo.css">
	<link rel="icon" href="homeicon.png">
	<meta charset="utf-8">
	<meta name="author" content="Mike Ewerthon de Figueiredo Silva" />
	<link rel="stylesheet" href="css/libs/animate.css">
  	<link rel="stylesheet" href="css/site.css">
	<script src="js/script.js"></script>
   <script src="js/jquery-1.5.2.min.js"></script>
   <style>.wow:first-child {visibility: hidden;}
       .auto-style1 {
           border-radius: 8px;
           width: 80%;
           margin-top: 0%;
           height: auto;
           min-height: 200px;
           padding: 10px;
           background-color: #ffffff;
       }
   </style>
</head>
<body>
    <div class="containerPaginaLogin">
		<center>
			<div class="blocosLargura50">
				<div class="boasVindasTelaLogin">
					<span><strong>Bem vindo Professor</strong><br><br>Insira os dados solicitados para conectar-se ao sistema.</span>
				</div>
			</div>
			<div class="blocosLargura50">
				<h1 class="tituloPaginaLogin">SIGPORT<br><span>Sistema Gerenciador de Portfólio</span></h1>
				<div class="auto-style1">
					<form id="form1" runat="server">
                        <asp:TextBox ID="txtInputLogin" runat="server" placeholder="Usuário:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox ID="txtSenhaLogin" type="password" runat="server" placeholder="Senha:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:Button ID="btnSubmitLogin" runat="server" Text="Entrar" class="wow bounceIn" data-wow-delay="0.3s" Height="25px" OnClick="btnSubmitLogin_Click"/>
					<p class="opcaoRecuperarSenhaLogin">Recuperar Senha</p>				
					</form>
				</div>
				<p class="tituloPaginaLogin">
                    <asp:HyperLink ID="hlCadastro" runat="server" NavigateUrl="~/cadastrarProfessor.aspx">Não possui cadastro? Clique aqui e cadastre-se!</asp:HyperLink>
                </p>
			</div>
			<div class="clearfix"></div>
			<img src="img/logo fatec.png" id="imgLogotiposLogin" class="wow bounceIn" data-wow-delay="0.3s">
			<img src="img/logo-cps-branco.png" id="imgLogotiposLogin" class="wow bounceIn" data-wow-delay="0.6s">
			<div class="clearfix"></div>
		</center>
	</div>
	<script src="dist/wow.js"></script>		
	<script>
	    wow = new WOW(
		{
		    animateClass: 'animated',
		    offset: 100,
		    callback: function (box) {
		        console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
		    }
		}
		);
	    wow.init();
	    document.getElementById('moar').onclick = function () {
	        var section = document.createElement('section');
	        section.className = 'section--purple wow fadeInDown';
	        this.parentNode.insertBefore(section, this);
	    };
	</script>
</body>
</html>
