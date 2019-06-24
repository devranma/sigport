<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="SigPort.Relatorios" %>

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
            <form id="form1" runat="server">
                <div class="blocoFormularioRevisaoNotas" style="margin-top: 4%;">
                    <asp:DropDownList ID="dropMateirasAap" runat="server" class="txtInputs" style="margin-top: 4%;">
                        <asp:ListItem Value="Modelagem de Processos" />
                        <asp:ListItem Value="Engenharia de Software e Aplicações" />
                        <asp:ListItem Value="Banco de Dados e Aplicações" />
                        <asp:ListItem Value="Programação para Internet" />
                        <asp:ListItem Value="Sistemas Integrados de Gestão e Aplicações" />
                        <asp:ListItem Value="Projetos de Tecnologia da Informação II" />
                    </asp:DropDownList>
                    <asp:TextBox ID="txtPesquisa" runat="server" class="txtInputs" placeholder="Nome ou RA do aluno:" style="margin-top: 4%;"></asp:TextBox>
                    <div class="clearfix"></div>
                    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btnRevisaoNotas" style="margin-top: 3%;"/>
                    <div class="clearfix"></div>
                    <table border="1" style="margin-top: 4%;">
                        <tr>
                            <td class="tituloTabelaInformacoes">RA</td>
                            <td class="tituloTabelaInformacoes">NOME</td>
                            <td class="tituloTabelaInformacoes">DISCIPLINA</td>
                            <td class="tituloTabelaInformacoes">STATUS</td>
                            <td class="tituloTabelaInformacoes">NOTA</td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1550781711015</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Victor Mattheu</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Modelagem de Processos</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Aprovado</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">8</span></td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1550781711016</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Luciano Fernandes</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Programação para Internet</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Aprovado</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">4</span></td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1551781711017</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Matheus Caetano</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Engenharia de Software e Aplicações</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Aprovado</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">9</span></td>
                        </tr>
                    </table>
                    <br /><br />
                    <asp:Button ID="btnRevisaoNotas" runat="server" Text="Exportar Dados" />
                    <div class="clearfix"></div>
                </div>
            </form>
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
