<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelAluno.aspx.cs" Inherits="SigPort.PainelAluno" %>

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
            <a href="EnvioAapRelatorioAluno.aspx">
                <img src="img/enviar-aap-e-relatorios.png" class="wow bounceIn" data-wow-delay="0.3s" id="botoesPainelAluno"/>
            </a>
            <a href="VisualizarAapRelatorioAluno.aspx">
                <img src="img/visualizar-aap-e-relatorios.png" class="wow bounceIn" data-wow-delay="0.6s" id="botoesPainelAluno"/>
            </a>
            <a href="SolicitarRevisaoNota.aspx">
                <img src="img/pedido-para-revisar-notas.png" class="wow bounceIn" data-wow-delay="0.9s" id="botoesPainelAluno"/>
            </a>
            <a href="CadastrarPortfolio.aspx">
                <img src="img/designar-aap-por-portfolio.png" class="wow bounceIn" data-wow-delay="1.2s" id="botoesPainelAluno"/>
            </a>
        </center>
        <div class="clearfix"></div>
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
