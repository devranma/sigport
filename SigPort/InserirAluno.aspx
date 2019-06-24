<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InserirAluno.aspx.cs" Inherits="SigPort.InserirAluno" %>

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
            <form id="form1" runat="server" enctype="multipart/form-data">
                <div class="blocoFormularioRevisaoNotas" style="margin-top: 4%;">
                    <asp:Label ID="lblAvisoArquivoEnviado" runat="server" Text="" class="descricaoForms"></asp:Label>
                    <div class="clearfix"></div>
                    <p class="descricaoForms">Solicite a revisão de notas</p>
                    <input type="file" name="arquivoParaRevisao" required ID="btnUploadArquivo" style="margin-top:2%;float:left;margin-left:2%;"/>
                    <div class="clearfix"></div>
                    <table border="1" style="margin-top: 4%;">
                        <tr>
                            <td class="tituloTabelaInformacoes">RA</td>
                            <td class="tituloTabelaInformacoes">NOME</td>
                            <td class="tituloTabelaInformacoes">NOTA</td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1550781621015</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Mike Figueiredo</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">10</span></td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1550781621018</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Higor Venâncio</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">6</span></td>
                        </tr>
                        <tr>
                            <td class="tabelaInformacoes"><input type="checkbox" value="" id=""/><span class="textoTabelaInformacoes">1550781621022</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">Leandro Paes</span></td>
                            <td class="tabelaInformacoes"><span class="textoTabelaInformacoes">8</span></td>
                        </tr>
                    </table>
                    <br /><br />
                    <asp:Button ID="btnConfirmar" class="btnRevisaoNotas" runat="server" Text="Confirmar" />
                    <asp:Button ID="btnAlterar" class="btnRevisaoNotas" runat="server" Text="Alterar" />
                    <asp:Button ID="btnLimpar" class="btnRevisaoNotas"  runat="server" Text="Limpar" />
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
