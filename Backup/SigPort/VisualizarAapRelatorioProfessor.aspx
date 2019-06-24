<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarAapRelatorioProfessor.aspx.cs" Inherits="SigPort.VisualizarAapRelatorioProfessor" %>

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
    <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
		<center>
			<div class="blocoFormularioRevisaoNotas">
				<p class="descricaoForms">Nome da Aap, nome do aluno ou RA.</p>
				<div class="clearfix"></div>
				<form style="margin-top: 4%;" id="form1" runat="server">
                    <asp:TextBox ID="txtPesquisa" runat="server" class="txtInputs" placeholder="Informe uma das sugestões:" required="required"></asp:TextBox>
                    <asp:Button ID="btnRevisaoNotas" runat="server" Text="Pesquisar" class="wow bounceIn" data-wow-delay="0.5s"/>
				</form>
				<div class="clearfix"></div>
				<table border="1" style="margin-top: 4%;">
					<tr>
						<td class="tituloTabelaInformacoes">RA</td>
						<td class="tituloTabelaInformacoes">Aluno</td>
						<td class="tituloTabelaInformacoes">AAP</td>
						<td class="tituloTabelaInformacoes">Nota</td>
					</tr>
					<tr>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">1550781621021</span></td>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Paulo Roberto</span></td>
						<td class="tabelaInformacoes"><img src="img/icone-pdf.jpg" class="ilustracaoTabelasInformacoes"><span class="textoStatusInformacoes">Modelagem de Processos</span></td>
						<td class="tabelaInformacoes"><span class="textoFeedbackInformacoes" style="color:#36ff00;">10,0</span></td>
					</tr>
                    <tr>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">1550781621010</span></td>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Aline Rodrigues</span></td>
						<td class="tabelaInformacoes"><img src="img/icone-pdf.jpg" class="ilustracaoTabelasInformacoes"><span class="textoStatusInformacoes">Engenharia de Software e Aplicações</span></td>
						<td class="tabelaInformacoes"><span class="textoFeedbackInformacoes" style="color:#ff0000;">3,6</span></td>
					</tr>
                    <tr>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">1550781621032</span></td>
						<td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Marcelo Fontineli</span></td>
						<td class="tabelaInformacoes"><img src="img/icone-pdf.jpg" class="ilustracaoTabelasInformacoes"><span class="textoStatusInformacoes">Sistemas Integrados e Aplicações</span></td>
						<td class="tabelaInformacoes"><span class="textoFeedbackInformacoes" style="color:#36ff00;">8,3</span></td>
					</tr>
				</table>
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
