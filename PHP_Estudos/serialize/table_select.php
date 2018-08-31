<?php
function ShowDataInTables(){ 

    
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

    $con = new mysqli("localhost","root","","server");

    if(!$con){
        die("fail connection" . mysqli_connect_error() ) ;
    }

    $sql = "SELECT NOME,SENHA FROM usuario ";

    $res = mysqli_query($con,$sql);
    if(  $res ){
        if( mysqli_num_rows( $res ) ){
            echo "<caption> Tabela de Usuarios </caption>";
            echo "<table>";
                echo "<th> Nome </th> ";
                echo "<th> Senha </th> ";
                while( $row = mysqli_fetch_assoc( $res ) ){
                    echo "<tr>";
                    echo " <td> " . $row["NOME"] . "</td>";
                    echo " <td> " . $row["SENHA"] . "</td>";
                    echo "</tr>";
                    
                }
            echo "</table>";
        }
        else{
            echo "Not found data";
        }
        mysqli_close($con);
    }
    else{
        echo "erro absurdo " . mysqli_error($con);
    }
}
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style>
        body{
            background-color:#f1f1f1;
        }
        table{
            width:100%;
            border-collapse: collapse;
            border-radius:6px;

        }
        th,td{
            color:white;
        }
        td,th{
            padding:10px;
        }
        table th{
            background-color:#626787;
            color:white;
     
        }
        button#refresh{
            background-color:#626787;
            border: none;
            width:180px;
            height:40px;
            margin-top: 20px;
            float:right;
            color:#C8FDFF;
            border-radius: 20px;
        }
     
        table tr:nth-child(even){
            background-color:#6A879E;
        }
        table tr:nth-child(odd){
            background-color:#4C9394;
        }
       
    </style>
</head>
<body>
    <div style="width:800px;margin:auto auto;" >
    <?php if ( isset( $_COOKIE['logado'] ) ) {  ?>   
        <form action='index.php' method='get' >
                <input type='submit' name='submit' value = 'Logoff'/> 
        </form>
    <?php } ?>
    <a href='index.php'> Index </a> <br>
         <?php  ShowDataInTables();    ?>
         
        <button id="refresh" href="table_select.php" onclick='location.reload();'> Refresh</button>
    </div>
</body>
</html>