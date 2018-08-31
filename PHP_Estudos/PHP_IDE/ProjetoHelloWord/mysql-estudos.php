<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

header("Content-Type: application/json");
    
define("DB_NAME","estudos_lucas");
$con = new mysqli("localhost","root","",DB_NAME);

if($con->connect_error){
    echo $con->connect_error;
    return ;
}
#IF I AN HERE SO AT TOP $CON DONT FOUND ANY ERROR
#echo "conectado com sucesso";

# DO QUERY
$res = mysqli_query( $con, "SELECT nome,marca FROM carro ");



$json = [];
$json_conter = 0;

# DO FETCH 
while( $a = mysqli_fetch_assoc($res) ) {
    
    $json[ $json_conter ] = array ( "nome"=>$a['nome'] , "marca" => $a['marca'] );
    $json_conter++;
}       
#ENCODE JSON
$json_encoded = json_encode($json);

#DELIVER JSON
echo $json_encoded;

$con->close();


/*
$res = mysqli_query($con,"select nome,marca from carro");

while ( $a = mysqli_fetch_assoc($res) ){
    echo "<p> Nome " . $a['nome'];
    echo " Marca ". $a['marca'] . "</p>";
    
}
 * */
 