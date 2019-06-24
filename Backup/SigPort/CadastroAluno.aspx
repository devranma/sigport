<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroAluno.aspx.cs" Inherits="SigPort.CadastroAluno" %>
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
   <style>.wow:first-child {visibility: hidden;}</style>
</head>
<body>
<div class="containerPaginaLogin">
        <br /><br />
		<center>		
			<div class="blocosLargura50">
				<div class="boasVindasTelaLogin">				
					<span>Ao se cadastrar você concorda com os nossos <strong><a href="" style="text-decoration: none;color: #ffffff;">Termos de Uso</a></strong></span>
				</div>
			</div>
			<div class="blocosLargura50">
				<h1 class="tituloPaginaLogin">SIGPORT<br><span>Sistema Gerenciador de Portfólio</span></h1>
				<div class="blocoLogin">
					<form id="form1" runat="server">
                        <asp:TextBox ID="txtNomeUsuario" runat="server" placeholder="Nome Completo:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox ID="txtRaUsuario" runat="server" placeholder="R.A:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox ID="txtSemestreUsuario" runat="server" placeholder="Semestre atual:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox ID="txtEmailUsuario" runat="server" placeholder="E-mail:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox type="password" ID="txtSenhaUsuario" runat="server" placeholder="Senha:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox type="password" ID="txtConfirmacaoSenhaUsuario" runat="server" placeholder="Confirme a senha:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:Button ID="btnSubmitLogin" runat="server" Text="Cadastrar" class="wow bounceIn" data-wow-delay="0.3s"/>
					</form>
				</div>
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
