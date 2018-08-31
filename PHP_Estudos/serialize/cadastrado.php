<?php 
    if( isset ($_GET['test'] ) ){
        echo "Olá " . $_GET['test'] . " você foi cadastrado com sucesso";
        echo  "<a href = 'cadastro.php'> cadastro </a>";
    }
    else{
        header("cadastro.php");
    }
?>