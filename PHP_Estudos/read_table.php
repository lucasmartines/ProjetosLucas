<?php 
    try{
        $conn = new PDO("mysql:host=localhost;dbname=megaglobal","root","");
        $conn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        foreach ( $conn->query("select name,email from robo") as $row){
            print( " <h3 style='display:inline'> nome : ". $row['name']."\t"."</h3>" );
            print( " <h4 style='display:inline'> email: ".$row['email']." </h4>\t ");
            print("</br> \n");
        }
    }
    catch( PDOException $error){
        echo $error;
    }

?>