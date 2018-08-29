<?php

if( isset( $_COOKIE[ 'logado' ] ) ){
    echo "Bem vindo <h1 style='display:inline'> " . $_COOKIE['nome'] . "</h1> </br>";
}
if( isset ( $_GET['submit'] ) )
{
    
    print_r(  $_GET['submit'] );
    if( $_GET['submit'] == "Logoff"){
    
        setcookie( 'nome' ,"",time()-3600 );
        setcookie( 'logado' ,"",time()-3600 );
        header( "Location:login.php") ;
      
        
    }
  

    
}

  
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
        <a href='table_select.php'> Todos os Cadastrados </a>
        <a href='login.php'> Login</a>
        <?php if ( isset( $_COOKIE['logado'] ) ) {  ?>   
            <form action='index.php' method='get' >
                    <input type='submit' name='submit' value = 'Logoff'/> 
            </form>
         <?php } ?>

    </div>
</body>
</html>