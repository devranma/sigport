<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastrarProfessor.aspx.cs" Inherits="SigPort.cadastrarProfessor" %>

<!DOCTYPE html>

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
           margin-top: 1%;
           height: 283px;
           min-height: 200px;
           padding: 10px;
           background-color: #ffffff;
       }
   </style>
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
				<div class="auto-style1">
					<form id="form1" runat="server">
                        <asp:TextBox ID="txtNomeProfessor" runat="server" placeholder="Nome do professor:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:DropDownList ID="disciplinas" runat="server" class="slcForms" Height="98px">
                                <asp:ListItem Value="Modelagem de Processos" />
                                <asp:ListItem Value="Engenharia de Software e Aplicações" />
                            <asp:ListItem Value="Banco de Dados e Aplicações" />
                            <asp:ListItem Value="Programação para Internet" />
                            <asp:ListItem Value="Sistemas Integrados de Gestão e Aplicações" />
                            <asp:ListItem Value="Projetos de Tecnologia da Informação II" />
                                <asp:ListItem>TG1</asp:ListItem>
                                <asp:ListItem>TG2</asp:ListItem>
                                <asp:ListItem Selected="True">Selecione</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtNomeUsuario" runat="server" placeholder="Nome de usuário" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox type="password" ID="txtSenhaUsuario" runat="server" placeholder="Senha:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:TextBox type="password" ID="txtConfirmacaoSenhaUsuario" runat="server" placeholder="Confirme a senha:" required="required" class="inputLogin"></asp:TextBox>
                        <asp:Button ID="btnSubmitLogin" runat="server" Text="Cadastrar" class="wow bounceIn" data-wow-delay="0.3s" OnClick="btnSubmitLogin_Click"/>
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
</html>
