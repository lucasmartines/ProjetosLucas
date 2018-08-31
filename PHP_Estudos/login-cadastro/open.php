<?php

session_start();

$con = mysqli_connect( "localhost" , "root" , ""  , "server"); 

if (!$con ){ // dont exist connection so die close app and show error
    die ("Connection Failed: " . mysqli_connect_error() );

}

$login = mysqli_real_escape_string( $con , $_POST['login'] );
$senha = mysqli_real_escape_string ( $con , $_POST['senha'] );

$sql_command = "select NOME,SENHA from usuario where NOME = '$login' and SENHA = '$senha'";
$result = mysqli_query( $con , $sql_command ) ;

if( !empty(  mysqli_error() ) ) {
    echo "erro com comando sql " . mysql_error();
}



if ( mysqli_num_rows( $result ) > 0){
    $_SESSION['login'] = $login;
    $_SESSION['senha'] = $senha;
    header('location:site.php');
   
}
else{
    unset( $_SESSION['login'] );
    unset( $_SESSION['senha'] );
    header('location:index.php');
}