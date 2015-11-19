﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RPPresentationLayer._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8" />
            <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Custom Login Form Styling</title>
            <meta name="description" content="Custom Login Form Styling with CSS3" />
            <meta name="keywords" content="css3, login, form, custom, input, submit, button, html5, placeholder" />
            <meta name="author" content="Codrops" />
            <link rel="shortcut icon" href="../favicon.ico">
            <link rel="stylesheet" type="text/css" href="css/style.css" />
            <script src="js/modernizr.custom.63321.js"></script>
            <!--[if lte IE 7]><style>.main{display:none;} .support-note .note-ie{display:block;}
</style>
<![endif]-->
            <style>
                @import url(http://fonts.googleapis.com/css?family=Montserrat:400,700|Handlee);
                body
                {
                    background: #eedfcc url(images/bg3.jpg) no-repeat center top;
                    -webkit-background-size: cover;
                    -moz-background-size: cover;
                    background-size: cover;
                }
                .container > header h1, .container > header h2
                {
                    color: #fff;
                    text-shadow: 0 1px 1px rgba(0,0,0,0.5);
                }
            </style>
        </head>
        <body>
            <div class="container">
                <!-- Codrops top bar -->
                
                <!--/ Codrops top bar -->
                <header>
			
				
				<nav class="codrops-demos">
					<a href="index.html">Demo 1</a>
					<a href="index2.html">Demo 2</a>
					<a href="index3.html">Demo 3</a>
					<a href="index4.html">Demo 4</a>
					<a class="current-demo" href="index5.html">Demo 5</a>
				</nav>

				<div class="support-note">
					<span class="note-ie">Sorry, only modern browsers.</span>
				</div>
				
			</header>
                <section class="main">
				<form class="form-5 clearfix">
				    <p>
				        <input type="text" id="login" name="login" placeholder="Username">
				        <input type="password" name="password" id="password" placeholder="Password"> 
				    </p>
				    <button type="submit" name="submit">
				    	<i class="icon-arrow-right"></i>
				    	<span>Sign in</span>
				    </button>     
				</form>​​​​
			</section>
            </div>
            <!-- jQuery if needed -->
            <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
            <script type="text/javascript" src="js/jquery.placeholder.min.js"></script>
            <script type="text/javascript">
                $(function () {
                    $('input, textarea').placeholder();
                });
		</script>
        </body>
        </html>
