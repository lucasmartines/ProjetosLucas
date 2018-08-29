<?php 
    $name = $_GET['nome'];
    $email = $_GET['email'];
    $lastname = $_GET['lastname'];

    try{
        $conn = new PDO("mysql:host=localhost;dbname=megaglobal","root","");
        //$cmd = "insert into robo (name,email,lastname) values ('engine n9',' delta@49889.com','delta')      ";  
        $cmd = "insert into robo (name,email,lastname) values ('$name','$email','$lastname')      ";  
        $conn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        $conn->exec($cmd);
        echo "all right";
        
    }
    catch( PDOException $ex ){
        echo $ex;
    }
    
?>
<a href="adicionar.php"> voltar </a>