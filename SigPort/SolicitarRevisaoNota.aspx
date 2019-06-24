<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitarRevisaoNota.aspx.cs" Inherits="SigPort.SolicitarRevisaoNota" %>
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
                <p class="descricaoForms">Solicite a revisão de notas</p>
                <div style="clear:both;"></div>
			    <form id="form1" runat="server" style="margin-top: 4%;">
                    <asp:Button ID="btnRevisaoNotas" runat="server" Text="Confirmar" class="wow bounceIn" data-wow-delay="0.5s"/>
                    <asp:DropDownList ID="dropSelecionarAap" runat="server" class="dropRevisaoNotas" required="required">
                        <asp:ListItem Value="Selecione --" />
                        <asp:ListItem Value="Portfólio 1" />
                        <asp:ListItem Value="Portfólio 2" />
                    </asp:DropDownList>
				    <div class="clearfix"></div>
                    <asp:TextBox ID="txtRevisaoNotas" runat="server" class="txtRevisaoNotas" placeholder="Digite os argumentos:"></asp:TextBox>
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
