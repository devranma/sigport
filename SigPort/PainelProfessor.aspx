<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelProfessor.aspx.cs" Inherits="SigPort.PainelProfessor" %>

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
            <a href="VisualizarAapRelatorioProfessor.aspx">
                <img src="img/visualizar-aap-e-relatorios.png" class="wow bounceIn" data-wow-delay="0.3s" id="botoesPainelProfessor" style="margin-left:0%;"/>
            </a>
            <a href="envioDeNotaseRelatorios.aspx">
                <img src="img/inserir-notas-aap.png" class="wow bounceIn" data-wow-delay="0.3s" id="botoesPainelProfessor"/>
            </a>
            <a href="InserirAlunoNoSistema.aspx">
                <img src="img/botao-inserir-alunos.png" class="wow bounceIn" data-wow-delay="0.3s" id="botoesPainelAluno"/>
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
