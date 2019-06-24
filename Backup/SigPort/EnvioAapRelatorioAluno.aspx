<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvioAapRelatorioAluno.aspx.cs" Inherits="SigPort.EnvioAapRelatorioAluno" %>

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
   <script>       jQuery(function ($) { $("#txtRaIntegrante1").mask("9999999999999"); $("#txtRaIntegrante2").mask("9999999999999"); $("#txtRaIntegrante3").mask("9999999999999"); $("#txtRaIntegrante4").mask("9999999999999"); });</script>
   <style>.wow:first-child {visibility: hidden;}</style>
</head>
<body>
    <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
        <center>
            <div class="containerAapAlunoeRelatorio" style="float: none;margin-left:0%;">
               <br />
                <form id="form1" runat="server" enctype="multipart/form-data">
                    <p class="descricaoForms" style="float: none;">Selecione o arquivo para o upload da AAP</p>
                    <input type="file" name="arquivoAap" ID="btnUploadAap" style="margin-top:7%;" required/>
                    <div class="clearfix"></div>
                    <br /><br />
                    <hr class="linhaDivisoria"/>
                    <br /><br />
                    <p class="descricaoForms" style="float: none;">Selecione o arquivo para o upload do Relatório</p>
                    <input type="file" name="arquivoRelatorio" ID="btnUploadRelatorio" style="margin-top:7%;" required/>
                    <div class="clearfix"></div>
                    <br /><br /><br />
                    <hr class="linhaDivisoria"/>
                    <br /><br />

                    <br />
                    <asp:Label ID="lblTituloSelecionaAap" runat="server" Text="Informe os dados" class="tituloTabelaInformacoes"></asp:Label>
                    <br /><br /><br />
                    <asp:TextBox ID="txtNomeIntegrante1" runat="server" placeholder="Nome do 1° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtRaIntegrante1" runat="server" placeholder="Ra do 1° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNomeIntegrante2" runat="server" placeholder="Nome do 2° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtRaIntegrante2" runat="server" placeholder="Ra do 2° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNomeIntegrante3" runat="server" placeholder="Nome do 3° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtRaIntegrante3" runat="server" placeholder="Ra do 3° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNomeIntegrante4" runat="server" placeholder="Nome do 4° integrante: " class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtRaIntegrante4" runat="server" placeholder="Ra do 4° integrante: " class="txtLadoaLado" required></asp:TextBox>
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
