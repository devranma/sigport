<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="revisaoDeNota.aspx.cs" Inherits="SigPort.revisaoDeNota" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGPORT</title>
	<link rel="stylesheet" type="text/css" href="css/estilo.css"/>
	<link rel="icon" href="homeicon.png"/>
	<meta charset="utf-8"/>
	<meta name="author" content="Mike Ewerthon de Figueiredo Silva" />
	<link rel="stylesheet" href="css/libs/animate.css"/>
  	<link rel="stylesheet" href="css/site.css"/>
	<script src="js/script.js"></script>
    <script src="js/jquery-1.5.2.min.js"></script>
	<script src="js/jquery.maskedinput-1.3.min.js"></script>
   <script>jQuery(function ($) {$("#txtDataRevisao").mask("99/99/9999");});</script>
   <style>.wow:first-child {visibility: hidden;}</style>
</head>
<body>
     <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
        <center>
            <div class="containerAapAlunoeRelatorio"><p style="margin-top: 30%;font-size: 15px;font-family:'Tahoma';color: #808080;">AAP do aluno</p></div>
            <div class="containerAapAlunoeRelatorio">
                <br />
                <asp:Label ID="lblTituloSelecionaAap" runat="server" Text="Informe os dados" class="tituloTabelaInformacoes"></asp:Label>
                <br /><br /><br />
                <form id="form1" runat="server">
                    <asp:TextBox ID="txtNomeAluno" runat="server" placeholder="Nome do aluno: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtRaAluno" runat="server" placeholder="Ra do aluno: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:DropDownList ID="selecionarAap" runat="server" class="txtLadoaLado">
                        <asp:ListItem Value="Modelagem de Processos" />
                        <asp:ListItem Value="Engenharia de Software e Aplicações" />
                        <asp:ListItem Value="Banco de Dados e Aplicações" />
                        <asp:ListItem Value="Programação para Internet" />
                        <asp:ListItem Value="Sistemas Integrados de Gestão e Aplicações" />
                        <asp:ListItem Value="Projetos de Tecnologia da Informação II" />
                    </asp:DropDownList>
                    <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descrição: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtMotivoRevisao" runat="server" placeholder="Motivo da Revisão: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtDataRevisao" runat="server" placeholder="Data da Revisão: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaAnterior" runat="server" placeholder="Digite a nota: " value="6.5" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaRevisada" runat="server" placeholder="Digite a nota revisada: " class="txtLadoaLado" required></asp:TextBox>
                    <div class="clearfix"></div><br /><br /><br /><br />
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" class="btnRevisaoNotas"/>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" class="btnRevisaoNotas"/>
                    <br /><br />
                </form>
            </div>
            <div class="clearfix"></div>
        </center>
    </div>
    <div class="clearfix"></div>
        <% Response.WriteFile("rodape.htm"); %>
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
